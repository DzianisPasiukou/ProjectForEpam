using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseLayer
{

    public class DataBase : IDataReader
    {
       private SqlConnection _connection;
       private string _table;
       private string _key;
       private static object lobj = new object();
        public DataBase(SqlConnection connection)
        {
            _table = "User";
            _key = "ID";
            _connection = connection;
        }
      
        public bool Add(object obj)
        {
            
           string nameProp, valueProp;
           DataBaseManager.Properties(obj,out nameProp,out valueProp);
           DataBaseManager.ClearID(obj, ref nameProp, ref valueProp, _key);

           string comm = String.Format(@"INSERT INTO [{0}] ({1}) VALUES ({2})",_table,nameProp,valueProp);
           return DataBaseManager.Execute(comm,_connection);
        }
        public bool Update(object obj)
        {
            string nameProp, valueProp;
            DataBaseManager.Properties(obj, out nameProp, out valueProp);
            DataBaseManager.ClearID(obj, ref nameProp, ref valueProp, _key);
            string str = DataBaseManager.Modification(nameProp, valueProp, ",");
            

            string prop = DataBaseManager.FindProperty(obj, _key);

            if (!String.IsNullOrEmpty(prop))
            {
                string comm = String.Format("UPDATE [{0}] SET {1} WHERE {2} = '{3}'", _table, str, _key, prop);
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


           string comm = String.Format("DELETE FROM [{0}] WHERE {1}",_table,str);
           return DataBaseManager.Execute(comm, _connection);
       }
        public List<Dictionary<string,object>> GetData(string args)
        {
            string comm = (args == "*") ? String.Format("SELECT * FROM [{0}]", _table) : String.Format("SELECT * FROM [{0}] Where {1}", _table, DataBaseManager.View(args));
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

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

                            list.Add(dict);
                        }
                    }
                }
                return list;
            }

      public string KeyEntity
      {
          get
          {
              return _key;
          }
          set
          {
              _key = value;
          }
      }
      public string EntityName
      {
          get
          {
              return _table;
          }
          set
          {
              _table = value;
          }
      }
    }
}
