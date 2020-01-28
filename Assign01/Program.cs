using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign01
{
    class Program
    {
        /// <summary>
        /// Assign 01 Tyler Gardella
        /// Reading and editing a file that displays information about a ticket.
        /// 
        /// Current problems:
        /// Attempting to create a ticket (2) after reading data from the file (1) crashes the program.
        /// </summary>
        /// <param name="args"></param>
       
        static void Main(string[] args)
        {

            string file = "Tickets.txt";
            string userChoice;
            do
            {
                // selection menu
                Console.WriteLine("1) Read data from ticket.");
                Console.WriteLine("2) Create ticket from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                userChoice = Console.ReadLine();

                if (userChoice == "1")
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
                            Console.WriteLine("{0,-8}|{1,-20}|{2,-8}|{3,-9}|{4,-16}|{5,-16}|{6,-20}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                    }
                    else
                    {
                        // error
                        Console.WriteLine("File does not exist");
                    }

                }
                else if (userChoice == "2")
                {
                    // create file from user data
                    StreamWriter sw = new StreamWriter(file);
                    Console.WriteLine("What is the ticket ID?");
                    string ticketID = Console.ReadLine();
                    Console.WriteLine("What is the ticket summary?");
                    string summary = Console.ReadLine();
                    Console.WriteLine("What is the ticket status?");
                    string status = Console.ReadLine();
                    Console.WriteLine("What is the ticket priority?");
                    string priority = Console.ReadLine();
                    Console.WriteLine("Who submitted the ticket?");
                    string submitter = Console.ReadLine();
                    Console.WriteLine("Who is the ticket assigned to?");
                    string assigned = Console.ReadLine();
                    Console.WriteLine("Who is watching the ticket?");
                    string watching = Console.ReadLine();
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, summary, status, priority, submitter, assigned, watching);
                    sw.Close();
                }
            } while (userChoice == "1" || userChoice == "2");
        }
    }
}
