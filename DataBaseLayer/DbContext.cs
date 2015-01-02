using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLayer;
using System.Data.SqlClient;
using System.Configuration;

namespace DataBaseLayer
{
    public abstract class DbContext : IDisposable
    {
       private SqlConnection _connection;

        public DbContext(string nameConnectionString)
        {
            _connection = new SqlConnection(GetConnectionstring(nameConnectionString));
            _connection.Open();
        }
        public void Dispose()
        {
            _connection.Close();
        }
        private static string GetConnectionstring(string nameConnectionString)
        {
            string str = ConfigurationManager.ConnectionStrings[nameConnectionString].ConnectionString;
            return str;
        }
        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }
}
