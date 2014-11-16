
using System.Collections.Generic;

namespace DBLabOne
{
  public  interface IDataReader
    {
        IEnumerable<object[]> GetData(string args);
        bool Add(object obj);
        bool Update(object obj, string key);
        bool Delete(object obj);
    }
}
