using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class EmailServices : IMessageServices
    {
        void IMessageServices.SendAutoMessage(string to, string subject, string message)
        {
            Console.WriteLine("Auto message sent");
        }

        void IMessageServices.SendMessage(DisplayServices display)
        {
            Console.WriteLine("email sent");
        }
    }
}
