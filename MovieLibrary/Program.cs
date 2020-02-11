using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "movies.csv";

            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Print movies list.");
                Console.WriteLine("2) Add movie to list.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("Movie ID: {0}, Movie: {1}, Genres: {2}", arr[0], arr[1], arr[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }

                }
                else if (choice == "2")
                {
                    string id, name, genre, final;
                    StreamWriter sw = new StreamWriter(file, true);
                    Console.WriteLine("Enter movie id: ");
                    id = Console.ReadLine();
                    Console.WriteLine("Enter movie name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter movie genre: ");
                    genre = Console.ReadLine();
                    final = id + "," + name + "," + genre;
                    sw.WriteLine(final);
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");

        }
    }
}
