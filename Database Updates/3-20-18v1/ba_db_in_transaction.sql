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
-- Table structure for table `in_transaction`
--

DROP TABLE IF EXISTS `in_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `in_transaction` (
  `intrans_ID` int(11) NOT NULL AUTO_INCREMENT,
  `it_date` varchar(45) DEFAULT NULL,
  `it_price` varchar(45) DEFAULT NULL,
  `it_owner` int(11) NOT NULL,
  `it_desc` varchar(45) DEFAULT NULL,
  `it_trans_stat` varchar(45) DEFAULT NULL,
  `it_void_date` varchar(45) DEFAULT NULL,
  `it_void_loggedin` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`intrans_ID`),
  KEY `fk_idx` (`it_owner`),
  CONSTRAINT `fk` FOREIGN KEY (`it_owner`) REFERENCES `owner` (`Owner_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `in_transaction`
--

LOCK TABLES `in_transaction` WRITE;
/*!40000 ALTER TABLE `in_transaction` DISABLE KEYS */;
INSERT INTO `in_transaction` VALUES (1,'2018-3-20','555',2,'rosary','0',NULL,NULL),(2,'2018-3-20','111',2,'XD','1',NULL,NULL),(3,'2018-3-20','100000',2,'bombs','2','2018-3-20','1');
/*!40000 ALTER TABLE `in_transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-20 20:09:49
