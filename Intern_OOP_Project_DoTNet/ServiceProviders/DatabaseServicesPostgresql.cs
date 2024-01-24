using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intern_OOP_Project_DoTNet.Interfaces;
using Npgsql;

namespace Intern_OOP_Project_DoTNet.ServiceProviders
{
    internal class DatabaseServicesPostgresql : IDataServices
    {
        
        string ConnectionString = "Host=127.0.0.1;Port=5432;Database=intern_OOP;Username=postgres;Password=root;";
        static string Result;
        static int EntryNum;
        void IDataServices.AddData(string tableName, int id, DateTime date, DateTime time, int priority, bool state, string text)
        {
                string sql = $"INSERT INTO {tableName} (id, date, time, priority, state, text) VALUES (@id, @date, @time, @priority, @state, @text)";

                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@time", time);
                        command.Parameters.AddWithValue("@priority", priority);
                        command.Parameters.AddWithValue("@state", state);
                        command.Parameters.AddWithValue("@text", text);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Successfully inserted data.");
                        }
                        else
                        {
                            Console.WriteLine("Error inserting data.");
                        }
                    }
                }
            }


            void IDataServices.AddDataCustomer(int id, string name, bool subscribe, string text)
        {
            string Sql = "INSERT INTO customers (id, name, state, email) VALUES (@id, @name, @state, @text)";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(Sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@state", subscribe);
                    command.Parameters.AddWithValue("@text", text);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Successfully inserted data.");
                    }
                    else
                    {
                        Console.WriteLine("Error inserting data.");
                    }
                }
            }
        }

        void IDataServices.DeleteDataById(string tableName, int id)
        {
            string Sql = $"DELETE FROM {tableName} WHERE id = @id";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open ();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                using (NpgsqlCommand command = new NpgsqlCommand(Sql,connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Successfully deleted data.");

                        // Corrected UpdateSql statement
                        string updateSql = $"UPDATE {tableName} SET id = id - 1 WHERE id > @id";
                        using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateSql, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@id", id);
                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    else
                    {
                        Console.WriteLine("Erro Deleting data.");
                    }
                }
            }
        }

        void IDataServices.GetAllData(string tableName)
        {
            string SQL = $"SELECT * FROM {tableName}";
            using (NpgsqlConnection Connection = new NpgsqlConnection(ConnectionString))
            {
                Connection.Open();

                using (NpgsqlCommand Command = new NpgsqlCommand(SQL,Connection))
                using (NpgsqlDataReader Reader = Command.ExecuteReader())
                {

                    
                    //Print rows
                    while (Reader.Read())
                    {
                        for (int i = 0; i < Reader.FieldCount; i++)
                        {
                            string ColumnValue = Reader[i].ToString();
                            if (Reader.GetFieldType(i) == typeof(DateTime) && Reader.GetDateTime(i).TimeOfDay == TimeSpan.Zero)
                            {
                                
                                ColumnValue = ""; // getting rid of 12:00:00 AM
                            }
                            Console.Write(Reader[i].ToString() + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }

        }

        int IDataServices.GetNumberOfEntries(string tableName)
        {
            int entryNum = 0;
            string sql = $"SELECT COUNT(*) AS total_entries FROM {tableName}";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        entryNum = reader.GetInt32(0); 
                    }
                }
            }

            return entryNum;
        }

        void IDataServices.UpdateStatus(string tableName, int id, bool status)
        {
            string sql = $"UPDATE {tableName} SET state = @status WHERE id = @id";

            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Successfully updated status.");
                    }
                    else
                    {
                        Console.WriteLine("Error updating status. No matching record found.");
                    }
                }
            }
        }

        public List<List<object>> ReadData(string tableName)
        {
            List<List<object>> ListOut = new List<List<object>>();
            string SQL = $"SELECT * FROM {tableName}";

            using (NpgsqlConnection Connection = new NpgsqlConnection(ConnectionString))
            {
                Connection.Open();

                using (NpgsqlCommand Command = new NpgsqlCommand(SQL, Connection))
                using (NpgsqlDataReader Reader = Command.ExecuteReader())
                {
             
                    while (Reader.Read())
                    {
                        List<object> tempList = new List<object>();

                        for (int i = 0; i < Reader.FieldCount; i++)
                        {
                            
                            if (Reader.IsDBNull(i))
                            {
                                tempList.Add(null); 
                            }
                            else
                            {
                                tempList.Add(Reader[i]);
                            }
                        }

                        ListOut.Add(tempList);
                    }
                }
            }

            return ListOut;
        }
    }
}
