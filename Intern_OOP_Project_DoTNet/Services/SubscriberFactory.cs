using Intern_OOP_Project_DoTNet.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.ServiceProviders;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class SubscriberFactory
    {
        ISubscriber customer = new CustomerServices();
        private IDisplay console;
        private DisplayServices display;

        public SubscriberFactory()
        {
            console = new ConsoleServices();
            display = new DisplayServices(console);
        }



        public SubscriberServices GetSubscriberObj()
        {
            int option = display.ChooseSubscriber();
            SubscriberServices returnObj = null;
            switch (option)
            {
                case 1:
                    returnObj = new SubscriberServices(customer); ;
                    break;

            }
            return returnObj;
        }
    }
}
