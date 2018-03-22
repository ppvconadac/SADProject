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
-- Table structure for table `uwat_trans_specs`
--

DROP TABLE IF EXISTS `uwat_trans_specs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `uwat_trans_specs` (
  `uwt_ID` int(11) NOT NULL AUTO_INCREMENT,
  `uwt_date` varchar(45) DEFAULT NULL,
  `uwt_prev` double DEFAULT NULL,
  `uwt_current` double DEFAULT NULL,
  `uwt_total` double DEFAULT NULL,
  `uwt_uwat_id` int(11) NOT NULL,
  `uwt_room_id` int(11) NOT NULL,
  `uwt_pay_meth` varchar(45) DEFAULT NULL,
  `uwt_pay_stat` varchar(45) DEFAULT NULL,
  `uwt_void_date` varchar(45) DEFAULT NULL,
  `uwt_void_loggedin` varchar(45) DEFAULT NULL,
  `uwt_pay_date` varchar(45) DEFAULT NULL,
  `uwt_owner_pay` varchar(45) DEFAULT NULL,
  `uwt_trans_resolved` varchar(45) DEFAULT NULL,
  `uwt_trans_stat` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`uwt_ID`),
  KEY `fk_uwat_id_idx` (`uwt_uwat_id`),
  KEY `fk_uwat_roomid_idx` (`uwt_room_id`),
  CONSTRAINT `fk_uwat_id` FOREIGN KEY (`uwt_uwat_id`) REFERENCES `utwat_trans` (`uwat_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_uwat_roomid` FOREIGN KEY (`uwt_room_id`) REFERENCES `room` (`Room_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `uwat_trans_specs`
--

LOCK TABLES `uwat_trans_specs` WRITE;
/*!40000 ALTER TABLE `uwat_trans_specs` DISABLE KEYS */;
/*!40000 ALTER TABLE `uwat_trans_specs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-03-22 19:05:23
