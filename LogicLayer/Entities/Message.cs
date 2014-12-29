using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class Message : IComparable
    {
       public int Id_Message { get; set; }
       public string Login_Recipient { get; set; }
       public string Login_Sender { get; set; }
       public string Text { get; set; }
       public string Date { get; set; }
       public bool IsRead { get; set; }

       public int CompareTo(object obj)
       {
           int result = 0;
           var a = (Message)obj;
           if (DateTime.Parse(a.Date) > DateTime.Parse(Date))
           {
               result = -1;
           }
           else if (DateTime.Parse(a.Date) < DateTime.Parse(Date))
           {
               result = 1;
           }
           return result;
       }
    }
}
