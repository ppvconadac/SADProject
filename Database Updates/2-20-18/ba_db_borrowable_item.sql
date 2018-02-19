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
-- Table structure for table `borrowable_item`
--

DROP TABLE IF EXISTS `borrowable_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `borrowable_item` (
  `bitem_ID` int(11) NOT NULL AUTO_INCREMENT,
  `bitem_name` varchar(45) DEFAULT NULL,
  `bitem_desc` varchar(45) DEFAULT NULL,
  `bitem_status` varchar(45) DEFAULT NULL,
  `bitem_dmg_status` varchar(45) DEFAULT NULL,
  `bitem_actual` double DEFAULT NULL,
  `bitem_rate` double DEFAULT NULL,
  PRIMARY KEY (`bitem_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `borrowable_item`
--

LOCK TABLES `borrowable_item` WRITE;
/*!40000 ALTER TABLE `borrowable_item` DISABLE KEYS */;
INSERT INTO `borrowable_item` VALUES (1,'Chicken',NULL,'available','functional',NULL,NULL),(2,'Beef',NULL,'available','functional',NULL,NULL),(3,'Pork',NULL,'Not Available','functional',NULL,NULL),(4,'Bed',NULL,'Out Of Stock','Damaged',NULL,NULL),(5,'Spoon',NULL,'available','functional',NULL,NULL),(6,'Fork',NULL,'available','functional',NULL,NULL);
/*!40000 ALTER TABLE `borrowable_item` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-20  5:29:31
