using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Servicios.DataAccess
{
    public class DataBase
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["BDConnection"]
                    .ConnectionString;
            }
        }

        public static SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}