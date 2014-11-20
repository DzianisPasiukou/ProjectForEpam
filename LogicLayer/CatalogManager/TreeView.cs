using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public class TreeView
    {
       public string NameNode { get; set; }

       public List<TreeView> Tree { get; set; }
    }
}
