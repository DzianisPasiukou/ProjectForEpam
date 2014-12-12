using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLayer;

namespace DataBaseLayer
{
    public class DbContext : IDisposable
    {
        public DbContext()
        {
            DataBase.ConnectionOpen();
        }
        public void Dispose()
        {
            DataBase.ConnectionClose();
        }
    }
}
