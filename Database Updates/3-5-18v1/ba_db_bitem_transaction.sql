-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: ba_db
-- ------------------------------------------------------
-- Server version	5.7.20-log

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
-- Table structure for table `bitem_transaction`
--

DROP TABLE IF EXISTS `bitem_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bitem_transaction` (
  `btrans_ID` int(11) NOT NULL AUTO_INCREMENT,
  `bt_date` varchar(45) DEFAULT NULL,
  `bt_pay_status` varchar(45) DEFAULT NULL,
  `bt_pay_method` varchar(45) DEFAULT NULL,
  `bt_price` varchar(45) DEFAULT NULL,
  `Profile_user_ID` int(11) NOT NULL,
  `borrowable_item_bitem_ID` int(11) NOT NULL,
  `bt_ret` varchar(45) DEFAULT NULL,
  `bt_pay_date` varchar(45) DEFAULT NULL,
  `bt_trans_stat` int(11) DEFAULT NULL,
  `bt_archive_date` varchar(45) DEFAULT NULL,
  `bt_archive_loggedin` int(11) DEFAULT NULL,
  PRIMARY KEY (`btrans_ID`),
  KEY `fk_bitem_Transaction_Profile1_idx` (`Profile_user_ID`),
  KEY `fk_bitem_Transaction_borrowable_item1_idx` (`borrowable_item_bitem_ID`),
  CONSTRAINT `fk_bitem_Transaction_Profile1` FOREIGN KEY (`Profile_user_ID`) REFERENCES `profile` (`user_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bitem_Transaction_borrowable_item1` FOREIGN KEY (`borrowable_item_bitem_ID`) REFERENCES `borrowable_item` (`bitem_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bitem_transaction`
--

LOCK TABLES `bitem_transaction` WRITE;
/*!40000 ALTER TABLE `bitem_transaction` DISABLE KEYS */;
INSERT INTO `bitem_transaction` VALUES (7,'2018/2/22','Paid','Check',NULL,9,1,'2018/2/26','2018/2/26',1,NULL,NULL),(8,'2018/2/22','Paid','Check',NULL,6,2,'2018/2/26','2018/2/26',1,NULL,NULL),(9,'2018/2/26','Paid','Check',NULL,13,3,'2018/2/26','2018/2/26',1,NULL,NULL),(10,'2018/2/26','Paid','Cash',NULL,15,5,'2018/2/26','2018/2/26',1,NULL,NULL),(11,'2018/2/25','Paid','Cash',NULL,12,1,'2018/2/26','2018/2/26',1,NULL,NULL),(12,'2018/2/25','Paid','Cash',NULL,10,3,'2018/2/26','2018/2/25',1,NULL,NULL),(13,'2018/2/25','Paid','Cash',NULL,10,1,'2018/2/26','2018/2/25',1,NULL,NULL),(14,'2018/2/25','Paid','Cash',NULL,5,1,'2018/2/26','2018/2/25',1,NULL,NULL),(15,'2018/2/25','Pending','Check',NULL,8,2,NULL,NULL,2,'2018-2-25',1),(16,'2018/2/28','Paid','Cash',NULL,8,3,'2018/2/28','2018/2/28',1,NULL,NULL),(17,'2018/3/3','Paid','Cash','3',5,3,'2018/3/3','2018/3/3',1,NULL,NULL),(18,'2018/3/3','Paid','Cash','5',6,5,'2018/3/3','2018/3/3',1,NULL,NULL),(19,'2018/3/3','Paid','Cash','6',9,6,'2018/3/3','2018/3/3',1,NULL,NULL),(20,'2018/3/3','Paid','Cash','1',6,1,'2018/3/3','2018/3/3',1,NULL,NULL),(21,'2018/3/3','Paid','Cash','3',7,3,'2018/3/3','2018/3/3',1,NULL,NULL),(22,'2018/3/3','Paid','Cash','5',8,5,'2018/3/3','2018/3/3',1,NULL,NULL),(23,'2018/3/3','Paid','Cash','3',6,3,'2018/3/3','2018/3/3',1,NULL,NULL),(24,'2018/3/3','Paid','Cash','5',6,5,'2018/3/3','2018/3/3',1,NULL,NULL),(25,'2018/3/3','Paid','Cash','1',6,1,'2018/3/3','2018/3/3',1,NULL,NULL),(26,'2018/3/3','Paid','Cash','3',7,3,'2018/3/3','2018/3/3',1,NULL,NULL),(27,'2018/3/3','Paid','Cash','1',5,1,'2018/3/3','2018/3/3',1,NULL,NULL),(28,'2018/3/3','Paid','Cash','3',6,3,'2018/3/3','2018/3/3',1,NULL,NULL),(29,'2018/3/3','Paid','Cash','6',6,6,'2018/3/3','2018/3/3',1,NULL,NULL),(30,'2018/3/3','Paid','Cash','3',6,3,'2018/3/3','2018/3/3',1,NULL,NULL),(31,'2018/3/3','Paid','Cash','5',6,5,'2018/3/3','2018/3/3',1,NULL,NULL),(33,'2018/3/3','Paid','Check','5',6,5,'2018/3/3','2018/3/3',1,NULL,NULL),(34,'2018/3/3','Paid','Cash','3',6,3,'2018/3/5','2018/3/5',1,NULL,NULL),(35,'2018/3/3','Paid','Cash','5',6,5,'2018/3/5','2018/3/3',1,NULL,NULL),(36,'2018/3/3','Paid','Check','6',6,6,'2018/3/5','2018/3/5',1,NULL,NULL),(37,'2018/3/5','Paid','Cash','5',7,5,'2018/3/5','2018/3/5',1,NULL,NULL),(38,'2018/3/5','Paid','Cash','1',6,1,NULL,'2018/3/5',0,NULL,NULL);
/*!40000 ALTER TABLE `bitem_transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-05 15:08:23
