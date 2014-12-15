using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class Category
   {
       public int Id_Category { get; set; }
       public string Name { get; set; }
       public string Description { get; set; }
       public Nullable<int> Id_TopCategory { get; set; }
    }
}
