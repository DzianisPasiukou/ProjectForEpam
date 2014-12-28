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
            return @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\EPAMPROJECT.mdf;Initial Catalog=ProjectEpam;Integrated Security=True";
        }
    }
}
