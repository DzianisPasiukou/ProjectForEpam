using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Entities
{
   public class File
    {
       public int Id_File { get; set; }
       public string Type { get; set; }
       public string Path { get; set; }
       public string Login { get; set; }
       public string Status { get; set; }
       public string Size { get; set; }
       public int Id_Note { get; set; }
       public string Description { get; set; }
    }
}
