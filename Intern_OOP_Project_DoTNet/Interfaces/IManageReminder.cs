using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.Interfaces
{
    internal interface IManageReminder
    {
        void AddReminder(DisplayServices display, DatabaseServices dbServices);

        void ViewReminders(DatabaseServices dbServices);

        void EditReminder(DisplayServices display, DatabaseServices dbServices);

        void DeleteReminder(DisplayServices display, DatabaseServices dbServices);
    }
}
