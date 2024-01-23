using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class ManageReminderOfficialServices : IManageReminder
    {
        protected string tableName = "official";

        public void AddReminder(DisplayServices display, DatabaseServices dbServices)
        {
            int pk = dbServices.GetNumberOfEntries(tableName);
            dbServices.AddData(tableName, pk + 1, display.ReadDate(), display.ReadTime(), display.ReadInt("Enter priority level: "), display.ReadBoolean("Enter state: "), display.ReadString("Enter the text:"));
        }
        public void ViewReminders(DatabaseServices dbServices)
        {
            dbServices.GetAllData(tableName);
        }

        public void EditReminder(DisplayServices display, DatabaseServices dbServices)
        {
            dbServices.UpdateStatus(tableName, display.ReadInt("id: "), display.ReadBoolean("state(true/false): "));

        }

        public void DeleteReminder(DisplayServices display, DatabaseServices dbServices)
        {
            dbServices.DeleteDataById(tableName, display.ReadInt("Enter ID: "));
        }
    }
}
