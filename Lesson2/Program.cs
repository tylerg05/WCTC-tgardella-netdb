using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bogusArray = new string[]
            {
                "tyler",
                "roberta",
                "lizzie"
            };

            Console.WriteLine($"The second name is: {bogusArray[1]}");
            Console.WriteLine("The second name is " + bogusArray[1]);

            for (int i = 0; i < bogusArray.Length; i++)
            {
                Console.WriteLine($"The second name is: {bogusArray[i]}");
            }

            string myString1 = "";
            var myString2;
            
            foreach (string name in bogusArray)
            {
                Console.WriteLine($"The second name is: {name}");
            }
        }
    }
}
