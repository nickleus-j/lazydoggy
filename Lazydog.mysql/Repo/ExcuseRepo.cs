using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.Model;
using Lazydog.Model.Repo;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;

namespace Lazydog.mysql.Repo
{
    public class ExcuseRepo : IExcuseRepo
    {
        #region
        private string script_GetExcuseWithLabel = @"SELECT * FROM excuse 
            WHERE trim(ExcuseLabels) LIKE CONCAT('%',@Lbl,'%')";
        private string script_GetExcuses = @"SELECT * FROM excuse ORDER BY ExcuseTitle";
        private string script_GetRandomExcuse = "SELECT * FROM excuse order by RAND() LIMIT 1";
        private string script_GetExcusesTitles = @"SELECT ExcuseTitle FROM excuse ORDER BY ExcuseTitle";
        
        #endregion
        private DbConnection connection;
        public ILogger Logger;
        /// <summary>
        /// Make A DAO for excuses
        /// </summary>
        /// <param name="_connection">Connection string</param>
        /// <param name="givenLogger">Logger</param>
        public ExcuseRepo(DbConnection _connection, ILogger givenLogger=null)
        {
            connection = _connection;
        }
        /// <summary>
        /// Provide a random excuse
        /// </summary>
        /// <returns></returns>
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
        public List<string> GetExcuseTitles()
        {
            List<string> excuses = new List<string>();
            using (connection)
            {
                connection.Open();
                DbCommand cmd = new MySqlCommand(script_GetExcusesTitles, (MySqlConnection)connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        excuses.Add(reader["ExcuseTitle"].ToString());

                    }
                }
                connection.Close();
            }
            return excuses;
        }
        /// <summary>
        /// Get a random Excuse
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Gets a list of Excuses from a MySQL database
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Get Excuses based on Labels
        /// </summary>
        /// <param name="label">Labels or categories</param>
        /// <returns></returns>
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
        /// <summary>
        /// Assign values from Excuse DB to Excuse object
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
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
