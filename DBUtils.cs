using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gostinka
{
    internal class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "gostinka";
            string user = "root";
            string password = "2375425";

            return DBMySQLUtils.GetDBConnection(host, port, database, user, password);

        }
    }
}
