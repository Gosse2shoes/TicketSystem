using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicketingSystem
{
    class TicketFile
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }

        public TicketFile(string path)
        {
            Tickets = new List<Ticket>();
            filePath = path;

            try
            {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    string line = sr.ReadLine();

                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] ticketDetails = line.Split(',');
                        ticket.ticketID = (ticketDetails[0]);
                        ticket.summary = ticketDetails[1];
                        ticket.status = ticketDetails[2];
                        ticket.priority = ticketDetails[3];
                        ticket.submit = ticketDetails[4];
                        ticket.assign = ticketDetails[5];
                        ticket.watchers = ticketDetails[6].Split('|').ToList();
                    }
                    else
                    {
                        ticket.ticketID = (line.Substring(0, idx - 1));
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf('"');
                        ticket.summary = line.Substring(0, idx);
                        line = line.Substring(idx + 2);
                        ticket.status = line.Substring(0, idx);
                        line = line.Substring(idx + 3);
                        ticket.priority = line.Substring(0, idx);
                        line = line.Substring(idx + 4);
                        ticket.submit = line.Substring(0, idx);
                        line = line.Substring(idx + 5);
                        ticket.assign = line.Substring(0, idx);
                        line = line.Substring(idx + 6);
                        ticket.watchers = line.Split('|').ToList();
                    }
                    Tickets.Add(ticket);
                }
                sr.Close();
                logger.Info("Movies in file {Count}", Tickets.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
        public void AddTicket(Ticket ticket)
        {
            try
            {
                ticket.ticketID = Tickets.Max(m => m.ticketID) + 1;
                string summary = ticket.summary;
                string status = ticket.status;
                string priority = ticket.priority;
                string submit = ticket.submit;
                string assgin = ticket.assign;
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketID},{summary},{status},{priority},{submit},{assgin},{string.Join("|", ticket.watchers)}");
                sw.Close();
                Tickets.Add(ticket);
                logger.Info("Ticket id {Id} added", ticket.ticketID);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
