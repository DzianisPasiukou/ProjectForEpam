using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer;
using LogicLayer.Models;

namespace LogicLayer.Entities
{
  public class DBEntities : DbContext
    {
      public DBSet<User> User { get; set; }
      public DBSet<Role> Role { get; set; }

      public DBEntities():base()
      {
          User = new DBSet<User>("Users", "ID");
          Role = new DBSet<Role>("Role", "ID");
      }
    }
}
