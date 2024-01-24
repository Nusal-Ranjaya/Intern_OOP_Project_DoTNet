using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Services;
using Intern_OOP_Project_DoTNet.Interfaces;
using System.IO;
using System.Collections;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class BulkEmailSender : IBulkMessage
    {
        private DatabaseServices DbServices;
        private MessageServices MServices;

        public BulkEmailSender(DatabaseServices DbS, MessageServices MS)
        {
            DbServices = DbS;
            MServices = MS;
        }
         
        public void SendMessagesAllCustomers(string message, string subject)
        {
            DbServices.GetAllData("customers");
        }

        public void StartNotification(string tableName)
        {
            List<List<object>> ProsList = DbServices.ReadData(tableName);

            foreach (List<object> row in ProsList)
            {
                if (row.Count > 1 && row[1] is DateTime column1Date && column1Date.Date == DateTime.Now.Date &&
                    row.Count > 4 && row[4] is bool column4Boolean && column4Boolean)
                {
                    string message = $"{row[2]} : {row[5]}";
                    DbServices.UpdateStatus(tableName,(int)row[0], false);
                    MServices.SendReminders(message);
                }
            }
        }
    }
}
