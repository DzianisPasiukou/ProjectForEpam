﻿
using System.Collections.Generic;

namespace DataBaseLayer
{
  public  interface IDataReader
    {
        IEnumerable<object[]> GetData(string args);
        bool Add(object obj);
        bool Update(object obj);
        bool Delete(object obj);
    }
}
