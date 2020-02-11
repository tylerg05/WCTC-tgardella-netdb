using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            Ticket ticket = new Ticket();
            string userChoice;
            do
            {
                userChoice = ticket.Menu();
                ticket.decision(userChoice);
            } while (userChoice == "1" || userChoice == "2");
        }
    }
}
