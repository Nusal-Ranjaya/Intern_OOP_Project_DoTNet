using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class BulkMessageSender
    {
        private IBulkMessage BulkMessagesObj;

        public BulkMessageSender(IBulkMessage bulkMessages)
        {
            this.BulkMessagesObj = bulkMessages;
        }

        public void StartNotification(String tableName)
        {
            BulkMessagesObj.StartNotification(tableName);
        }
        public void SendMessagesAllCustomers(String message, String subject)
        {
            BulkMessagesObj.SendMessagesAllCustomers(message, subject);
           
        }
    }
}
