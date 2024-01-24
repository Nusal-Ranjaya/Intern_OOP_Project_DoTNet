using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.ServiceProviders;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // All objects needed
            IDisplay console = new ConsoleServices(); // Console
            DisplayServices display = new DisplayServices(console);

            IDataServices dbServicesPost = new DatabaseServicesPostgresql(); // PostgreSQL
            DatabaseServices dbServices = new DatabaseServices(dbServicesPost);

            IMessageServices email = new EmailServices(); // Email
            MessageServices messageService = new MessageServices(email);

            IBulkMessage emailBulk = new BulkEmailSender(dbServices, messageService); // Email
            BulkMessageSender bulkMessage = new BulkMessageSender(emailBulk);

            // Reminder and Subscriber Factories
            ReminderFactory factoryR = new ReminderFactory();
            SubscriberFactory factoryS = new SubscriberFactory();

            do
            {
                // Send automatic email if there's a reminder to be sent
                bulkMessage.StartNotification("personal");
                bulkMessage.StartNotification("official");

                Console.WriteLine(@"
                    Enter option type:
                    1 - set a new reminder
                    2 - view all reminders
                    3 - edit a current reminder state
                    4 - delete a reminder
                    5 - Add new subscriber
                    6 - view all subscribers
                    7 - change subscriber subscription
                    8 - Remove subscriber from the table
                    9 - send an email");

                int option;
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }

                switch (option)
                {
                    case 1:
                        factoryR.GetReminderObj().AddReminder(display, dbServices);
                        break;
                    case 2:
                        factoryR.GetReminderObj().ViewReminders(dbServices);
                        break;
                    case 3:
                        factoryR.GetReminderObj().EditReminder(display, dbServices);
                        break;
                    case 4:
                        factoryR.GetReminderObj().DeleteReminder(display, dbServices);
                        break;
                    case 5:
                        factoryS.GetSubscriberObj().AddSubscriber(display, dbServices);
                        break;
                    case 6:
                        factoryS.GetSubscriberObj().GetAllSubscriberData(dbServices);
                        break;
                    case 7:
                        factoryS.GetSubscriberObj().UpdateSubscriber(display, dbServices);
                        break;
                    case 8:
                        factoryS.GetSubscriberObj().RemoveSubscriber(display, dbServices);
                        break;
                    case 9:
                        messageService.SendMessage(display);
                        break;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            } while (true);
        }
    }
}
