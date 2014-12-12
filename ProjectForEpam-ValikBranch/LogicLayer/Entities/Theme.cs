using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class Theme
   {
       public int ID { get; set; }
       public string Name { get; set; }

       public string CatalogID { get; set; }

       public string Description { get; set; }
    }
}
