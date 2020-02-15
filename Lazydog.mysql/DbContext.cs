using MySql.Data.MySqlClient;
using System;
using System.Data.Common;

namespace Lazydog.mysql
{
    public class DbContext
    {
        public string ConnectionString { get; set; }

        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// Creates an new Connection to a Mysql Database
        /// </summary>
        /// <returns>MySqlConnection</returns>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
