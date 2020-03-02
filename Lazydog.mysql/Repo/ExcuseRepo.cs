using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.Model;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;

namespace Lazydog.mysql.Repo
{
    public class ExcuseRepo
    {
        #region
        private string script_GetExcuseWithLabel = @"SELECT * FROM excuse 
            WHERE trim(ExcuseLabels) LIKE CONCAT('%',@Lbl,'%')";
        private string script_GetExcuses = @"SELECT * FROM excuse ORDER BY ExcuseTitle";
        private string script_GetRandomExcuse = "SELECT * FROM excuse order by RAND() LIMIT 1";
        #endregion
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
                    DbCommand cmd = new MySqlCommand(script_GetRandomExcuse, (MySqlConnection)connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            randomExcuse = GetExcuseFromReader(reader);
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
        public IList<Excuse> GetExcuses()
        {
            IList<Excuse> Excuses = new List<Excuse>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand(script_GetExcuses, (MySqlConnection)connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Excuse givenExcuse = GetExcuseFromReader(reader);
                            Excuses.Add(givenExcuse);
                        }
                    }
                    connection.Close();
                }
            }
            catch (DbException dbEX)
            {
                Log(LogLevel.Error, "ExcuseRepo.GetExcuses() Got a DB Issue \n" + dbEX.Message);
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "ExcuseRepo.GetExcuses() Got an Unknown Error details \n" + ex.Message);
            }
            return Excuses;
        }
        public IList<Excuse> GetExcuses(string label)
        {
            IList<Excuse> Excuses = new List<Excuse>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand(script_GetExcuseWithLabel, (MySqlConnection)connection);
                    cmd.Parameters.Add(new MySqlParameter( "@Lbl", label));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Excuse givenExcuse = GetExcuseFromReader(reader);
                            Excuses.Add(givenExcuse);
                        }
                    }
                    connection.Close();
                }
            }
            catch (DbException dbEX)
            {
                Log(LogLevel.Error, "ExcuseRepo.GetExcuses() Got a DB Issue \n" + dbEX.Message);
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "ExcuseRepo.GetExcuses() Got an Unknown Error details \n" + ex.Message);
            }
            return Excuses;
        }
        private Excuse GetExcuseFromReader(DbDataReader reader)
        {
            Excuse givenExcuse = new Excuse();
            givenExcuse.ExcuseTitle = reader["ExcuseTitle"].ToString();
            givenExcuse.ExcuseDescription = reader["ExcuseDescription"].ToString();
            givenExcuse.Labels = reader["ExcuseLabels"].ToString();
            return givenExcuse;
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
