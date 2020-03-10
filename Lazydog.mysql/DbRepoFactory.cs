using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.mysql.Repo;
using Microsoft.Extensions.Logging;

namespace Lazydog.mysql
{
    /// <summary>
    /// Has method the generate objects that interact data with the Mysql DB
    /// </summary>
    public class DbRepoInstantiator
    {
        public string ConnectionString { get; set; }
        //public ILogger Logger;
        public DbRepoInstantiator(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// Create new repository from Mysql DB
        /// </summary>
        /// <param name="givenLogger">Optional Logger object</param>
        /// <returns></returns>
        public ExcuseRepo GetExcuseRepo(ILogger givenLogger = null)
        {
            DbContext dbContext = new DbContext(ConnectionString);
            return new ExcuseRepo(dbContext.GetConnection());
        }
        /// <summary>
        /// Create new GetCultureRepo repository from Mysql DB
        /// </summary>
        /// <param name="givenLogger"></param>
        /// <returns></returns>
        public CultureRepo GetCultureRepo(ILogger givenLogger = null)
        {
            DbContext dbContext = new DbContext(ConnectionString);
            return new CultureRepo(dbContext.GetConnection());
        }
        public LetterTemplateRepo GetLetterTemplateRepo(ILogger givenLogger = null)
        {
            DbContext dbContext = new DbContext(ConnectionString);
            return new LetterTemplateRepo(dbContext.GetConnection(), givenLogger);
        }
    }
}
