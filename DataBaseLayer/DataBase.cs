using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseLayer
{

    public class DataBase :IDataReader
    {
        static SqlConnection _connection;
        string _table;
        string _key;
        public DataBase(string table, string key)
        {
            _table = table;
            _key = key;
        }
        public DataBase():this("Users", "ID")
        {
        }
        public DataBase(string table)
            : this(table, "ID")
        {

        }

       static string GetConnectionstring()
       {
         //  string str = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
           return @"Data Source=LENOVO\SQLEXPRESS2012;Initial Catalog=D:\С#\ASP_PROJECT\EPAMPROJECT\MVCAPP\APP_DATA\EPAMPROJECT.MDF;Integrated Security=True";
       }

       static public void ConnectionOpen()
       {
           if (_connection == null)
           {
               _connection = new SqlConnection(GetConnectionstring());
               _connection.Open();
           }
           else
           {
               _connection.Close();
               _connection = new SqlConnection(GetConnectionstring());
               _connection.Open();
           }
       }
       static public void ConnectionOpen(string connectionString)
        {
            if (_connection == null) 
            {
                if (_connection.ConnectionString != connectionString)
                    _connection.Close();
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
            else
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();
            }
        }
        public bool Add(object obj)
        {
            
           string nameProp, valueProp;
           DataBaseManager.Properties(obj,out nameProp,out valueProp);

           string comm = String.Format(@"INSERT INTO {0} ({1}) VALUES ({2})",_table,nameProp,valueProp);
           return DataBaseManager.Execute(comm,_connection);
        }
        public bool Update(object obj)
        {
            string nameProp, valueProp;
            DataBaseManager.Properties(obj, out nameProp, out valueProp);
            string str = DataBaseManager.Modification(nameProp, valueProp, ",");

            string prop = DataBaseManager.FindProperty(obj, _key);

            if (String.IsNullOrEmpty(prop))
            {
                string comm = String.Format("UPDATE {0} SET {1} WHERE {2} = {3}", _table, str, _key.ToUpper(), DataBaseManager.FindProperty(obj, _key));
                return DataBaseManager.Execute(comm, _connection);
            }
            else
            {
                return false;
            }
        }
       public bool Delete(object obj)
       {
           string nameProp, valueProp;
           DataBaseManager.Properties(obj, out nameProp, out valueProp);

           string str = DataBaseManager.Modification(nameProp, valueProp, "AND");


           string comm = String.Format("DELETE FROM {0} WHERE {1}",_table,str);
           return DataBaseManager.Execute(comm, _connection);
       }
        public IEnumerable<Dictionary<string,object>> GetData(string args)
        {
            string comm = (args == "*") ? String.Format("SELECT * FROM {0}", _table) : String.Format("SELECT * FROM {0} Where {1}", _table, DataBaseManager.View(args));

                using (SqlCommand command = new SqlCommand(comm,_connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        for (int i = 0; reader.Read(); i++)
                        {
                            Dictionary<string, object> dict = new Dictionary<string, object>();

                            for (int j = 0; j < reader.FieldCount; j++)
                            {
                                dict.Add(reader.GetName(j), reader.GetValue(j));
                            }

                            yield return dict;
                        }
                    }
                }
            }

      static public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
