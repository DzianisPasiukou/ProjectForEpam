using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class User_Permission
    {
       public int Id_Permission { get; set; }
       public string Login { get; set; }
       public int Id { get; set; }
       public string ValuePermission { get; set; }
    }
}
