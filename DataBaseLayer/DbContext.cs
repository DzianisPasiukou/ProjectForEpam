using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseLayer;
using System.Data.SqlClient;

namespace DataBaseLayer
{
    public abstract class DbContext : IDisposable
    {
       public SqlConnection connection;

        public DbContext()
        {
            connection = new SqlConnection(GetConnectionstring());
            connection.Open();
        }
        public void Dispose()
        {
            connection.Close();
        }
        private static string GetConnectionstring()
        {
            //  string str = ConfigurationManager.ConnectionStrings["user"].ConnectionString;
            return @"Data Source=LENOVO\SQLEXPRESS2012;Initial Catalog=EPAMPROJECT;Integrated Security=True";
        }
    }
}
