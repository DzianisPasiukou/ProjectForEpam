using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public class NoteInfoHelper
    {
       public IEnumerable<File> Files { get; set; }
       public IEnumerable<Characteristic> Characteristics { get; set; }
       public IEnumerable<Note_Characteristic> CharacteristicsOfNote { get; set; }
    }
}
