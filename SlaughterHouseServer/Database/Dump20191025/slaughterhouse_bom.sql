-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: 203.150.243.47    Database: slaughterhouse
-- ------------------------------------------------------
-- Server version	5.7.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bom`
--

DROP TABLE IF EXISTS `bom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bom` (
  `bom_code` int(11) NOT NULL AUTO_INCREMENT,
  `product_code` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`bom_code`),
  KEY `idx_bom_product` (`product_code`),
  CONSTRAINT `fk_bom_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bom`
--

LOCK TABLES `bom` WRITE;
/*!40000 ALTER TABLE `bom` DISABLE KEYS */;
INSERT INTO `bom` VALUES (0,'NA',1,'2019-08-11 12:25:45','system',NULL,NULL),(2,'P003',1,'2019-08-11 12:25:45','system','2019-09-23 11:45:58','system'),(3,'P004',1,'2019-08-11 12:25:45','system','2019-10-10 18:41:18','system'),(4,'P005',1,'2019-08-11 12:25:45','system',NULL,NULL),(5,'P002',1,'2019-08-11 12:25:45','system','2019-09-23 11:45:47','system'),(7,'P001',1,'2019-09-23 10:03:17','system','2019-09-23 10:10:01','system'),(12,'P009',1,'2019-09-26 18:49:29','system',NULL,NULL),(13,'P0027',1,'2019-10-03 00:54:35','system',NULL,NULL),(14,'P0028',1,'2019-10-10 18:43:38','system','2019-10-20 12:09:38','system'),(17,'0001',1,'2019-10-25 00:03:25','system',NULL,NULL);
/*!40000 ALTER TABLE `bom` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:51
