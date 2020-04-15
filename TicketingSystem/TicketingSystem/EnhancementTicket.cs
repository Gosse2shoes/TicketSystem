using System;
using System.Collections.Generic;
using System.Text;

namespace TicketingSystem
{
    class EnhancementTicket
    {
        public string ticketID { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submit { get; set; }
        public string assign { get; set; }
        public List<string> watchers { get; set; }
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set;}
        public string estimate { get; set; }


        public EnhancementTicket()
        {
            watchers = new List<string>();
        }

        public string Display()
        {
            return $"Id: { ticketID}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submit}\nAssign To: {assign}\nWatchers: {string.Join(", ", watchers)}\nSoftware: {software}\n" +
                $"Cost: {cost}\nReason: {reason}\nEstimate: {estimate}\n";
        }
    }
}

