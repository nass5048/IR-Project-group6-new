//opens The data folder TODO: fix the file path
using IR_Project_group6_C_;
using Pluralize.NET;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IRSystem
{
    class Program
    {
        static List<InvertedIndexData> Sort (List<InvertedIndexData> data)
        {
            data = data.OrderByDescending(i => i.token).ToList();
            return data;
        }
        static List<InvertedIndexData> checkIndex(List<InvertedIndexData> invertedindex, string test, string location)
        {
            bool isInIndex = false;
            int i = 0;
            foreach(var index in invertedindex)
            {
                if (isInIndex)
                {
                    invertedindex[i].AddLocation(location);
                    break;
                }
                if(index.token == test)
                {
                    isInIndex = true;
                }
                i++;
            }
            if(!isInIndex)
            {
                invertedindex.Add(new InvertedIndexData(test, location));
            }
            return invertedindex;
        }
        static List<InvertedIndexData> Process(List<InvertedIndexData> data, string path)
        {

            StreamReader reader = File.OpenText(path);
            IPluralize pluralizer = new Pluralizer();
            string line;
            //grabs the text from the document and proccesses it
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(' ');
                //int myInteger = int.Parse(items[1]);   // Here's your integer.

                // Now let's find the path.
                List<string> list = new List<string>();
                foreach (string item in items)
                {
                    string temp;
                    //Console.WriteLine(item);
                    temp = item.ToLower();
                    temp = Regex.Replace(temp, @"[^\w\d\s]", "");
                    temp = pluralizer.Singularize(temp);

                    if (string.IsNullOrWhiteSpace(temp) || "1234567890".Contains(temp.First()) || "1234567890".Contains(temp.Last()))
                        continue;
                    data = checkIndex(data, temp, path.Substring(14));
                    //Console.WriteLine(temp);

                    list.Add(temp);
                }
                
                // At this point, `myInteger` and `path` contain the values we want
                // for the current line. We can then store those values or print them,
                // or anything else we like.
            }
            return data;
        }
        //need to figure out how to create the inverted index probably do this in the process function
        static InvertedIndexData Search(string query)
        {
            IPluralize pluralizer = new Pluralizer();
            string line;
            //grabs the text from the document and proccesses it
                string[] items = query.Split(' ');
                //int myInteger = int.Parse(items[1]);   // Here's your integer.

                // proccess the query
                List<string> list = new List<string>();
                foreach (string item in items)
                {
                    string temp;
                    //Console.WriteLine(item);
                    temp = item.ToLower();
                    temp = Regex.Replace(temp, @"[^\w\d\s]", "");
                    temp = pluralizer.Singularize(temp);

                    if (string.IsNullOrWhiteSpace(temp) || "1234567890".Contains(temp.First()) || "1234567890".Contains(temp.Last()))
                        continue;
                    //Console.WriteLine(temp);
                    

                    list.Add(temp);
                }

            // At this point, `myInteger` and `path` contain the values we want
            // for the current line. We can then store those values or print them,
            // or anything else we like.
            return new InvertedIndexData("e", "e");
        }
        static void Main(string[] args)
        {
            var files = from file in Directory.EnumerateFiles("..\\..\\..\\Data") select file;
            Console.WriteLine("Files: {0}", files.Count<string>().ToString());
            List<InvertedIndexData> data = new List<InvertedIndexData>();
            int docID = 0;
            foreach (var file in files)
            {
                Console.WriteLine("{0}", file);

                data = Process(data, file);
            }
            //prints out the index
            data = Sort(data);
            Console.WriteLine("_______________________");
            foreach(var t in data)
            {
                Console.WriteLine(t.token);
                Console.WriteLine(t.soundex);
            }
        }
    }
}



// See https://aka.ms/new-console-template for more information

//create a GUI
//parse files in blocks
//create the inverted index
//lookup data from the inverted index
//display if the data was found and where the data was found
//only create the inverted index when the user selects to on the gui -> this will prevent creatoin of the invertedd index every time
//see if there is a quick way to view changes in files to possibly just update the index every time a specipic file has been changed -> Metadata possibly

