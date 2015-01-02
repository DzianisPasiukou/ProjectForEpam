using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public class CharacteristicHelper
    {
        public IEnumerable<Characteristic> Characteristics { get; set; }
        public IEnumerable<Note_Characteristic> CharacteristicsOfNote { get; set; }
    }
}
