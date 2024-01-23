using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class DisplayServices
    {
        private IDisplay DisplayObj;
        public DisplayServices(IDisplay displayObj)
        {
            DisplayObj = displayObj;
        }

        public DateTime ReadDate()
        {
            return DisplayObj.ReadDate();
        }

        public DateTime ReadTime()
        {
            return DisplayObj.ReadTime();
        }

        public int ReadInt(String message)
        {
            return DisplayObj.ReadInt(message);
        }

        public Boolean ReadBoolean(String message)
        {
            return DisplayObj.ReadBoolean(message);
        }

        public String ReadString(String message)
        {
            return DisplayObj.ReadString(message);
        }

        public int ChooseReminder()
        {
            return DisplayObj.ChooseReminder();
        }

        public int ChooseSubscriber()
        {
            return DisplayObj.ChooseSubscriber();
        }
    }
}
