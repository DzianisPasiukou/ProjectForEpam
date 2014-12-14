using LogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
   public class LikeNoteInfo : IDataBaseManager<LikeNote>
    {
        public IEnumerable<LikeNote> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LikeNote> GetBy(string nameParametr, string parametr)
        {
            throw new NotImplementedException();
        }

        public bool Add(LikeNote t)
        {
            throw new NotImplementedException();
        }

        public bool Update(LikeNote t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(LikeNote t)
        {
            throw new NotImplementedException();
        }
    }
}
