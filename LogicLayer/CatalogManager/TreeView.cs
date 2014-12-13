using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public class TreeView
    {
       public int ID { get; set; }
       public string NodeName { get; set; }
       public int? IDNote { get; set; }
       public string NodeDescription { get; set; }
       public List<TreeView> ChildNode { get; set; }
    }
}
