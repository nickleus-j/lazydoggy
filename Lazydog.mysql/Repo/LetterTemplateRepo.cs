using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Lazydog.Model;
using MySql.Data.MySqlClient;
using Lazydog.Model.Service;

namespace Lazydog.mysql.Repo
{
    public class LetterTemplateRepo
    {
        private DbConnection connection;
        public ILogger Logger;

        private string script_getActiveTemplates = @"SELECT * FROM lettertemplate WHERE ACTIVE=1";
        private string script_getTempalteViaId = @"SELECT * FROM lettertemplate WHERE ACTIVE=1 AND templateid=@id";
        public LetterTemplateRepo(DbConnection _connection, ILogger givenLogger = null)
        {
            connection = _connection;
        }
        private LetterTemplate GetLetterTemplateFromDbReader(DbDataReader reader)
        {
            LetterTemplate templateEntry = new LetterTemplate();
            templateEntry.ID = int.Parse(reader["templateid"].ToString());
            templateEntry.Content = reader["Content"].ToString();
            templateEntry.Meta = reader["Meta"].ToString();
            templateEntry.Name = reader["Name"].ToString();
            templateEntry.Active = reader["Active"].ToString()=="1";
            return templateEntry;
        }
        public LetterTemplate GetLetterTemplate(int id)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand(script_getTempalteViaId, (MySqlConnection)connection);
                    cmd.Parameters.Add(new MySqlParameter("@id", id));
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        return GetLetterTemplateFromDbReader(reader);
                    }
                }
            }
            catch (DbException dbEX)
            {
                Log(LogLevel.Error, "LetterTemplateRepo.GetLetterTemplate() Got a DB Issue \n" + dbEX.Message);
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "LetterTemplateRepo.GetLetterTemplate() Got an Unknown Error details \n" + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Get a letter Template from DB
        /// </summary>
        /// <param name="id">ID in the Database</param>
        /// <returns></returns>
        public LetterTemplate GetLetterTemplateInHtmlForm(int id)
        {
            LetterTemplate template = GetLetterTemplate(id);
            ExcuseMsgTemplateService msgService = new ExcuseMsgTemplateService();
            template.Content = msgService.GenerateHtmlOfTemplate(template.Content, JsonValuesService.GetOptionsFromtemplateMeta(template.Meta));
            return template;
        }
        /// <summary>
        /// Get All Active Letter Templates in the database
        /// </summary>
        /// <returns></returns>
        public IList<LetterTemplate> GetLetterTemplates()
        {
            IList<LetterTemplate> templates = new List<LetterTemplate>();

            try
            {
                using (connection)
                {
                    connection.Open();
                    DbCommand cmd = new MySqlCommand(script_getActiveTemplates, (MySqlConnection)connection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            templates.Add(GetLetterTemplateFromDbReader(reader));
                        }
                    }
                    connection.Close();
                }
            }
            catch (DbException dbEX)
            {
                Log(LogLevel.Error, "LetterTemplateRepo.GetLetterTemplates() Got a DB Issue \n" + dbEX.Message);
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "LetterTemplateRepo.GetLetterTemplates() Got an Unknown Error details \n" + ex.Message);
            }
            return templates;
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
