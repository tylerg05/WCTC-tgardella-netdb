using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Ticket
    {

        public string Menu()
        {
            string userChoice;
            Console.WriteLine("1) Read data from ticket.");
            Console.WriteLine("2) Create ticket from data.");
            Console.WriteLine("Enter any other key to exit.");

            userChoice = Console.ReadLine();
            return userChoice;
        }

        public void decision(string userChoice)
        {
            if (userChoice == "1")
            {
                readTicketData();
            }
            else if (userChoice == "2")
            {
                createTicket();
            }
            else
            {
                close();
            }
        }

        public void readTicketData()
        {
            string file = "Tickets.csv";
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
                    Console.WriteLine("{0,-10}|{1,-20}|{2,-10}|{3,-10}|{4,-20}|{5,-20}|{6,-30}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                }
                sr.Close();
            }
            else
            {
                // error
                Console.WriteLine("File does not exist");
            }
        }

        public void createTicket()
        {
            string file = "Tickets.csv";
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

        public void close()
        {
            Console.WriteLine("Thanks for using the ticket manager.");
        }
    }
}
