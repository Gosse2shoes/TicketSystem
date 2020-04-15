using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem
{
    class TaskTicket
    {
        public string ticketID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submit { get; set; }
        public string assign { get; set; }
        public List<string> watchers { get; set; }
        public string projectName { get; set; }
        public string dueDate { get; set; }


        public TaskTicket()
        {
            watchers = new List<string>();
        }

        public string Display()
        {
            return $"Id: { ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submit}\nAssign To: {assign}\nWatchers: {string.Join(", ", watchers)}\nProject Name: {projectName}\n" +
                $"Due Date: {dueDate}\n";
        }
    }
}
