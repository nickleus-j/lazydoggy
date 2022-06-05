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
            /*!40101 SET character_set_client = @saved_cs_client */;

            LOCK TABLES `culture` WRITE;
            /*!40000 ALTER TABLE `culture` DISABLE KEYS */;
            INSERT INTO `culture` VALUES (1,'en-US','English (united States)',_binary ''),(2,'es-ES','Spanish (Spain)',_binary ''),(3,'en-GB','English (united kingdom)',_binary ''),(4,'fr-CA','French (Canadian)',_binary '');
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
            ) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
            /*!40101 SET character_set_client = @saved_cs_client */;

            LOCK TABLES `excuse` WRITE;
            /*!40000 ALTER TABLE `excuse` DISABLE KEYS */;
            INSERT INTO `excuse` VALUES (1,'Flu','Generic excuse but common during certain seasons','Sick,Medical'),(2,'Colds',NULL,'Sick,Medical'),(3,'Immobilizing Back pain','Say that your back hurts so much that you can barely stand','Sick,Medical'),(4,'Broken Foot',NULL,'Sick,Medical'),(5,'Migraine',NULL,'Sick, Medical'),(6,'LBM','Usual','Sick, Medical'),(7,'Persistent Vomit','Gross and frequent Vommiting','Sick, Medical'),(8,'Sniffles','red nose','Sick,Medical'),(9,'Car Accident','Might need Police report','Sick,Medical, Emergency'),(10,'Automobile broke down',NULL,NULL),(11,'Carpal Tunnel Syndrome','Wrist problems',NULL),(12,'Fever',NULL,'Sick, Medical'),(13,'Sick Child',NULL,'Personal, Emergency'),(14,'Toothache',NULL,NULL),(15,'Food Poisoning','Stomach problems',NULL),(16,'In grown nail',NULL,NULL),(17,'Stomach pain',NULL,'Sick, Medical'),(18,'Family matters','vague but acceptable','Personal, Emergency'),(19,'Severe Rash',NULL,NULL),(20,'Broken toilet at home',NULL,NULL),(21,'Stiff Neck','Cite severe case',NULL),(22,'Liver checkup','Might need medical certificate',NULL),(23,'Kidney Check up',NULL,NULL),(24,'Got Assaulted last night','Too injured to work','Personal, Emergency'),(25,'Bleeding ears','Blood on Ears',NULL),(26,'Heartburn',NULL,'Medical'),(27,'acid reflux',NULL,'Sick, Medical'),(28,'Recent Broken Limb',NULL,'Sick, Medical'),(29,'Persitent Rash','Itches so much, cant concentrate on work','Sick, Medical'),(30,'Burnt Foot',NULL,'Sick, Medical');
            /*!40000 ALTER TABLE `excuse` ENABLE KEYS */;
            UNLOCK TABLES;

            DROP TABLE IF EXISTS `excusealteration`;
            /*!40101 SET @saved_cs_client     = @@character_set_client */;
            /*!40101 SET character_set_client = utf8 */;
            CREATE TABLE `excusealteration` (
              `alterationID` int(11) NOT NULL AUTO_INCREMENT,
              `excuseID` int(11) NOT NULL,
              `alteredTitle` varchar(120) DEFAULT NULL,
              PRIMARY KEY (`alterationID`),
              KEY `ateredExcuse_idx` (`excuseID`),
              CONSTRAINT `ateredExcuse` FOREIGN KEY (`excuseID`) REFERENCES `excuse` (`ExcuseId`) ON DELETE CASCADE ON UPDATE CASCADE
            ) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
            /*!40101 SET character_set_client = @saved_cs_client */;

            LOCK TABLES `excusealteration` WRITE;
            /*!40000 ALTER TABLE `excusealteration` DISABLE KEYS */;
            INSERT INTO `excusealteration` VALUES (1,9,'Automobile Accident'),(2,9,'Traffic Accident'),(3,3,'Severe Back problems'),(4,7,'Uncontrolled Vomit'),(5,17,'Stomach ache'),(6,26,'painful burning feeling in chest'),(7,23,'Kidney appointment'),(8,24,'Injured from Physical Altercation'),(9,29,'Scourging Rash'),(10,18,'Family Emergency');
            /*!40000 ALTER TABLE `excusealteration` ENABLE KEYS */;
            UNLOCK TABLES;

            DROP TABLE IF EXISTS `lettertemplate`;
            /*!40101 SET @saved_cs_client     = @@character_set_client */;
            /*!40101 SET character_set_client = utf8 */;
            CREATE TABLE `lettertemplate` (
              `templateId` int(11) NOT NULL AUTO_INCREMENT,
              `content` text,
              `meta` json DEFAULT NULL,
              `name` varchar(50) DEFAULT NULL,
              `active` bit(1) DEFAULT b'1',
              PRIMARY KEY (`templateId`)
            ) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
            /*!40101 SET character_set_client = @saved_cs_client */;

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
