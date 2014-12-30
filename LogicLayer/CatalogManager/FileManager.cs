using DataBaseLayer;
using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.CatalogManager
{
    public class FileManager : IDataBaseManager<File>
    {
        public IEnumerable<File> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetBy(string nameParametr, string parametr)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Files.GetBy(String.Format("{0} = {1}", nameParametr, parametr));
            }
        }

        public bool Add(File t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Files.Add(t);
            }
        }

        public bool Update(File t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(File t)
        {
            throw new NotImplementedException();
        }
    }
}
