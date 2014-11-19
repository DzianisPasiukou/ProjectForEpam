using System;
using System.Collections.Generic;

namespace DataBaseLayer
{
  public  interface IDataReader
    {
      IEnumerable<Dictionary<string, object>> GetData(string args);
        bool Add(object obj);
        bool Update(object obj);
        bool Delete(object obj);
    }
}
