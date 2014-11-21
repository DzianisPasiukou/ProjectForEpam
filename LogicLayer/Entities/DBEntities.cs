using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer;
using LogicLayer.Entities;

namespace LogicLayer.Entities
{
  public class DBEntities : DbContext
    {
      public DBSet<User> User { get; set; }
      public DBSet<Role> Role { get; set; }

      public DBSet<Catalog> Catalog { get; set; }

      public DBSet<Theme> Theme { get; set; }
      public DBSet<Record> Record { get; set; }
      public DBEntities():base()
      {
          User = new DBSet<User>();
          Role = new DBSet<Role>();
          Catalog = new DBSet<Catalog>();
          Theme = new DBSet<Theme>();
          Record = new DBSet<Record>();
      }
    }
}
