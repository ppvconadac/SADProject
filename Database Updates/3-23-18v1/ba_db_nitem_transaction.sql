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
-- Table structure for table `nitem_transaction`
--

DROP TABLE IF EXISTS `nitem_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `nitem_transaction` (
  `ntrans_ID` int(11) NOT NULL AUTO_INCREMENT,
  `nt_date` varchar(45) DEFAULT NULL,
  `nt_quantity` int(11) DEFAULT NULL,
  `nonborrowable_item_nitem_ID` int(11) NOT NULL,
  `nt_type` varchar(45) DEFAULT NULL,
  `nt_archive_date` varchar(45) DEFAULT NULL,
  `nt_archived_loggedin` varchar(45) DEFAULT NULL,
  `nt_roomID` int(11) DEFAULT NULL,
  `nt_trans_stat` int(11) DEFAULT NULL,
  PRIMARY KEY (`ntrans_ID`),
  KEY `fk_nitem_transaction_nonborrowable_item1_idx` (`nonborrowable_item_nitem_ID`),
  KEY `fk_nt_itemID_idx` (`nt_roomID`),
  CONSTRAINT `fk_nitem_transaction_nonborrowable_item1` FOREIGN KEY (`nonborrowable_item_nitem_ID`) REFERENCES `nonborrowable_item` (`nitem_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_nt_itemID` FOREIGN KEY (`nt_roomID`) REFERENCES `room` (`Room_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `nitem_transaction`
--

LOCK TABLES `nitem_transaction` WRITE;
/*!40000 ALTER TABLE `nitem_transaction` DISABLE KEYS */;
INSERT INTO `nitem_transaction` VALUES (1,'2018/2/26',5,4,'Stock-out','2018-3-2','1',1,2),(2,'2018/2/26',5,4,'Stock-out',NULL,NULL,1,1),(3,'2018/2/28',5,4,'Stock-out',NULL,NULL,4,1),(4,'2018/2/28',5,4,'Stock-in',NULL,NULL,NULL,1),(5,'2018-3-19',5,4,'Stock-in',NULL,NULL,NULL,1);
/*!40000 ALTER TABLE `nitem_transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-23  7:40:32
