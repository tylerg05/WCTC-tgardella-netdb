using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Ticket : Base
    {

        public string severity { get; set; }

        public List<Base> Tickets = new List<Base>();

        public string Menu()
        {
            string userChoice;
            Console.WriteLine("1) Read data from ticket.");
            Console.WriteLine("2) Create ticket from data.");
            Console.WriteLine("3) Search by status.");
            Console.WriteLine("4) Search by priority.");
            Console.WriteLine("5) Search by submitter.");
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
            else if (userChoice == "3")
            {
                searchStatus();
            }
            else if (userChoice == "4")
            {
                searchPriority();
            }
            else if (userChoice == "5")
            {
                searchSubmitter();
            }
            else
            {
                close();
            }
        }

        public void readTicketData()
        {
            string file = "Tickets.csv";
            StreamReader sr = new StreamReader(file);
            outputHeader();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                string[] arr = line.Split(',');
                Console.WriteLine(arr[0] + "    " + arr[1] + "       " + arr[2] + "        " + arr[3] + "     " + arr[4] + "        " + arr[5] + "       " + arr[6]);
            }
        }

        public void outputHeader()
        {
            Console.WriteLine("ID  | Summary        | Status  | Priority | Submitter      | Assigned     | Watching");
       
        }

        public void createTicket()
        {
            string file = "Tickets.csv";
            StreamWriter sw = new StreamWriter(file);
            Console.WriteLine("What is the ticket ID?");
            string ID = Console.ReadLine();
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
            Base ticket = new Ticket(ID, summary, status, priority, submitter, assigned, watching);
            Tickets.Add(ticket);
            var addToFile = ticket.baseToFile(ID, summary, status, priority, submitter, assigned, watching);
            sw.WriteLine(addToFile);
            sw.Close();
        }

        public void searchStatus()
        {
            Console.WriteLine("Enter status to search by: ");
            var userChoice = Console.ReadLine();
            var results = Tickets.Where(m => m.status.Contains(userChoice));
            Console.WriteLine(results);
        }

        public void searchPriority()
        {
            Console.WriteLine("Enter priority to search by: ");
            var userChoice = Console.ReadLine();
            var results = Tickets.Where(m => m.priority.Contains(userChoice));
            Console.WriteLine(results);
        }

        public void searchSubmitter()
        {
            Console.WriteLine("Enter submitter to search by: ");
            var userChoice = Console.ReadLine();
            var results = Tickets.Where(m => m.submitter.Contains(userChoice));
            Console.WriteLine(results);
        }

        public void close()
        {
            Console.WriteLine("Thanks for using the ticket manager.");
        }

        public Ticket(string ID, string summary, string status, string priority, string submitter, string assigned, string watching)
        {
            base.ticketID = ID;
            base.summary = summary;
            base.status = status;
            base.priority = priority;
            base.submitter = submitter;
            base.assigned = assigned;
            base.watching = watching;
        }

        public Ticket()
        {

        }
    }
}
