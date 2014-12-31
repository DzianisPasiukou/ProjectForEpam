using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DataBaseLayer
{
   static public class DataBaseManager
    {
       static public bool Execute(string comm, SqlConnection connection)
        {
            try
            {
                    using (SqlCommand command = new SqlCommand(comm, connection))
                    {
                        command.ExecuteNonQuery();
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

            StringBuilder namePropBuilder = new StringBuilder();

            for (int i = 0; i < prop.Length; i++)
            {
                namePropBuilder.Append(prop[i].Name);
                if (i != prop.Length - 1)
                {
                    namePropBuilder.Append(", ");
                }
            }
            nameProp = namePropBuilder.ToString();

            StringBuilder valuePropBuilder = new StringBuilder();
            for (int i = 0; i < prop.Length; i++)
            {
                valuePropBuilder.Append("'");
                valuePropBuilder.Append(prop[i].GetValue(obj, null));
                valuePropBuilder.Append("'");
                if (i != prop.Length - 1)
                {
                   valuePropBuilder.Append(", ");
                }
            }
            valueProp = valuePropBuilder.ToString();
        }
       static public string Modification(string arg1, string arg2, string arg3)
        {
            arg1 = arg1.Trim(' ');
            arg2 = arg2.Trim(' ');
            string[] newArrName = arg1.Split(',');
            string[] newArrValue = arg2.Split(',');

            StringBuilder str = new StringBuilder();
           
            for (int i = 0; i < newArrName.Length; i++)
            {
                str.Append(String.Format("{0} = {1}", newArrName[i], newArrValue[i]));
                if (i != newArrName.Length - 1)
                {
                    str.Append(String.Format(" {0} ", arg3));
                }
            }

            return str.ToString();
        }
       static public string View(string view)
        {
            char separator = Array.Find<char>(view.ToCharArray(), a => (a == '=') || (a == '>') || (a == '<'));
            string[] arr = view.Split('=', ' ', '\'', '\"', '>', '<');

            StringBuilder viewBuilder = new StringBuilder();
            string[] args = Array.FindAll<string>(arr, a => !String.IsNullOrEmpty(a));
            viewBuilder.Append(args[0]);
            viewBuilder.Append(separator);
            viewBuilder.Append(String.Format("'{0}'", args[1]));

            return viewBuilder.ToString();
        }
       static public string FindProperty(object obj, string key)
       {
           string prop;
           try
           {
               prop = Array.Find<PropertyInfo>(obj.GetType().GetProperties(), p => p.Name.ToUpper() == key.ToUpper()).GetValue(obj).ToString();
           }
           catch
           {
               return "";
           }
           return prop;
       }
       static public void ClearID(object obj, ref string nameProp, ref string valueProp, string key)
       {
           PropertyInfo[] props = obj.GetType().GetProperties();
           string[] arrName = nameProp.Split(',');
           string[] arrValue = valueProp.Split(',');
           int indexId = 0;

           StringBuilder nameBuilder = new StringBuilder();
           
           for (int i = 0; i < props.Length; i++)
           {
               if (props[i].Name.ToLower() != key.ToLower())
               {
                   nameBuilder.Append(arrName[i]);
               }
               else
               {
                   indexId = i;
               }
               if ((i != props.Length - 1) && (props[i].Name.ToLower() != key.ToLower()))
               {
                   nameBuilder.Append(", ");
               }
           }
           
           arrValue[indexId] = arrValue[indexId].Remove(0);
           StringBuilder valueBuilder = new StringBuilder();

           for (int i = 0; i < props.Length; i++)
           {
                valueBuilder.Append(arrValue[i]);
                if ((i != props.Length - 1) && (props[i].Name.ToLower() != key.ToLower()))
                {
                    valueBuilder.Append(", ");
                }
           }

           nameProp = nameBuilder.ToString();
           valueProp = valueBuilder.ToString();
       }
    }
}
