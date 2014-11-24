using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager.ThemeManager.RecordManager
{
   public class RecordManager : IDataBaseManager<Record>, IRecordCompare
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


        public IEnumerable<Record> GetBy(string nameParametr, string param)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Record.GetBy(String.Format("{0} = {1}", nameParametr,param));
            }
        }
        public IEnumerable<Record> GetRecords(string param1, string param2)
        {
            using (DBEntities entity = new DBEntities())
            {
                IEnumerable<Record> records = entity.Record;
                List<Record> current = new List<Record>()
            {
                records.First(rc=>rc.ID == int.Parse(param1)),
                records.First(rc=>rc.ID == int.Parse(param2)),
            };

                return current;
            }
        }
    }
}
