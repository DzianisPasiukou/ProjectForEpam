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
            return @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\EpamProject\MvcApp\App_Data\EpamProject.mdf;Integrated Security=True";
        }
    }
}
