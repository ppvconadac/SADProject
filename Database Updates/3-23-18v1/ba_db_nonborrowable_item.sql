-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: ba_db
-- ------------------------------------------------------
-- Server version	5.7.19-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `nonborrowable_item`
--

DROP TABLE IF EXISTS `nonborrowable_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nonborrowable_item` (
  `nitem_ID` int(11) NOT NULL AUTO_INCREMENT,
  `nitem_name` varchar(45) DEFAULT NULL,
  `nitem_price` varchar(45) DEFAULT NULL,
  `nitem_desc` varchar(45) DEFAULT NULL,
  `nitem_stat` varchar(45) DEFAULT NULL,
  `nt_archive_date` varchar(45) DEFAULT NULL,
  `nt_archive_loggedin` varchar(45) DEFAULT NULL,
  `nt_quantity` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`nitem_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nonborrowable_item`
--

LOCK TABLES `nonborrowable_item` WRITE;
/*!40000 ALTER TABLE `nonborrowable_item` DISABLE KEYS */;
INSERT INTO `nonborrowable_item` VALUES (1,'sop','24','sef','1','2018-2-26','1',NULL),(2,'sop','24','sef','1','2018-2-26','1',NULL),(3,'sop','24','sef','1','2018-2-26','1',NULL),(4,'sop','24','sef','0',NULL,NULL,'25');
/*!40000 ALTER TABLE `nonborrowable_item` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-23  7:40:34
