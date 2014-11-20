using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager.ThemeManager.RecordManager
{
   public class RecordManager : IDataBaseManager<Record>
    {
        public IEnumerable<Record> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Record;
            }
        }

        public bool Add(Record t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Record.Add(t);
            }
        }

        public bool Update(Record t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Record.Update(t);
                
            }
        }

        public bool Delete(Record t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Record.Delete(t);                 
            }
        }


        public IEnumerable<Record> GetBy(string id)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Record.Where(r => r.NameTheme == id);
            }
        }
    }
}
