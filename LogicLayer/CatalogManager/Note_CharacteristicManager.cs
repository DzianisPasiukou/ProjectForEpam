using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public class Note_CharacteristicManager : IDataBaseManager<Note_Characteristic>
    {
        public IEnumerable<Note_Characteristic> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Note_Characteristics.GetAll();
            }
        }

        public IEnumerable<Note_Characteristic> GetBy(string nameParametr, string parametr)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Note_Characteristics.GetBy(String.Format("{0} = {1}", nameParametr, parametr));
            }
        }

        public bool Add(Note_Characteristic t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Note_Characteristics.Add(t);
            }
        }

        public bool Update(Note_Characteristic t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Note_Characteristics.Update(t);

            }
        }

        public bool Delete(Note_Characteristic t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Note_Characteristics.Delete(t);
            }
        }
    }
}
