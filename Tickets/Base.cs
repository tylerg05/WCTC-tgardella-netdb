using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public abstract class Base
    {
        public string ticketID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public string watching { get; set; }

       
        public Base()
        {
        }

        public string baseToFile(string ID, string summary, string status, string priority, string submitter, string assigned, string watching)
        {
            return ID + "," + summary + "," + status + "," + priority + "," + submitter + "," + assigned + "," + watching;
        }

        public string Display() 
        { 
            return $"ID: {ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {watching}\n"; 
        }

    }
}
