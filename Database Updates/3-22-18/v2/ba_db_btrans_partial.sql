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
-- Table structure for table `btrans_partial`
--

DROP TABLE IF EXISTS `btrans_partial`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `btrans_partial` (
  `bp_id` int(11) NOT NULL AUTO_INCREMENT,
  `bp_date` varchar(45) DEFAULT NULL,
  `bp_amount` varchar(45) DEFAULT NULL,
  `bp_trans_id` int(11) NOT NULL,
  PRIMARY KEY (`bp_id`),
  KEY `bp_btrans_id_idx` (`bp_trans_id`),
  CONSTRAINT `bp_btrans_id` FOREIGN KEY (`bp_trans_id`) REFERENCES `bitem_transaction` (`btrans_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `btrans_partial`
--

LOCK TABLES `btrans_partial` WRITE;
/*!40000 ALTER TABLE `btrans_partial` DISABLE KEYS */;
INSERT INTO `btrans_partial` VALUES (1,'2018/3/3','2',28),(2,'2018/3/3','2',29),(3,'2018/3/3','1',30),(4,'2018/3/3','5',31),(6,'2018/3/3','2',34),(7,'2018/3/3','2',35),(8,'2018/3/3','2',35),(9,'2018/3/3','2',35),(10,'2018/3/5','1',34),(11,'2018/3/5','5',37),(12,'2018/3/5','1',38),(13,'2018-3-22','1.5',40),(14,'2018-3-22','0.5',40);
/*!40000 ALTER TABLE `btrans_partial` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-22 15:31:16
