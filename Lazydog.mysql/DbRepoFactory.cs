using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.mysql.Repo;

namespace Lazydog.mysql
{
    public class DbRepoFactory
    {
        public string ConnectionString { get; set; }

        public DbRepoFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public ExcuseRepo GetExcuseRepo()
        {
            DbContext dbContext = new DbContext(ConnectionString);
            return new ExcuseRepo(dbContext.GetConnection());
        }
    }
}
