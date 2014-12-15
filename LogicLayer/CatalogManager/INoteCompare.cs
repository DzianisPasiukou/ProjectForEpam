using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager.ThemeManager.RecordManager
{
   public interface INoteCompare
    {
       IEnumerable<Note> GetNote(string param1, string param2);
    }
}
