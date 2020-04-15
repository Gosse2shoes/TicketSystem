using System;

namespace TicketingSystem
{
    class Program
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string file = "ticketSystem.csv";
            string enhancedfile = "Enhancements.csv";
            string taskfile = "Task.csv";
            logger.Info("Program started");
            TicketFile ticketFile = new TicketFile(file);
            EnhancementFile enhancement = new EnhancementFile(enhancedfile);
            TaskFile task = new TaskFile(taskfile);
            string choice = "";
            do
            {
                Console.WriteLine("1) Create a bug ticket file.");
                Console.WriteLine("a) Read bug Ticket data from file.");
                Console.WriteLine("2) Create a Enhanced Ticket file");
                Console.WriteLine("b) Read Enhanced Ticket data from file.");
                Console.WriteLine("3) Create a Task Ticket file");
                Console.WriteLine("c) Read task Ticket data from file.");
                Console.WriteLine("Enter to quit");
                choice = Console.ReadLine();
                logger.Info("User choice: {Choice}", choice);
                if (choice == "1")
                {
                    Ticket ticket = new Ticket();
                    for (int i = 0; i < 10; i++)
                    {

                        Console.WriteLine("Enter a ticket (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        logger.Info("User Response {Response}", resp);
                        if (resp != "Y") { break; }
                        Console.WriteLine("Enter the Ticket ID: ");
                        ticket.ticketID = Console.ReadLine();
                        Console.WriteLine("Please enter summary: ");
                        ticket.summary = Console.ReadLine();
                        Console.WriteLine("Please enter the status of ticket: ");
                        ticket.status = Console.ReadLine();
                        Console.WriteLine("Level of priority: ");
                        ticket.priority = Console.ReadLine();
                        Console.WriteLine("Please enter the submitter: ");
                        ticket.submit = Console.ReadLine();
                        Console.WriteLine("Who is assigned this ticket: ");
                        ticket.assign = Console.ReadLine();
                        string input;
                        do
                        {
                            Console.WriteLine("Who is watching (or done to quit): ");
                            input = Console.ReadLine();
                            if (input != "done" && input.Length > 0)
                            {
                                ticket.watchers.Add(input);
                            }
                        } while (input != "done");
                        if (ticket.watchers.Count == 0)
                        {
                            ticket.watchers.Add("(no watchers watching this ticket)");
                        }
                        ticketFile.AddTicket(ticket);
                    }
                }
                else if (choice == "a")
                {
                    foreach (Ticket t in ticketFile.Tickets)
                    {
                        Console.WriteLine(t.Display());
                    }
                }
                else if (choice == "2")
                {
                    EnhancementTicket enhancementTicket = new EnhancementTicket();
                    for (int i = 0; i < 10; i++)
                    {

                        Console.WriteLine("Enter a ticket (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        logger.Info("User Response {Response}", resp);
                        if (resp != "Y") { break; }
                        Console.WriteLine("Enter the Ticket ID: ");
                        enhancementTicket.ticketID = Console.ReadLine();
                        Console.WriteLine("Please enter summary: ");
                        enhancementTicket.summary = Console.ReadLine();
                        Console.WriteLine("Please enter the status of ticket: ");
                        enhancementTicket.status = Console.ReadLine();
                        Console.WriteLine("Level of priority: ");
                        enhancementTicket.priority = Console.ReadLine();
                        Console.WriteLine("Please enter the submitter: ");
                        enhancementTicket.submit = Console.ReadLine();
                        Console.WriteLine("Who is assigned this ticket: ");
                        enhancementTicket.assign = Console.ReadLine();
                        Console.WriteLine("What is software for this ticket: ");
                        enhancementTicket.software = Console.ReadLine();
                        Console.WriteLine("How much is this ticket: ");
                        enhancementTicket.cost = double.Parse(Console.ReadLine());
                        Console.WriteLine("What is the reason for this ticket: ");
                        enhancementTicket.reason = Console.ReadLine();
                        Console.WriteLine(  "What is the estimate of this ticket: ");
                        enhancementTicket.estimate = Console.ReadLine();
                        string input;
                        do
                        {
                            Console.WriteLine("Who is watching (or done to quit): ");
                            input = Console.ReadLine();
                            if (input != "done" && input.Length > 0)
                            {
                                enhancementTicket.watchers.Add(input);
                            }
                        } while (input != "done");
                        if (enhancementTicket.watchers.Count == 0)
                        {
                            enhancementTicket.watchers.Add("(no watchers watching this ticket)");
                        }
                        enhancement.AddTicket(enhancementTicket);
                    }
                }
                else if (choice == "b")
                {
                    foreach (EnhancementTicket e in enhancement.EnhancedTickets)
                    {
                        Console.WriteLine(e.Display());
                    }
                }
                else if (choice == "3")
                {
                    TaskTicket taskTicket = new TaskTicket();
                    for (int i = 0; i < 10; i++)
                    {

                        Console.WriteLine("Enter a ticket (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        logger.Info("User Response {Response}", resp);
                        if (resp != "Y") { break; }
                        Console.WriteLine("Enter the Ticket ID: ");
                        taskTicket.ticketID = Console.ReadLine();
                        Console.WriteLine("Please enter summary: ");
                        taskTicket.summary = Console.ReadLine();
                        Console.WriteLine("Please enter the status of ticket: ");
                        taskTicket.status = Console.ReadLine();
                        Console.WriteLine("Level of priority: ");
                        taskTicket.priority = Console.ReadLine();
                        Console.WriteLine("Please enter the submitter: ");
                        taskTicket.submit = Console.ReadLine();
                        Console.WriteLine("Who is assigned this ticket: ");
                        taskTicket.assign = Console.ReadLine();
                        Console.WriteLine("What is name of the project for this ticket: ");
                        taskTicket.projectName = Console.ReadLine();
                        Console.WriteLine("What is the due date of this task: ");
                        taskTicket.dueDate = Console.ReadLine();
                        string input;
                        do
                        {
                            Console.WriteLine("Who is watching (or done to quit): ");
                            input = Console.ReadLine();
                            if (input != "done" && input.Length > 0)
                            {
                                taskTicket.watchers.Add(input);
                            }
                        } while (input != "done");
                        if (taskTicket.watchers.Count == 0)
                        {
                            taskTicket.watchers.Add("(no watchers watching this ticket)");
                        }
                        task.AddTicket(taskTicket);
                    }
                }
                else if (choice == "c")
                {
                    foreach (TaskTicket t in task.TaskTickets)
                    {
                        Console.WriteLine(t.Display());
                    }
                }
            } while (choice == "1" || choice == "a" || choice == "2" || choice == "b" || choice == "3" || choice == "c");
            logger.Info("Program ended");
        }
    }
}
