using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.Interfaces
{
    internal interface IBulkMessage
    {
        void StartNotification(String tableName);
        void SendMessagesAllCustomers(String message, String subject);
    }
}
