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
-- Table structure for table `product_slip_item`
--

DROP TABLE IF EXISTS `product_slip_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_slip_item` (
  `product_slip_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `location_code` int(11) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `seq` int(11) NOT NULL,
  `qty` int(10) DEFAULT NULL,
  `wgh` decimal(12,0) DEFAULT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_slip_no`,`product_code`,`location_code`,`lot_no`),
  KEY `fk_slipitem_product` (`product_code`),
  KEY `fk_slipitem_location` (`location_code`),
  CONSTRAINT `fk_slipitem_location` FOREIGN KEY (`location_code`) REFERENCES `location` (`location_code`),
  CONSTRAINT `fk_slipitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`),
  CONSTRAINT `fk_slipitem_slip` FOREIGN KEY (`product_slip_no`) REFERENCES `product_slip` (`product_slip_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_slip_item`
--

LOCK TABLES `product_slip_item` WRITE;
/*!40000 ALTER TABLE `product_slip_item` DISABLE KEYS */;
INSERT INTO `product_slip_item` VALUES ('PDS0000008','P0021',0,'NA',1,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0022',0,'NA',2,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0023',0,'NA',3,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0024',0,'NA',4,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0025',0,'NA',5,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0026',0,'NA',6,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0027',7,'11924910609',7,0,1,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0028',6,'11924910609',8,0,1,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P003',3,'11924910001',9,1,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0031',0,'NA',10,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0032',0,'NA',11,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0033',0,'NA',12,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0034',0,'NA',13,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0035',0,'NA',14,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000008','P0036',0,'NA',15,0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000009','P002',0,'NA',1,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0021',0,'NA',2,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0022',0,'NA',3,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0024',0,'NA',4,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P003',0,'NA',5,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0031',0,'NA',6,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0032',0,'NA',7,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0033',0,'NA',8,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0034',0,'NA',9,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0035',0,'NA',10,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P0036',0,'NA',11,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P004',0,'NA',12,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000009','P005',0,'NA',13,0,0,'2019-10-02 00:28:12','system',NULL,NULL),('PDS0000010','P0021',0,'NA',1,0,0,'2019-10-04 19:43:00','system',NULL,NULL),('PDS0000010','P0022',0,'NA',2,0,0,'2019-10-04 19:43:00','system',NULL,NULL),('PDS0000010','P0024',0,'NA',3,0,0,'2019-10-04 19:43:00','system',NULL,NULL),('PDS0000010','P0031',0,'NA',4,0,0,'2019-10-04 19:43:00','system',NULL,NULL),('PDS0000010','P0032',0,'NA',5,0,0,'2019-10-04 19:43:00','system',NULL,NULL),('PDS0000011','P002',2,'1192831101001',1,1,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P003',0,'NA',2,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0031',0,'NA',3,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0032',0,'NA',4,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0033',0,'NA',5,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0034',0,'NA',6,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0035',0,'NA',7,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0036',0,'NA',8,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P004',4,'11926612309',9,1,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0041',0,'NA',10,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0042',0,'NA',11,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0043',0,'NA',12,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0044',0,'NA',13,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0045',0,'NA',14,0,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P0046',7,'11924910609',15,0,1,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000011','P005',0,'11926612309',16,1,0,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000013','P0024',0,'NA',3,0,21,'2019-10-24 20:40:23','system',NULL,NULL),('PDS0000013','P0024',8,'A001',1,0,1,'2019-10-24 20:40:23','system',NULL,NULL),('PDS0000013','P0024',8,'A003',2,0,2,'2019-10-24 20:40:23','system',NULL,NULL),('PDS0000013','P0032',0,'NA',4,0,0,'2019-10-24 20:40:23','system',NULL,NULL);
/*!40000 ALTER TABLE `product_slip_item` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:59
