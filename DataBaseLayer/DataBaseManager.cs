using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DataBaseLayer
{
   static public class DataBaseManager
    {
       /// <summary>
       /// Выполнение Sql команды.
       /// </summary>
       /// <param name="comm">Запрос</param>
       /// <param name="connection">Соединение</param>
       /// <returns></returns>
       static public bool Execute(string comm, SqlConnection connection, Dictionary<string, object> param)
       {
           SqlCommand command = new SqlCommand(comm, connection);
           CommandParametr(ref command, param);
           command.ExecuteNonQuery();
           command.Dispose();

           return true;
       }
       /// <summary>
       /// Занесение в nameProp, valueProp значение имён свойств и их значений с объекта.
       /// </summary>
       /// <param name="obj"></param>
       /// <param name="nameProp"></param>
       /// <param name="valueProp"></param>
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
           if (String.IsNullOrEmpty(key))
           {
               return;
           }

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
                   if (i != props.Length - 1)
                   {
                       if ((props[i+1].Name.ToLower() != key.ToLower()) || (i == props.Length - 3))
                       nameBuilder.Append(", ");
                   }
               }
               else
               {
                   indexId = i;
               }
               
           }
           
           arrValue[indexId] = arrValue[indexId].Remove(0);
           StringBuilder valueBuilder = new StringBuilder();

           for (int i = 0; i < props.Length; i++)
           {
               if (props[i].Name.ToLower() != key.ToLower())
               {
                   valueBuilder.Append(arrValue[i]);
                   if (i != props.Length - 1)
                   {
                       if ((props[i + 1].Name.ToLower() != key.ToLower()) || (i == props.Length - 3))
                           valueBuilder.Append(", ");
                   }
               }
           }

           nameProp = nameBuilder.ToString();
           valueProp = valueBuilder.ToString();
       }
       static public Dictionary<string, object> Parameters(ref string value, char splitter)
       {
           StringBuilder builder = new StringBuilder();
           Dictionary<string, object> dict = new Dictionary<string, object>();

           value = value.Trim();
           string[] split;
           split = value.Split(splitter);
         
           for (int i = 0; i < split.Length; i++)
           {
               builder.Append(String.Format("@Param_{0}", i));

               if (i != split.Length - 1)
               {
                   builder.Append(",");
               }
               split[i] = split[i].Trim('\'', ' ');
               dict.Add(String.Format("@Param_{0}", i), split[i]);
           }

           value = builder.ToString();
           return dict;
       }
        static public void CommandParametr(ref SqlCommand command, Dictionary<string,object> param)
       {
           foreach (var p in param.Keys)
           {
               command.Parameters.AddWithValue(p, param[p]);
           }
       }
     
    }
   
}
