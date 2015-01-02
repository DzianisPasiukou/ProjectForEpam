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
        public DataBase(SqlConnection connection)
        {
            _connection = connection;
        }
      
        public bool Add(object obj)
        {
            
           string nameProp, valueProp;
           DataBaseManager.Properties(obj,out nameProp,out valueProp);
           if (_key != "Login")
           {
               DataBaseManager.ClearID(obj, ref nameProp, ref valueProp, _key);
           }
           Dictionary<string, object> param = DataBaseManager.Parameters(ref valueProp, ',');

           string comm = String.Format(@"INSERT INTO [{0}] ({1}) VALUES ({2})",_table,nameProp,valueProp);

           return DataBaseManager.Execute(comm,_connection, param);
        }
        public bool Update(object obj)
        {
            string nameProp, valueProp;
            DataBaseManager.Properties(obj, out nameProp, out valueProp);
            DataBaseManager.ClearID(obj, ref nameProp, ref valueProp, _key);
            Dictionary<string, object> param = DataBaseManager.Parameters(ref valueProp, ',');

            string str = DataBaseManager.Modification(nameProp, valueProp, ",");


            string prop = DataBaseManager.FindProperty(obj, _key);


            string comm = String.Format("UPDATE [{0}] SET {1} WHERE {2} = '{3}'", _table, str, _key, prop);
            return DataBaseManager.Execute(comm, _connection, param);

        }
       public bool Delete(object obj)
       {
           string nameProp, valueProp;
           DataBaseManager.Properties(obj, out nameProp, out valueProp);

           Dictionary<string, object> param = DataBaseManager.Parameters(ref valueProp, ',');
           string str = DataBaseManager.Modification(nameProp, valueProp, "AND");
          

           string comm = String.Format("DELETE FROM [{0}] WHERE {1}",_table,str);
           return DataBaseManager.Execute(comm, _connection, param);
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
