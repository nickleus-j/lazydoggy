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
    public class ExcuseAlterationRepo : IExcuseAlterationRepo
    {
        private string script_GetExcuseAlterations = @"SELECT * FROM lazydog.excusealteration
                WHERE excuseID IN (SELECT excuseID FROM excuse WHERE ExcuseTitle=@Title )";
        private DbConnection connection;
        public ILogger Logger;
        /// <summary>
        /// Make A DAO for excuses
        /// </summary>
        /// <param name="_connection">Connection string</param>
        /// <param name="givenLogger">Logger</param>
        public ExcuseAlterationRepo(DbConnection _connection, ILogger givenLogger = null)
        {
            connection = _connection;
        }
        public IList<ExcuseAlteration> GetExcuseAlteration(string title)
        {
            IList<ExcuseAlteration> alternateTitles = new List<ExcuseAlteration>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand(script_GetExcuseAlterations, (MySqlConnection)connection);
                    cmd.Parameters.Add(new MySqlParameter("@Title", title));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExcuseAlteration alternateTitle = new ExcuseAlteration();
                            alternateTitle.AlternateTitle= reader["AlteredTitle"].ToString();
                            alternateTitles.Add(alternateTitle);
                        }
                    }
                    connection.Close();
                }
            }
            catch (DbException dbEX)
            {
                Log(LogLevel.Error, "ExcuseAlterationRepo.GetExcuseAlteration() Got a DB Issue \n" + dbEX.Message);
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "ExcuseAlterationRepo.GetExcuseAlteration() Got an Unknown Error details \n" + ex.Message);
            }
            return alternateTitles;
        }

        public void Log(LogLevel givenLogLevel, string msg)
        {
            if (Logger != null)
            {
                Logger.Log(givenLogLevel, msg);
            }
        }
    }
}
