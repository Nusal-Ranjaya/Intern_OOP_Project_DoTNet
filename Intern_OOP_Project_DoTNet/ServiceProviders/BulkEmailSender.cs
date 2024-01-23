using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Services;
using Intern_OOP_Project_DoTNet.Interfaces;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class BulkEmailSender : IBulkMessage
    {
        public void SendMessagesAllCustomers(string message, string subject, MessageServices messageService)
        {
            Console.WriteLine("sent messages to all");
        }

        public void StartNotification(string tableName, DatabaseServices dbServices, MessageServices messageService)
        {
            Console.WriteLine("started notification");
         
        }
    }
}
