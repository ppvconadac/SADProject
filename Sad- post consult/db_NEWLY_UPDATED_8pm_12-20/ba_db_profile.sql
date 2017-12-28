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
-- Table structure for table `profile`
--

DROP TABLE IF EXISTS `profile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `profile` (
  `user_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Profile_name` varchar(45) DEFAULT NULL,
  `profile_fname` varchar(45) DEFAULT NULL,
  `profile_mname` varchar(45) DEFAULT NULL,
  `profile_lname` varchar(45) DEFAULT NULL,
  `Profile_Address` varchar(45) DEFAULT NULL,
  `Profile_cpnumber` varchar(11) DEFAULT NULL,
  `Profile_balance` int(11) DEFAULT NULL,
  `profile_idt` int(11) DEFAULT NULL,
  `profile_idn` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profile`
--

LOCK TABLES `profile` WRITE;
/*!40000 ALTER TABLE `profile` DISABLE KEYS */;
INSERT INTO `profile` VALUES (5,'a','karl','lim','3333','22333',0,3,'4324342'),(6,'b','patric','cadano','davao','0932124432',0,1,'42343242'),(7,'c','emil','gimena','davao','0943243432',0,1,'76864324'),(8,'d.inc','fernan','monton','tagum','09876543213',0,2,'1132423423'),(9,'e.org','joshua','kun','quantum universe','0987643214',0,1,'90468463'),(10,'rj.bayot','rj','reroma','sa mundo na wala ka','09696969669',0,3,'0o0o0o0o0o0o'),(11,'keno.lmao','keno','neffe','davao','0942428642',0,2,'66767234'),(12,'f.ince','karl brian','lim','davao','0987643212',0,3,'121594'),(13,'rand','karl','qwe','luland','0987643216',0,2,'43543643'),(14,'dsa','karl brian eklabu','xd','davao','00987643215',0,1,'4354343');
/*!40000 ALTER TABLE `profile` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-12-20 20:16:19
