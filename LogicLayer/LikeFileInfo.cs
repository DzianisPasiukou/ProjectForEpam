using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
   public class LikeFileInfo : IDataBaseManager<LikeFile>
    {
        public IEnumerable<LikeFile> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LikeFile> GetBy(string nameParametr, string parametr)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.LikeFiles.GetBy(String.Format("{0} = {1}", nameParametr, parametr));
            }
        }

        public bool Add(LikeFile t)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.LikeFiles.Add(t);
            }
        }

        public bool Update(LikeFile t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LikeFile t)
        {
            throw new NotImplementedException();
        }
    }
}
