using Intern_OOP_Project_DoTNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class SubscriberServices 
    {
        private ISubscriber SubObj;

    public SubscriberServices(ISubscriber subObj)
        {
            SubObj = subObj;
        }

        public void AddSubscriber(DisplayServices display, DatabaseServices dbServices)
        {
            SubObj.AddSubscriber(display, dbServices);
        }

        public void RemoveSubscriber(DisplayServices display, DatabaseServices dbServices)
        {
            SubObj.RemoveSubscriber(display, dbServices);
        }


        public void UpdateSubscriber(DisplayServices display, DatabaseServices dbServices)
        {
            SubObj.UpdateSubscriber(display, dbServices);
        }

        public void GetAllSubscriberData(DatabaseServices dbServices)
        {
            SubObj.GetAllSubscriberData(dbServices);
        }
    }
}
