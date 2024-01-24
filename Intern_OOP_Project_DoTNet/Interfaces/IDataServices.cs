using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intern_OOP_Project_DoTNet.Interfaces
{
    internal interface IDataServices
    {
        void GetAllData(String tableName);

        void DeleteDataById(String tableName, int id);

        void AddData(String tableName, int id, DateTime date, DateTime time, int priority, Boolean state, String text);

        void UpdateStatus(String tableName, int id, Boolean status);


        int GetNumberOfEntries(String tableName);

        void AddDataCustomer(int id, String name, Boolean subscribe, String text);

        List<List<object>> ReadData(string tableName);
    }
}
