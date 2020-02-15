using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.mysql;
using Lazydog.Model;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;

namespace Lazydog.mysql.Repo
{
    public class ExcuseRepo
    {
        private DbConnection connection;
        public ILogger Logger;
        public ExcuseRepo(DbConnection _connection, ILogger givenLogger=null)
        {
            connection = _connection;
        }
        public string GetRandomExcuse()
        {
            string randomExcuse=String.Empty;
            using (connection)
            {
                connection.Open();
                DbCommand cmd = new MySqlCommand("SELECT * FROM excuse order by RAND() LIMIT 1", (MySqlConnection)connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        randomExcuse = reader["ExcuseTitle"].ToString();
                        
                    }
                }
                connection.Close();
            }
            return randomExcuse;
        }
        public Excuse GetAnExcuse()
        {
            Excuse randomExcuse =new Excuse();
            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand("SELECT * FROM excuse order by RAND() LIMIT 1", (MySqlConnection)connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            randomExcuse.ExcuseTitle = reader["ExcuseTitle"].ToString();
                            randomExcuse.ExcuseDescription = reader["ExcuseDescription"].ToString();
                        }
                    }
                    connection.Close();
                }
            }
            catch(DbException dbEX)
            {
                Log(LogLevel.Error, "ExcuseRepo.GetAnExcuse() Got a DB Issue \n"+dbEX.Message);
            }
            catch(Exception ex)
            {
                Log(LogLevel.Error, "ExcuseRepo.GetAnExcuse() Got an Unknown Error details \n" + ex.Message);
            }
            return randomExcuse;
        }
        public void Log(LogLevel givenLogLevel,string msg)
        {
            if (Logger != null)
            {
                Logger.Log(givenLogLevel, msg);
            }
        }
    }
}
