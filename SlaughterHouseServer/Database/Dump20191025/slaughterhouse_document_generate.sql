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
-- Table structure for table `document_generate`
--

DROP TABLE IF EXISTS `document_generate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `document_generate` (
  `document_type` varchar(3) NOT NULL,
  `running` int(11) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_at` datetime DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`document_type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document_generate`
--

LOCK TABLES `document_generate` WRITE;
/*!40000 ALTER TABLE `document_generate` DISABLE KEYS */;
INSERT INTO `document_generate` VALUES ('BF',0,'2019-10-14 21:49:22',NULL,'ยกมา'),('INV',6,'2019-06-14 19:18:00','2019-10-25 12:25:04','เอกสาร invoice'),('ISS',1,'2019-06-14 19:18:00',NULL,'เอกสารเบิก'),('PDL',1,'2019-06-22 16:17:31',NULL,'product lot no'),('PDS',14,'2019-09-21 17:01:31','2019-10-24 20:40:23','product slip'),('PO',5,'2019-07-03 16:28:14','2019-09-15 08:00:12',NULL),('REV',7,'2019-06-14 19:18:00','2019-10-25 11:10:52','เอกสารรับหมูเป็น'),('SO',38,'2019-06-14 19:18:00','2019-10-25 12:09:10','เอกสาร sales order'),('STK',20,'2019-06-28 18:55:46',NULL,'Stock document no'),('SWL',1,'2019-06-22 15:49:34',NULL,'Lot No รับหมูเป็น'),('TP',4,'2019-10-14 21:49:22',NULL,'?????????????');
/*!40000 ALTER TABLE `document_generate` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:58:03
