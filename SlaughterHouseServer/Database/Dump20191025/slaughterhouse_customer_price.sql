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
-- Table structure for table `customer_price`
--

DROP TABLE IF EXISTS `customer_price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_price` (
  `customer_code` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customer_code`,`product_code`,`start_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_price`
--

LOCK TABLES `customer_price` WRITE;
/*!40000 ALTER TABLE `customer_price` DISABLE KEYS */;
INSERT INTO `customer_price` VALUES ('001','P0024','2019-09-30','2019-12-29',12.00,'2019-09-30 19:54:07','system',NULL,NULL),('001','P003','2019-09-29','2020-01-07',135.00,'2019-09-29 13:33:43','system',NULL,NULL),('001','P0031','2019-09-29','2020-01-07',16.00,'2019-09-29 13:34:02','system',NULL,NULL),('001','P0041','2019-09-29','2019-10-09',10.00,'2019-09-29 14:06:15','system',NULL,NULL),('002','P002','2019-09-01','2019-09-11',150.00,'2019-09-28 12:44:49','system','2019-09-29 13:06:09','system'),('002','P0033','2019-09-29','2020-02-16',34.00,'2019-09-29 13:43:23','system',NULL,NULL),('002','P004','2019-09-29','2020-02-26',320.00,'2019-09-29 12:33:13','system','2019-09-29 13:38:28','system'),('003','P0055','2019-09-25','2019-10-10',120.00,'2019-09-29 13:39:01','system',NULL,NULL),('003','P0207','2019-09-24','2020-01-02',140.00,'2019-09-29 13:43:01','system','2019-09-29 13:49:12','system'),('PKP0001','P0023','2019-10-25','2019-11-14',88.00,'2019-10-25 10:39:52','system',NULL,NULL);
/*!40000 ALTER TABLE `customer_price` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:49
