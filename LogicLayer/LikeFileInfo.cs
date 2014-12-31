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
            throw new NotImplementedException();
        }

        public bool Add(LikeFile t)
        {
            throw new NotImplementedException();
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
