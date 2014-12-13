using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
  public class Group_Permission
    {
      public int Id_Group { get; set; }
      public int Id_Permission { get; set; }
      public int Id { get; set; }
      public string ValuePermission { get; set; }
    }
}
