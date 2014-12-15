using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer
{
   public class UsersInfo : IDataBaseManager<User>
    {
        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetBy(string nameParametr, string parametr)
        {
            using (DBEntities entity = new DBEntities())
            {
                return entity.Users.GetBy(String.Format("{0} = {1}", nameParametr, parametr));
            }
        }

        public bool Add(User t)
        {
            throw new NotImplementedException();
        }

        public bool Update(User t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User t)
        {
            throw new NotImplementedException();
        }
    }
}
