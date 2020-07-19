using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.Model;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using Lazydog.Model.Repo;

namespace Lazydog.mysql.Repo
{
    public class CultureRepo : ICultureRepo
    {
        private DbConnection connection;
        public ILogger Logger;
        public CultureRepo(DbConnection _connection, ILogger givenLogger = null)
        {
            connection = _connection;
        }
        public IList<LocalizationCulture> GetSupportedCultures()
        {
            IList<LocalizationCulture> currentCultures = new List<LocalizationCulture>();
            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand("SELECT CultureCode,CultureName FROM culture WHERE ACTIVE=1", (MySqlConnection)connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LocalizationCulture culture = new LocalizationCulture();
                            culture.CultureCode = reader["CultureCode"].ToString();
                            culture.CultureName = reader["CultureName"].ToString();
                            currentCultures.Add(culture);
                        }
                    }
                    connection.Close();
                }
            }
            catch (DbException dbEX)
            {
                Log(LogLevel.Error, "CultureRepo.GetSupportedCultures() Got a DB Issue \n" + dbEX.Message);
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "CultureRepo.GetSupportedCultures() Got an Unknown Error details \n" + ex.Message);
            }
            return currentCultures;
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
