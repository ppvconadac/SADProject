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
-- Table structure for table `bitem_damage_transaction`
--

DROP TABLE IF EXISTS `bitem_damage_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bitem_damage_transaction` (
  `bdtrans_ID` int(11) NOT NULL AUTO_INCREMENT,
  `bdt_date` varchar(45) DEFAULT NULL,
  `bdt_price` varchar(45) DEFAULT NULL,
  `Profile_user_ID` int(11) DEFAULT NULL,
  `borrowable_item_bitem_ID` int(11) NOT NULL,
  `bdt_pay_method` varchar(45) DEFAULT NULL,
  `bdt_pay_status` varchar(45) DEFAULT NULL,
  `bdt_pay_date` varchar(45) DEFAULT NULL,
  `bdt_trans_stat` int(11) DEFAULT NULL,
  PRIMARY KEY (`bdtrans_ID`),
  KEY `fk_bitem_damage_transaction_Profile1_idx` (`Profile_user_ID`),
  KEY `fk_bitem_damage_transaction_borrowable_item1_idx` (`borrowable_item_bitem_ID`),
  CONSTRAINT `fk_bitem_damage_transaction_Profile1` FOREIGN KEY (`Profile_user_ID`) REFERENCES `profile` (`user_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bitem_damage_transaction_borrowable_item1` FOREIGN KEY (`borrowable_item_bitem_ID`) REFERENCES `borrowable_item` (`bitem_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bitem_damage_transaction`
--

LOCK TABLES `bitem_damage_transaction` WRITE;
/*!40000 ALTER TABLE `bitem_damage_transaction` DISABLE KEYS */;
INSERT INTO `bitem_damage_transaction` VALUES (3,'2018/3/5','5',6,5,'Cash','Pending',NULL,0),(4,'2018/3/5','5',6,5,'Cash','Pending',NULL,0),(5,'2018/3/5','5',6,6,'Check','Paid','2018/3/17',1),(6,'2018/3/5','10',6,3,'Cash','Partially Paid',NULL,0),(7,'2018/3/5','5',7,5,'Cash','Paid','2018/3/5',1),(8,'2018/3/5','1',6,1,'Cash','Paid','2018/3/5',0),(9,'2018/3/17','14515',11,1,'Cash','Paid','2018/3/17',0),(10,'2018-3-19','555',10,8,'Cash','Paid','2018-3-19',0);
/*!40000 ALTER TABLE `bitem_damage_transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-20 20:09:56
