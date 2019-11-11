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
-- Table structure for table `barcode`
--

DROP TABLE IF EXISTS `barcode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `barcode` (
  `barcode_no` bigint(13) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `production_date` date NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `qty` int(11) NOT NULL DEFAULT '0',
  `wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  PRIMARY KEY (`barcode_no`),
  KEY `fk_barcode_product_idx` (`product_code`),
  CONSTRAINT `fk_barcode_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barcode`
--

LOCK TABLES `barcode` WRITE;
/*!40000 ALTER TABLE `barcode` DISABLE KEYS */;
INSERT INTO `barcode` VALUES (1000000000101,'P002','2019-08-07','11924910609',22,1.20,1,'2019-08-10 15:55:51','system'),(1000000000102,'P002','2019-08-07','',141,3.30,1,'2019-08-10 15:55:51','system'),(1000000000103,'P003','2019-08-07','',2,4.30,1,'2019-08-10 15:55:51','system'),(1000000000104,'P004','2019-08-07','',23,2.10,1,'2019-08-10 15:55:51','system'),(1000000000105,'P001','2019-08-07','',12,3.20,1,'2019-08-10 15:55:51','system'),(1000000000106,'P0021','2019-09-21','11924910609',1,12.67,0,'2019-09-21 16:57:13','auto'),(1000000000107,'P0021','2019-09-21','11924910609',1,11.88,0,'2019-09-21 16:58:29','auto'),(1000000000108,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:03:12','auto'),(1000000000109,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:05:11','auto'),(1000000000110,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:29:04','auto'),(1000000000111,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:31:02','auto'),(1000000000112,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:31:39','auto'),(1000000000113,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:33:14','auto'),(1000000000114,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:33:51','auto'),(1000000000115,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:36:04','auto'),(1000000000116,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:37:04','auto'),(1000000000117,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:44:26','auto'),(1000000000118,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:45:53','auto'),(1000000000119,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:57:32','auto'),(1000000000120,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:01:49','auto'),(1000000000121,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:03:25','auto'),(1000000000122,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:05:17','auto'),(1000000000123,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:08:33','auto'),(1000000000124,'P0021','2019-09-22','11924910609',1,0.21,0,'2019-09-22 17:18:58','auto'),(1000000000125,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:20:21','auto'),(1000000000126,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:32:56','auto'),(1000000000127,'P0021','2019-09-22','11924910609',1,1.20,0,'2019-09-22 17:42:41','auto'),(1000000000128,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:50:36','auto'),(1000000000129,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:51:41','auto'),(1000000000130,'P0021','2019-09-22','11924910609',1,0.04,0,'2019-09-22 17:52:52','auto'),(1000000000131,'P0021','2019-09-22','11924910609',1,0.10,0,'2019-09-22 17:57:45','auto'),(1000000000132,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:59:28','auto'),(1000000000133,'P0027','2019-09-22','11924910609',1,0.56,0,'2019-09-22 21:09:37','auto'),(1000000000134,'P0027','2019-09-22','11924910609',1,1.20,0,'2019-09-22 21:14:34','auto'),(1000000000135,'P0028','2019-09-22','11924910609',1,1.20,0,'2019-09-22 21:20:18','auto'),(1000000000136,'P0028','2019-09-22','11924910609',1,1.20,0,'2019-09-22 21:20:35','auto'),(1000000000137,'P0022','2019-09-22','11924910609',1,1.19,0,'2019-09-22 21:20:52','auto'),(1000000000138,'P0021','2019-09-22','11924910609',1,1.19,0,'2019-09-22 21:22:04','auto'),(1000000000139,'P0027','2019-09-23','11924910609',1,1.19,0,'2019-09-23 00:15:12','auto'),(1000000000140,'P005','2019-10-03','11926612309',1,5.25,0,'2019-10-03 16:12:43','192.168.56.1'),(1000000000141,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 17:13:35','192.168.56.1'),(1000000000142,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 17:23:23','192.168.56.1'),(1000000000143,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:34','192.168.56.1'),(1000000000144,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:41','192.168.56.1'),(1000000000145,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:48','192.168.56.1'),(1000000000146,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:53','192.168.56.1'),(1000000000147,'P005','2019-10-03','11926612309',1,4.55,1,'2019-10-03 19:32:59','192.168.56.1'),(1000000000148,'P005','2019-10-03','11926612309',1,4.55,1,'2019-10-03 19:33:04','192.168.56.1'),(1000000000149,'P004','2019-10-03','11926612309',1,6.78,1,'2019-10-03 20:06:06','192.168.56.1'),(1000000000150,'P004','2019-10-03','11926612309',1,6.66,1,'2019-10-03 20:06:56','192.168.56.1'),(1000000000151,'P004','2019-10-03','11926612309',1,5.89,1,'2019-10-03 20:07:37','192.168.56.1'),(1000000000152,'P0046','2019-10-10','11924910609',1,5.25,1,'2019-10-10 17:25:07','192.168.56.1'),(1000000000153,'P0046','2019-10-10','11924910609',1,4.11,1,'2019-10-10 17:25:58','192.168.56.1'),(1000000000154,'P005','2019-10-10','1192831101001',1,4.55,1,'2019-10-10 19:08:07','192.168.56.1'),(1000000000155,'P005','2019-10-10','1192831101001',1,4.55,0,'2019-10-10 19:08:26','192.168.56.1'),(1000000000156,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:44:18','192.168.56.1'),(1000000000157,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:42','192.168.56.1'),(1000000000158,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:46','192.168.56.1'),(1000000000159,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:49','192.168.56.1'),(1000000000160,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:53','192.168.56.1'),(1000000000161,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:58','192.168.56.1'),(1000000000162,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:46:03','192.168.56.1'),(1000000000163,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:46:06','192.168.56.1'),(1000000000164,'P005','2019-10-24','1192971241001',1,4.95,0,'2019-10-24 22:46:07','192.168.56.1'),(1000000000165,'P005','2019-10-24','1192971241001',1,4.95,0,'2019-10-24 22:46:09','192.168.56.1'),(1000000000166,'P004','2019-10-24','1192971241001',1,5.53,1,'2019-10-24 22:59:35','192.168.56.1'),(1000000000167,'P004','2019-10-24','1192971241001',1,5.53,0,'2019-10-24 23:00:05','192.168.56.1'),(1000000000168,'P004','2019-10-24','1192971241001',1,5.22,0,'2019-10-24 23:03:04','192.168.56.1'),(1000000000169,'P0021','2019-10-24','11924910609',1,10.55,1,'2019-10-25 02:57:41','192.168.56.1'),(1000000000170,'P0021','2019-10-24','11924910609',1,11.20,1,'2019-10-25 03:05:34','192.168.56.1');
/*!40000 ALTER TABLE `barcode` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:53
