using System.Text.RegularExpressions;
using IR_Project_group6_C_;
using Pluralize.NET;

namespace IRSystem
{
    class Program
    {
        static Dictionary<string, InvertedIndexData> invertedIndex = new Dictionary<string, InvertedIndexData>();
        static string DIRPATH = "..\\..\\..\\Data";

        static void Main(string[] args)
        {
            Console.WriteLine("Loading documents...");
            LoadDocuments(DIRPATH);
            Console.WriteLine("Documents loaded. Ready to receive queries.");

            string userInput;
            do
            {
                Console.Write("Enter query (or 'exit' to quit): ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput) && userInput.ToLower() != "exit")
                {
                    if (userInput.StartsWith("top"))
                    {
                        DisplayTopFrequentWords(userInput);
                    }
                    else
                    {
                        var results = Search(userInput);
                        if (results.Any())
                        {
                            foreach (var result in results)
                            {
                                Console.WriteLine($"Token: {result.token}, Soundex: {result.soundex}, Locations: {string.Join(", ", result.locationFreqs.Keys.Select(Path.GetFileName))}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No results found.");
                        }
                    }
                }
            } while (userInput.ToLower() != "exit");
        }
        static void DisplayTopFrequentWords(string command)
        {
            if (int.TryParse(command.Substring(3), out int topCount))
            {
                // Aggregate all frequencies of each token across all files and also get a Soundex code
                var topWords = invertedIndex.Values
                                .GroupBy(indexData => new { indexData.token, indexData.soundex })  // Group by token and soundex
                                .Select(group => new {
                                    Token = group.Key.token,
                                    Soundex = group.Key.soundex,
                                    Frequency = group.Sum(data => data.locationFreqs.Sum(lf => lf.Value))
                                })
                                .OrderByDescending(tf => tf.Frequency)
                                .Take(topCount)
                                .ToList();

                if (topWords.Any())
                {
                    foreach (var word in topWords)
                    {
                        Console.WriteLine($"Token: {word.Token}, Soundex: {word.Soundex}, Frequency: {word.Frequency}");
                    }
                }
                else
                {
                    Console.WriteLine("No frequent words found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command format. Use 'topXX' where XX is a number.");
            }
        }

        static void LoadDocuments(string directoryPath)
        {
            var files = Directory.EnumerateFiles(directoryPath).ToList();
            Console.WriteLine($"Files: {files.Count}");

            foreach (var file in files)
            {
                ProcessFile(file);
            }
        }

        static void ProcessFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var words = TokenizeAndNormalize(line);
                    foreach (var word in words)
                    {
                        if (!invertedIndex.ContainsKey(word))
                            invertedIndex[word] = new InvertedIndexData(word, filePath);
                        else
                            invertedIndex[word].AddLocation(filePath);
                    }
                }
            }
        }

        static List<string> TokenizeAndNormalize(string text)
        {
            var pluralizer = new Pluralizer();
            return Regex.Split(text.ToLower(), @"\W+")
                        .Where(token => token != string.Empty && !token.Any(char.IsDigit))
                        .Select(token => pluralizer.Singularize(token))
                        .ToList();
        }

        static List<InvertedIndexData> Search(string query)
        {
            List<InvertedIndexData> results = new List<InvertedIndexData>();

            // Check if the query is likely a Soundex code (typically one uppercase letter followed by three digits)
            if (Regex.IsMatch(query, @"^[A-Z][0-9]{3}$"))
            {
                // Searching by Soundex code
                foreach (var indexData in invertedIndex.Values)
                {
                    if (indexData.soundex == query)
                    {
                        results.Add(indexData);
                    }
                }
            }
            else
            {
                // Tokenizing and normalizing plaintext query
                var tokens = TokenizeAndNormalize(query);

                // Searching by plaintext token
                foreach (var token in tokens)
                {
                    if (invertedIndex.ContainsKey(token))
                    {
                        results.Add(invertedIndex[token]);
                    }
                }
            }

            return results;
        }

    }
}
