using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class CustomerServices : ISubscriber
    {
        public void AddSubscriber(DisplayServices display, DatabaseServices dbServices)
        {
            int pk = dbServices.GetNumberOfEntries("customers");
            dbServices.AddDataCustomer(pk + 1, display.ReadString("Customer name: "), display.ReadBoolean("Enter subscription(true/false): "), display.ReadString("Enter email:"));
        }

        public void GetAllSubscriberData(DatabaseServices dbServices)
        {
            dbServices.GetAllData("customers");
        }

        public void MailToAll(DisplayServices display, BulkMessageSender bulkMessage, MessageServices messageService)
        {
            bulkMessage.SendMessagesAllCustomers(display.ReadString("subject: "), display.ReadString("message:"), messageService); ;
        }

        public void RemoveSubscriber(DisplayServices display, DatabaseServices dbServices)
        {
            dbServices.DeleteDataById("customers", display.ReadInt("Enter id: "));
        }

        public void UpdateSubscriber(DisplayServices display, DatabaseServices dbServices)
        {
            dbServices.UpdateStatus("customers", display.ReadInt("id: "), display.ReadBoolean("subscription(true/false): "));
        }
    }
}
