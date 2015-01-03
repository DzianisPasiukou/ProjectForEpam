using System;
using System.Collections.Generic;

namespace DataBaseLayer
{
    public interface IDataReader
    {
        List<Dictionary<string, object>> GetData(string args);
        bool Add(object obj);
        bool Update(object obj);
        bool Delete(object obj);
        string KeyEntity { get; set; }
        string EntityName { get; set; }
        bool IsAutoinc { get; set; }
    }
}
