using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class ManageReminder
    {
        private IManageReminder MrObj;

    public ManageReminder(IManageReminder mrObj)
        {
            this.MrObj = mrObj;
        }

        public void AddReminder(DisplayServices display, DatabaseServices dbServices)
        {
            MrObj.AddReminder(display, dbServices);
        }

        public void ViewReminders(DatabaseServices dbServices)
        {
            MrObj.ViewReminders(dbServices);
        }

        public void EditReminder(DisplayServices display, DatabaseServices dbServices)
        {
            MrObj.EditReminder(display, dbServices);
        }

        public void DeleteReminder(DisplayServices display, DatabaseServices dbServices)
        {
            MrObj.DeleteReminder(display, dbServices);
        }
    }
}
