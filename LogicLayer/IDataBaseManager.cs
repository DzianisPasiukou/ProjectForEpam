using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Entities;

namespace LogicLayer
{
   public interface IDataBaseManager<TEntity>
       where TEntity: new()
    {
        IEnumerable<TEntity> Get();

        IEnumerable<TEntity> GetBy(string nameParametr, string parametr);
        bool Add(TEntity t);
        bool Update(TEntity t);
        bool Delete(TEntity t);
       

    }
}
