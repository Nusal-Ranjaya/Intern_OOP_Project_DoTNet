using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;

namespace Intern_OOP_Project_DoTNet.Services
{
    internal class DatabaseServices
    {
        private IDataServices DataBaseObj;
        public DatabaseServices(IDataServices dataBase)
        {
            this.DataBaseObj = dataBase;
        }
        public void AddData(string tableName, int id, DateTime date, DateTime time, int priority, bool state, string text)
        {
            DataBaseObj.AddData(tableName, id, date, time, priority, state, text);
        }

        public void AddDataCustomer(int id, string name, bool subscribe, string text)
        {
            DataBaseObj.AddDataCustomer(id, name,subscribe,text);
        }

        public void DeleteDataById(string tableName, int id)
        {
            DataBaseObj.DeleteDataById(tableName,id);
        }

        public void GetAllData(string tableName)
        {
            DataBaseObj.GetAllData(tableName);
        }

        public int GetNumberOfEntries(string tableName)
        { 
            return DataBaseObj.GetNumberOfEntries(tableName); 
        }

        public void UpdateStatus(string tableName, int id, bool status)
        {
            DataBaseObj.UpdateStatus(tableName,id,status);
        }

        public List<List<object>> ReadData(string tableName)
        {
            return DataBaseObj.ReadData(tableName);
        }
    }
}
