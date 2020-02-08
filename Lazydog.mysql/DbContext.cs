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

        public DbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
