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
-- Table structure for table `room_transaction`
--

DROP TABLE IF EXISTS `room_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `room_transaction` (
  `rTrans_ID` int(11) NOT NULL AUTO_INCREMENT,
  `rt_date` varchar(50) DEFAULT NULL,
  `rt_date_start` varchar(50) DEFAULT NULL,
  `rt_date_expire` varchar(50) DEFAULT NULL,
  `rt_price` int(11) DEFAULT NULL,
  `rt_discount` int(11) DEFAULT NULL,
  `Profile_user_ID` int(11) NOT NULL,
  `Room_Room_ID` int(11) NOT NULL,
  PRIMARY KEY (`rTrans_ID`),
  KEY `fk_Room_transaction_Profile1_idx` (`Profile_user_ID`),
  KEY `fk_Room_Profile1_idx` (`Room_Room_ID`),
  CONSTRAINT `fk_rm_id` FOREIGN KEY (`Room_Room_ID`) REFERENCES `room` (`Room_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_usr_id` FOREIGN KEY (`Profile_user_ID`) REFERENCES `profile` (`user_ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `room_transaction`
--

LOCK TABLES `room_transaction` WRITE;
/*!40000 ALTER TABLE `room_transaction` DISABLE KEYS */;
INSERT INTO `room_transaction` VALUES (12,'2/4/2018','2/4/2018','3/4/2018',20000,0,5,4),(13,'2/4/2018','2/4/2018','3/4/2018',20000,0,7,5),(15,'2/4/2018','2/4/2018','3/4/2018',20000,0,6,1),(16,'2/4/2018','2/4/2018','2/5/2018',10000,0,6,2),(17,'2/4/2018','2/4/2018','3/4/2018',20000,0,8,3),(18,'2/4/2018','2/4/2018','2/5/2018',10000,0,8,2),(19,'2/4/2018','2/4/2018','3/4/2018',20000,2,8,1),(20,'2/4/2018','2/4/2018','3/4/2018',20000,1,10,3),(21,'2/5/2018','2/5/2018','2/6/2018',10000,0,10,2),(22,'2/14/2018','2/14/2018','3/14/2018',20000,0,6,1);
/*!40000 ALTER TABLE `room_transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-02-20 20:42:51
