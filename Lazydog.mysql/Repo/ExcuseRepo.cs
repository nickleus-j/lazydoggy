using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.mysql;
//using Lazydog.Model;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Lazydog.mysql.Repo
{
    public class ExcuseRepo
    {
        private DbConnection connection;
        public ExcuseRepo(DbConnection _connection)
        {
            connection = _connection;
        }
        public string GetRandomExcuse()
        {
            string randomExcuse=String.Empty;
            using (connection)
            {
                connection.Open();
                DbCommand cmd = new MySqlCommand("SELECT * FROM lazydog.excuse order by RAND() LIMIT 1", (MySqlConnection)connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        randomExcuse = reader["ExcuseTitle"].ToString();
                        
                    }
                }
            }
            return randomExcuse;
        }
    }
}
