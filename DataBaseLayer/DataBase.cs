using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseLayer
{

    public class DataBase :IDataReader
    {
        string _connectionString;
        string _table;
        string _key;
        public DataBase(string connectionString, string table, string key)
        {
            _connectionString = connectionString;
            _table = table;
            _key = key;
        } 
        public DataBase():this(GetConnectionstring(), "Users", "ID")
        {
        }
        public DataBase(string table)
            : this(GetConnectionstring(), table, "ID")
        {

        }

       static string GetConnectionstring()
       {
         //  string str = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
           return @"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Users;Integrated Security=True";
       }
        
        public bool Add(object obj)
        {
           string nameProp, valueProp;
           DataBaseManager.Properties(obj,out nameProp,out valueProp);

           string comm = String.Format(@"INSERT INTO {0} ({1}) VALUES ({2})",_table,nameProp,valueProp);
           return DataBaseManager.Execute(comm, _connectionString);
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
                return DataBaseManager.Execute(comm, _connectionString);
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
           return DataBaseManager.Execute(comm, _connectionString);
       }
        public IEnumerable<object[]> GetData(string args)
        {
            string comm = (args == "*") ? String.Format("SELECT * FROM {0}", _table) : String.Format("SELECT * FROM {0} Where {1}", _table, DataBaseManager.View(args));

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(comm, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        for (int i = 0; reader.Read(); i++)
                        {
                            object[] objs = new object[reader.FieldCount];
                            reader.GetValues(objs);

                            yield return objs;
                        }
                    }
                }
            }
           
        }

    }
}
