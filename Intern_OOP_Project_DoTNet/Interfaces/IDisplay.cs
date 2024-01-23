using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_OOP_Project_DoTNet.Interfaces
{
    internal interface IDisplay
    {
        DateTime ReadDate();
        DateTime ReadTime();
        int ReadInt(string message);
        bool ReadBoolean(string message);
        string ReadString(string message);
        int ChooseReminder();
        int ChooseSubscriber();
    }
}
