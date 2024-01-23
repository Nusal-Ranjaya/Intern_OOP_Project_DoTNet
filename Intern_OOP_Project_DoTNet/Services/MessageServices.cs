using Intern_OOP_Project_DoTNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class MessageServices
    {
        private IMessageServices MessageObj;

    public MessageServices(IMessageServices messageObj)
        {
            this.MessageObj = messageObj;
        }
        public void SendMessage(DisplayServices display)
        {
            MessageObj.SendMessage(display);
        }

        public void SendAutoMessage(String to, String subject, String message)
        {
            MessageObj.SendAutoMessage(to, subject, message);
        }
    }
}
