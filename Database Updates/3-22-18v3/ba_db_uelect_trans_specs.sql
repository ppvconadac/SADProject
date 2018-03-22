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
-- Table structure for table `uelect_trans_specs`
--

DROP TABLE IF EXISTS `uelect_trans_specs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uelect_trans_specs` (
  `uet_ID` int(11) NOT NULL AUTO_INCREMENT,
  `uet_date` varchar(45) DEFAULT NULL,
  `uet_prev` double DEFAULT NULL,
  `uet_current` double DEFAULT NULL,
  `uet_total` double DEFAULT NULL,
  `uet_uelect_id` int(11) NOT NULL,
  `uet_room_id` int(11) NOT NULL,
  `uet_pay_meth` varchar(45) DEFAULT NULL,
  `uet_pay_stat` varchar(45) DEFAULT NULL,
  `uet_void_date` varchar(45) DEFAULT NULL,
  `uet_void_loggedin` varchar(45) DEFAULT NULL,
  `uet_pay_date` varchar(45) DEFAULT NULL,
  `uet_owner_pay` varchar(45) DEFAULT NULL,
  `uet_trans_resolved` int(11) DEFAULT NULL,
  `uet_trans_stat` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uet_ID`),
  KEY `fk_uelect_id_idx` (`uet_uelect_id`),
  KEY `fk_uelect_roomid_idx` (`uet_room_id`),
  CONSTRAINT `fk_uelect_id` FOREIGN KEY (`uet_uelect_id`) REFERENCES `utelect_trans` (`uelect_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_uelect_roomid` FOREIGN KEY (`uet_room_id`) REFERENCES `room` (`Room_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uelect_trans_specs`
--

LOCK TABLES `uelect_trans_specs` WRITE;
/*!40000 ALTER TABLE `uelect_trans_specs` DISABLE KEYS */;
INSERT INTO `uelect_trans_specs` VALUES (8,'2018-3-22',555.55,600,400.05,1,4,'Check','Paid',NULL,NULL,'2018-3-22','Tenant',1,'0'),(9,'2018-3-22',123.45,555,3883.95,1,5,NULL,NULL,NULL,NULL,NULL,'Owner',0,'0');
/*!40000 ALTER TABLE `uelect_trans_specs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-22 19:01:57
