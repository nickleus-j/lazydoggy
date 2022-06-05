using Lazydog.Model.Repo;
using Lazydog.mysql.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;


namespace Lazydog.mysql.test
{
    [TestClass()]
    public class CultureRepoTests
    {
        [TestInitialize]
        public void Initialize()
        {
            DbRepoInstantiatorTest.StartDB();
        }
        [TestCleanup]
        public void cleanUp()
        {
            DbRepoInstantiatorTest.finishTest();
        }
        [TestMethod()]
        public void GetSupportedCulturesTest()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            ICultureRepo cultureRepo = instantiator.GetCultureRepo();
            Assert.IsTrue(cultureRepo.GetSupportedCultures().Count > 0);
        }
    }
}