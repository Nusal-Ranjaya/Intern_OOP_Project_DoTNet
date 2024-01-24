using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Configurations;
using Intern_OOP_Project_DoTNet.Interfaces;
using Intern_OOP_Project_DoTNet.Services;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class EmailServices : IMessageServices
    {
       
        void IMessageServices.SendMessage(DisplayServices display)
        {
            String to = display.ReadString("to: ");

            if (MailVerify(to))
            {
                Console.WriteLine("Check the given email address");
            }
            else
            {
                EmailConfig email1 = new EmailConfig(to, display.ReadString("subject: "), display.ReadString("message: "));
                email1.SendActualEmail();
            }
        }

        protected bool MailVerify(string addres) 
        {
            string RegexVal = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
            Regex Pattern = new Regex(RegexVal);
            Match MatchObj = Pattern.Match(addres);
            return !(MatchObj.Success);
        }

        void IMessageServices.SendReminders(string message)
        {
            EmailConfig email1 = new EmailConfig("damika7alwis@gmail.com","Remider","reminder->"+message);
            email1.SendActualEmail();
        }
    }
}
