using System;
using System.Data.SqlClient;
using System.Reflection;

namespace DBLabOne
{
   static public class DataBaseManager
    {
       static public bool Execute(string comm, string _connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(comm, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

       static public void Properties(object obj, out string nameProp, out string valueProp)
        {
            PropertyInfo[] prop = obj.GetType().GetProperties();

            nameProp = "";
            for (int i = 0; i < prop.Length; i++)
            {
                nameProp += prop[i].Name;
                if (i != prop.Length - 1)
                {
                    nameProp += ", ";
                }
            }
            valueProp = "";
            for (int i = 0; i < prop.Length; i++)
            {
                valueProp += "'";
                valueProp += prop[i].GetValue(obj, null);
                valueProp += "'";
                if (i != prop.Length - 1)
                {
                    valueProp += ", ";
                }
            }
        }
       static public string Modification(string arg1, string arg2, string arg3)
        {
            arg1 = arg1.Trim(' ');
            arg2 = arg2.Trim(' ');
            string[] newArrName = arg1.Split(',');
            string[] newArrValue = arg2.Split(',');
            string str = "";
            for (int i = 0; i < newArrName.Length; i++)
            {
                str += String.Format("{0} = {1}", newArrName[i], newArrValue[i]);
                if (i != newArrName.Length - 1)
                {
                    str += String.Format(" {0} ", arg3);
                }
            }

            return str;
        }
       static public string View(string view)
        {
            char separator = Array.Find<char>(view.ToCharArray(), a => (a == '=') || (a == '>') || (a == '<'));
            string[] arr = view.Split('=', ' ', '\'', '\"', '>', '<');
            
            view = "";
            string[] args = Array.FindAll<string>(arr, a => !String.IsNullOrEmpty(a));
            view += args[0];
            view += separator;
            view += String.Format("'{0}'", args[1]);

            return view;
        }
       static public string FindProperty(object obj, string key)
       {
           string prop;
           try
           {
               prop = Array.Find<PropertyInfo>(obj.GetType().GetProperties(), p => p.Name.ToUpper() == key.ToUpper()).Name.ToUpper();
           }
           catch
           {
               return "";
           }
           return prop;
       }
    }
}
