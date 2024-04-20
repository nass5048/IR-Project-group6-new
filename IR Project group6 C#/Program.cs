//opens The data folder TODO: fix the file path
using Pluralize.NET;

namespace IRSystem
{
    class Program
    {
        static void Process()
        {
            StreamReader reader = File.OpenText("C:\\Users\\Mike\\source\\repos\\IR Project group6 C#\\IR Project group6 C#\\Data\\00.txt");
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
                    Console.WriteLine(item);
                    temp = item.ToLower();
                    temp = pluralizer.Singularize(temp);
                    Console.WriteLine(temp);

                    list.Add(temp);
                }

                // At this point, `myInteger` and `path` contain the values we want
                // for the current line. We can then store those values or print them,
                // or anything else we like.
            }
        }
        static void Main(string[] args)
        {
            Process();
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

