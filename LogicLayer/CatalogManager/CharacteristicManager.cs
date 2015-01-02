using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
   public class CharacteristicManager: IDataBaseManager<Characteristic>
    {
        public IEnumerable<Characteristic> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Characteristics.GetAll();
            }
        }

        public IEnumerable<Characteristic> GetBy(string nameParametr, string parametr)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Characteristics.GetBy(String.Format("{0} = {1}", nameParametr, parametr));
            }
        }

        public bool Add(Characteristic t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Characteristics.Add(t);
            }
        }

        public bool Update(Characteristic t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Characteristics.Update(t);

            }
        }

        public bool Delete(Characteristic t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Characteristics.Delete(t);
            }
        }
    }
}
