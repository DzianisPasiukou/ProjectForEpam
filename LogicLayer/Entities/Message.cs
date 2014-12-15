using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class Message
    {
       public int Id_Message { get; set; }
       public int Id_Recipient { get; set; }
       public int Id_Sender { get; set; }
       public string Text { get; set; }
    }
}
