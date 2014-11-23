using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager.ThemeManager
{
   public class ThemeManager: IDataBaseManager<Theme>
    {
        public IEnumerable<Theme> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Theme;
            }
        }

        public IEnumerable<Theme> GetBy(string id)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Theme.Where(t => t.CatalogID == int.Parse(id));
            }
        }

        public bool Add(Theme t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Theme.Add(t);
            }
        }

        public bool Update(Theme t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Theme.Update(t);
            }
        }

        public bool Delete(Theme t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Theme.Delete(t);
            }
        }
    }
}
