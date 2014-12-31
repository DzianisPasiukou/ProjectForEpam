using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer.CatalogManager
{
  public  class CatalogManager: IDataBaseManager<Category>, ITree
    {
        public IEnumerable<Category> Get()
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Categories;
            }
        }

        public bool Add(Category cat)
        {
            using ( DBEntities entity = new DBEntities())
            {
                return entity.Categories.Add(cat);
            }
        }

        public bool Update(Category cat)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Categories.Update(cat);
            }
        }

        public bool Delete(Category cat)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Categories.Delete(cat);
            }
        }


        public IEnumerable<Category> GetBy(string nameParametr, string param)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Categories.GetBy(String.Format("{0} = {1}", nameParametr, param));
            }
        }

      public List<TreeView> GetTree()
        {
            using (DBEntities entity = new DBEntities())
            {
                return InitializeTree.InstanceTree(entity, false);
            }
        }
    }
}
