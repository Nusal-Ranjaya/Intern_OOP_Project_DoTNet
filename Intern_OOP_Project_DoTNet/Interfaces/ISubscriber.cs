using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.Interfaces
{
    internal interface ISubscriber
    {
        void AddSubscriber(DisplayServices display, DatabaseServices dbServices);

        void RemoveSubscriber(DisplayServices display, DatabaseServices dbServices);

        void UpdateSubscriber(DisplayServices display, DatabaseServices dbServices);

        void GetAllSubscriberData(DatabaseServices dbServices);
    }
}
