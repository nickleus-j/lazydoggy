using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lazydog.mysql.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lazydog.Model;
using Lazydog.Model.Repo;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace Lazydog.mysql.Repo.Tests
{
    [TestClass()]
    public class ExcuseRepoTests
    {
        public DbContext webContext { get; set; }
        /*
         public void seed()
        {
             DbContextOptions<ArgYouWebContext> dbContextOptions = new DbContextOptionsBuilder<ArgYouWebContext>()
        .UseInMemoryDatabase(databaseName: "ARGYOUWEB")
        .Options;
            webContext = new ArgYouWebContext(dbContextOptions);
            List<Sheet> sheets = new List<Sheet>();
            sheets.Add(new Sheet { CreatedOn = DateTime.UtcNow, LastModifiedOn=DateTime.UtcNow, Description="Desc",InUse=true,IsPublic=true,SheetId=1,Title="Debate 1" });
            sheets.Add(new Sheet { CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow, Description = "Desc", InUse = true, IsPublic = true, SheetId = 2, Title = "Using Windows 11" });
            sheets.Add(new Sheet { CreatedOn = DateTime.UtcNow, LastModifiedOn = DateTime.UtcNow, Description = "Desc", InUse = true, IsPublic = false, SheetId = 3, Title = "Debate 3" });
            if (webContext.Sheet.Count() == 0)
            {
                webContext.Sheet.AddRange(sheets);
                webContext.SaveChanges();
            }
            
        }
        [TestInitialize]
        public void Initialize()
        {
            seed();
        }
         */
        [TestMethod()]
        public void ExcuseRepoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetRandomExcuseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetExcuseTitlesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAnExcuseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetExcusesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetExcusesTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LogTest()
        {
            Assert.Fail();
        }
    }
}