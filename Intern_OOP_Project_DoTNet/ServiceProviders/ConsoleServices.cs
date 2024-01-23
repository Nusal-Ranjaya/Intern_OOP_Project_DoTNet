using Intern_OOP_Project_DoTNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class ConsoleServices : IDisplay
    {
        public int ChooseReminder()
        {
            int val = 0;
            int option = 0;
            Console.WriteLine(@"
                    Enter option type:
                    1 - personal
                    2 - official");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    val = 1;
                    break;
                case 2:
                    val = 2;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            return val;
        }

        public int ChooseSubscriber()
        {
            int val = 0;
            int option = 0;
            Console.WriteLine(@"
                    Enter option type:
                    1 - personal");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    val = 1;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            return val;
        }

        public bool ReadBoolean(string message)
        {
            Console.WriteLine(message);
            string BoolString = Console.ReadLine();
            return Boolean.Parse(BoolString);
        }

        public DateTime ReadDate()
        {
            Console.WriteLine("Enter date (YYYY-MM-DD): ");
            string DateString = Console.ReadLine();
            return DateTime.Parse( DateString );

        }

        public int ReadInt(string message)
        {
            Console.WriteLine(message);
            string IntString = Console.ReadLine();
            return int.Parse(IntString);
        }

        public string ReadString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
            
        }

        public DateTime ReadTime()
        {
            Console.WriteLine("Enter time (HH:MM): ");
            string TimeString = Console.ReadLine();
            return DateTime.Parse(TimeString);
        }

    }
}
