using Lazydog.mysql.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;

namespace Lazydog.mysql.test
{
    [TestClass]
    public class ExcuseRepoTest
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
        [TestMethod]
        public void Test_CanRetriveExcuseDb()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            Assert.IsNotNull(instantiator.GetExcuseRepo());
        }
        [TestMethod]
        public void Test_HasExcuse()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            ExcuseRepo repo = instantiator.GetExcuseRepo();
            Assert.IsTrue(repo.GetExcuses().Count > 0);
        }
        [TestMethod]
        public void Test_HasExcuse_Emergency()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            ExcuseRepo repo = instantiator.GetExcuseRepo();
            Assert.IsTrue(repo.GetExcuses("Emergency").Count > 0);
        }
        [TestMethod]
        public void Test_GetAnExcuse()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            ExcuseRepo repo = instantiator.GetExcuseRepo();
            Assert.IsTrue(repo.GetAnExcuse().ExcuseTitle.Length>0);
        }
    }
}
