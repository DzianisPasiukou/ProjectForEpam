using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager
{
  public  class CatalogManager: IDataBaseManager<Catalog>, ITree
    {
        public IEnumerable<Catalog> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Catalog;
            }
        }

        public bool Add(Catalog cat)
        {
            using ( DBEntities entity = new DBEntities())
            {
                return entity.Catalog.Add(cat);
            }
        }

        public bool Update(Catalog cat)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Catalog.Update(cat);
            }
        }

        public bool Delete(Catalog cat)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Catalog.Delete(cat);
            }
        }


        public IEnumerable<Catalog> GetBy(string id)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Catalog.Where(c => c.Name == id);
            }
        }

      public TreeView GetTree()
        {
            using (DBEntities entity = new DBEntities())
            {
                return InitializeTree.InstanceTree(entity, false);
            }
        }
    }
}
