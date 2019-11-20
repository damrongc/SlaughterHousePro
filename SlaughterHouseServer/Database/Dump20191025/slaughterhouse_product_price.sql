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
-- Table structure for table `product_price`
--

DROP TABLE IF EXISTS `product_price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_price` (
  `product_code` varchar(10) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_code`,`start_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_price`
--

LOCK TABLES `product_price` WRITE;
/*!40000 ALTER TABLE `product_price` DISABLE KEYS */;
INSERT INTO `product_price` VALUES ('0001','2019-10-21','2019-10-31',70.00,'2019-10-25 00:04:46','system',NULL,NULL),('P001','2019-09-01','2019-12-10',1250.00,'2019-09-05 23:01:39','system','2019-09-29 13:49:17','system'),('P002','2019-09-01','2019-10-01',211.00,'2019-09-20 13:31:36','system','2019-09-29 11:58:43','system'),('P0021','2019-10-30','2019-11-09',100.00,'2019-10-25 11:03:53','system',NULL,NULL),('P0021','2019-10-31','2019-11-05',80.00,'2019-10-25 11:04:55','system',NULL,NULL),('P0023','2019-10-25','2019-11-14',100.00,'2019-10-25 10:38:16','system',NULL,NULL),('P003','2019-09-20','2019-12-29',200.00,'2019-09-20 13:30:13','system','2019-10-10 19:22:21','system'),('P0032','2019-09-23','2020-01-01',100.00,'2019-09-23 13:33:59','system','2019-09-29 13:49:30','system'),('P008','2019-09-01','2019-12-10',1500.00,'2019-09-05 23:01:25','system',NULL,NULL),('P009','2019-09-23','2020-01-01',72.00,'2019-09-23 10:18:34','system','2019-09-29 13:49:22','system'),('P010','2019-09-23','2019-12-31',73.00,'2019-09-23 10:18:44','system','2019-09-29 01:25:20','system'),('P010','2019-09-24','2021-04-06',100.00,'2019-09-29 13:45:25','system',NULL,NULL),('P011','2019-09-23','2019-12-30',81.00,'2019-09-23 10:18:51','system','2019-09-29 01:25:30','system'),('P012','2019-09-23','2020-01-01',82.00,'2019-09-23 10:18:57','system',NULL,NULL);
/*!40000 ALTER TABLE `product_price` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:58:01
