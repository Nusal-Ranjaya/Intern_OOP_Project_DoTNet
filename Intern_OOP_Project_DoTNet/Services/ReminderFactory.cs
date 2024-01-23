using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Intern_OOP_Project_DoTNet.Services
{
    internal class ReminderFactory
    {
        IManageReminder mR_OfficialObj = new ManageReminderOfficialServices();
        IManageReminder mR_PersonalObj = new ManageReminderPersonalServices();


        private IDisplay console;
        private DisplayServices display;

        public ReminderFactory()
        {
            console = new ConsoleServices();
            display = new DisplayServices(console);
        }



        public ManageReminder GetReminderObj()
        {
            int option = display.ChooseReminder();
            switch (option)
            {
                case 1:
                    return new ManageReminder(mR_PersonalObj);
                case 2:
                    return new ManageReminder(mR_OfficialObj);
                default:
                    Console.WriteLine("Invalid option");
                    return null;
            }
        }
    }
}
