using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;

namespace Lazydog.mysql.test
{
    [TestClass]
    public class DbRepoInstantiatorTest
    {
        public static string InitializeDbScript = @"
            CREATE DATABASE  IF NOT EXISTS `lazydogtest` /*!40100 DEFAULT CHARACTER SET utf8 */;
            USE `lazydogtest`;

            DROP TABLE IF EXISTS `culture`;
            /*!40101 SET @saved_cs_client     = @@character_set_client */;
            /*!40101 SET character_set_client = utf8 */;
            CREATE TABLE `culture` (
              `ID` int(11) NOT NULL AUTO_INCREMENT,
              `CultureCode` varchar(15) DEFAULT NULL,
              `CultureName` varchar(75) DEFAULT NULL,
              `Active` bit(1) DEFAULT b'1',
              PRIMARY KEY (`ID`)
            ) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
           

            LOCK TABLES `culture` WRITE;
            /*!40000 ALTER TABLE `culture` DISABLE KEYS */;
            INSERT INTO `culture` VALUES (1,'en-US','English (united States)',''),(2,'es-ES','Spanish (Spain)',''),(3,'en-GB','English (united kingdom)',''),(4,'fr-CA','French (Canadian)','');
            /*!40000 ALTER TABLE `culture` ENABLE KEYS */;
            UNLOCK TABLES;

            DROP TABLE IF EXISTS `excuse`;
            /*!40101 SET @saved_cs_client     = @@character_set_client */;
            /*!40101 SET character_set_client = utf8 */;
            CREATE TABLE `excuse` (
              `ExcuseId` int(11) NOT NULL AUTO_INCREMENT,
              `ExcuseTitle` varchar(120) DEFAULT NULL,
              `ExcuseDescription` text,
              `ExcuseLabels` varchar(345) DEFAULT NULL,
              PRIMARY KEY (`ExcuseId`)
            ) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
          
            LOCK TABLES `excuse` WRITE;
            /*!40000 ALTER TABLE `excuse` DISABLE KEYS */;
            INSERT INTO `excuse` VALUES (1,'Flu','Generic excuse but common during certain seasons','Sick,Medical'),(2,'Colds',NULL,'Sick,Medical'),(3,'Immobilizing Back pain','Say that your back hurts so much that you can barely stand','Sick,Medical'),(4,'Broken Foot',NULL,'Sick,Medical'),(5,'Migraine',NULL,'Sick, Medical'),(6,'LBM','Usual','Sick, Medical'),(7,'Persistent Vomit','Gross and frequent Vommiting','Sick, Medical'),(8,'Sniffles','red nose','Sick,Medical'),(9,'Car Accident','Might need Police report','Sick,Medical, Emergency'),(10,'Automobile broke down',NULL,NULL),(11,'Carpal Tunnel Syndrome','Wrist problems',NULL),(12,'Fever',NULL,'Sick, Medical'),(13,'Sick Child',NULL,'Personal, Emergency'),(14,'Toothache',NULL,NULL),(15,'Food Poisoning','Stomach problems',NULL),(16,'In grown nail',NULL,NULL),(17,'Stomach main',NULL,NULL),(18,'Family matters','vague but acceptable','Personal, Emergency'),(19,'Severe Rash',NULL,NULL),(20,'Broken toilet at home',NULL,NULL),(21,'Stiff Neck','Cite severe case',NULL),(22,'Liver checkup','Might need medical certificate',NULL),(23,'Kidney Check up',NULL,NULL),(24,'Got Assaulted last night','Too injured to work','Personal, Emergency'),(25,'Bleeding ears','Blood on Ears',NULL);
            /*!40000 ALTER TABLE `excuse` ENABLE KEYS */;
            UNLOCK TABLES;
        ";
        public static string defaultConnectionString = @"server=localhost;Database=lazydogtest;user=adminTest;port=3306;password=w0rd-Life;";
        //Needs special Admin user
        public static void StartDB()
        {
            string connStr = "server=localhost;user=adminTest;port=3306;password=w0rd-Life;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
           
            try
            {
                conn.Open();
                cmd = new MySqlCommand(InitializeDbScript, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
               
            }
        }
        public static void finishTest()
        {
            string connStr = "server=localhost;user=adminTest;port=3306;password=w0rd-Life;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;

            try
            {
                conn.Open();
                cmd = new MySqlCommand("DROP DATABASE lazydogtest", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {

            }
        }
        [TestInitialize]
        public void Initialize()
        {
            StartDB();
        }
        [TestCleanup]
        public void cleanUp()
        {
            finishTest();
        }
        [TestMethod]
        public void Test_CanRetriveExcuseDb()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            Assert.IsNotNull(instantiator.GetExcuseRepo());
        }
        [TestMethod]
        public void Test_CanRetriveCulturesDb()
        {
            DbRepoInstantiator instantiator = new DbRepoInstantiator(DbRepoInstantiatorTest.defaultConnectionString);
            Assert.IsNotNull(instantiator.GetCultureRepo());
        }
    }
}
