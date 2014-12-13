using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class Note_Characteristic
    {
       public int Id_Note { get; set; }
       public int Id_Characteristic { get; set; }
       public int Id { get; set; }
       public string Value { get; set; }
    }
}
