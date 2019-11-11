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
INSERT INTO `barcode` VALUES (1000000000101,'P002','2019-08-07','11924910609',22,1.20,1,'2019-08-10 15:55:51','system'),(1000000000102,'P002','2019-08-07','',141,3.30,1,'2019-08-10 15:55:51','system'),(1000000000103,'P003','2019-08-07','',2,4.30,1,'2019-08-10 15:55:51','system'),(1000000000104,'P004','2019-08-07','',23,2.10,1,'2019-08-10 15:55:51','system'),(1000000000105,'P001','2019-08-07','',12,3.20,1,'2019-08-10 15:55:51','system'),(1000000000106,'P0021','2019-09-21','11924910609',1,12.67,0,'2019-09-21 16:57:13','auto'),(1000000000107,'P0021','2019-09-21','11924910609',1,11.88,0,'2019-09-21 16:58:29','auto'),(1000000000108,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:03:12','auto'),(1000000000109,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:05:11','auto'),(1000000000110,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:29:04','auto'),(1000000000111,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:31:02','auto'),(1000000000112,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:31:39','auto'),(1000000000113,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:33:14','auto'),(1000000000114,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 15:33:51','auto'),(1000000000115,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:36:04','auto'),(1000000000116,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:37:04','auto'),(1000000000117,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:44:26','auto'),(1000000000118,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:45:53','auto'),(1000000000119,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 16:57:32','auto'),(1000000000120,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:01:49','auto'),(1000000000121,'P0021','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:03:25','auto'),(1000000000122,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:05:17','auto'),(1000000000123,'P0028','2019-09-22','11924910609',1,0.22,0,'2019-09-22 17:08:33','auto'),(1000000000124,'P0021','2019-09-22','11924910609',1,0.21,0,'2019-09-22 17:18:58','auto'),(1000000000125,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:20:21','auto'),(1000000000126,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:32:56','auto'),(1000000000127,'P0021','2019-09-22','11924910609',1,1.20,0,'2019-09-22 17:42:41','auto'),(1000000000128,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:50:36','auto'),(1000000000129,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:51:41','auto'),(1000000000130,'P0021','2019-09-22','11924910609',1,0.04,0,'2019-09-22 17:52:52','auto'),(1000000000131,'P0021','2019-09-22','11924910609',1,0.10,0,'2019-09-22 17:57:45','auto'),(1000000000132,'P0021','2019-09-22','11924910609',1,0.09,0,'2019-09-22 17:59:28','auto'),(1000000000133,'P0027','2019-09-22','11924910609',1,0.56,0,'2019-09-22 21:09:37','auto'),(1000000000134,'P0027','2019-09-22','11924910609',1,1.20,0,'2019-09-22 21:14:34','auto'),(1000000000135,'P0028','2019-09-22','11924910609',1,1.20,0,'2019-09-22 21:20:18','auto'),(1000000000136,'P0028','2019-09-22','11924910609',1,1.20,0,'2019-09-22 21:20:35','auto'),(1000000000137,'P0022','2019-09-22','11924910609',1,1.19,0,'2019-09-22 21:20:52','auto'),(1000000000138,'P0021','2019-09-22','11924910609',1,1.19,0,'2019-09-22 21:22:04','auto'),(1000000000139,'P0027','2019-09-23','11924910609',1,1.19,0,'2019-09-23 00:15:12','auto'),(1000000000140,'P005','2019-10-03','11926612309',1,5.25,0,'2019-10-03 16:12:43','192.168.56.1'),(1000000000141,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 17:13:35','192.168.56.1'),(1000000000142,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 17:23:23','192.168.56.1'),(1000000000143,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:34','192.168.56.1'),(1000000000144,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:41','192.168.56.1'),(1000000000145,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:48','192.168.56.1'),(1000000000146,'P005','2019-10-03','11926612309',1,4.55,0,'2019-10-03 19:32:53','192.168.56.1'),(1000000000147,'P005','2019-10-03','11926612309',1,4.55,1,'2019-10-03 19:32:59','192.168.56.1'),(1000000000148,'P005','2019-10-03','11926612309',1,4.55,1,'2019-10-03 19:33:04','192.168.56.1'),(1000000000149,'P004','2019-10-03','11926612309',1,6.78,1,'2019-10-03 20:06:06','192.168.56.1'),(1000000000150,'P004','2019-10-03','11926612309',1,6.66,1,'2019-10-03 20:06:56','192.168.56.1'),(1000000000151,'P004','2019-10-03','11926612309',1,5.89,1,'2019-10-03 20:07:37','192.168.56.1'),(1000000000152,'P0046','2019-10-10','11924910609',1,5.25,1,'2019-10-10 17:25:07','192.168.56.1'),(1000000000153,'P0046','2019-10-10','11924910609',1,4.11,1,'2019-10-10 17:25:58','192.168.56.1'),(1000000000154,'P005','2019-10-10','1192831101001',1,4.55,1,'2019-10-10 19:08:07','192.168.56.1'),(1000000000155,'P005','2019-10-10','1192831101001',1,4.55,0,'2019-10-10 19:08:26','192.168.56.1'),(1000000000156,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:44:18','192.168.56.1'),(1000000000157,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:42','192.168.56.1'),(1000000000158,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:46','192.168.56.1'),(1000000000159,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:49','192.168.56.1'),(1000000000160,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:53','192.168.56.1'),(1000000000161,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:45:58','192.168.56.1'),(1000000000162,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:46:03','192.168.56.1'),(1000000000163,'P005','2019-10-24','1192971241001',1,4.95,1,'2019-10-24 22:46:06','192.168.56.1'),(1000000000164,'P005','2019-10-24','1192971241001',1,4.95,0,'2019-10-24 22:46:07','192.168.56.1'),(1000000000165,'P005','2019-10-24','1192971241001',1,4.95,0,'2019-10-24 22:46:09','192.168.56.1'),(1000000000166,'P004','2019-10-24','1192971241001',1,5.53,1,'2019-10-24 22:59:35','192.168.56.1'),(1000000000167,'P004','2019-10-24','1192971241001',1,5.53,0,'2019-10-24 23:00:05','192.168.56.1'),(1000000000168,'P004','2019-10-24','1192971241001',1,5.22,0,'2019-10-24 23:03:04','192.168.56.1'),(1000000000169,'P0021','2019-10-24','11924910609',1,10.55,1,'2019-10-25 02:57:41','192.168.56.1'),(1000000000170,'P0021','2019-10-24','11924910609',1,11.20,1,'2019-10-25 03:05:34','192.168.56.1'),(1000000000171,'P005','2019-10-24','1192982251001',1,4.95,1,'2019-10-25 15:26:36','192.168.56.1');
/*!40000 ALTER TABLE `barcode` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `bom_item`
--

DROP TABLE IF EXISTS `bom_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bom_item` (
  `bom_code` int(11) NOT NULL,
  `product_code` varchar(45) NOT NULL,
  `mutiply_qty` int(11) DEFAULT '1',
  `mutiply_wgh` decimal(10,2) DEFAULT '1.00',
  PRIMARY KEY (`bom_code`,`product_code`),
  KEY `fk_bomitem_bom_idx` (`product_code`),
  CONSTRAINT `fk_bomitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bom_item`
--

LOCK TABLES `bom_item` WRITE;
/*!40000 ALTER TABLE `bom_item` DISABLE KEYS */;
INSERT INTO `bom_item` VALUES (0,'NA',1,1.00),(2,'P003',1,1.00),(2,'P0031',1,1.00),(2,'P0032',1,1.00),(2,'P0033',1,1.00),(2,'P0034',1,1.00),(2,'P0035',1,1.00),(2,'P0036',1,1.00),(3,'P0041',1,1.00),(3,'P0042',1,1.00),(3,'P0043',1,1.00),(3,'P0044',1,1.00),(3,'P0045',1,1.00),(3,'P0046',1,1.00),(4,'P005',1,1.00),(4,'P0051',1,1.00),(4,'P0052',1,1.00),(4,'P0053',1,1.00),(4,'P0054',1,1.00),(4,'P0055',1,1.00),(5,'P0021',1,1.00),(5,'P0022',1,1.00),(5,'P0023',1,1.00),(5,'P0024',1,1.00),(5,'P0025',1,1.00),(5,'P0026',1,1.00),(5,'P0027',1,1.00),(5,'P0028',1,1.00),(7,'P0021',1,1.00),(7,'P0022',1,1.00),(7,'P0024',1,1.00),(12,'P002',1,1.00),(12,'P003',1,1.00),(12,'P004',1,1.00),(12,'P005',1,1.00),(13,'P002',1,1.00),(13,'P0021',1,1.00),(14,'P0034',1,1.00),(14,'P0044',1,1.00),(14,'P0051',1,1.00),(14,'P0208',1,1.00),(17,'P002',1,1.00),(17,'P003',1,1.00),(17,'P004',1,1.00),(17,'P005',1,1.00);
/*!40000 ALTER TABLE `bom_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `breeder`
--

DROP TABLE IF EXISTS `breeder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `breeder` (
  `breeder_code` int(11) NOT NULL AUTO_INCREMENT,
  `breeder_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`breeder_code`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `breeder`
--

LOCK TABLES `breeder` WRITE;
/*!40000 ALTER TABLE `breeder` DISABLE KEYS */;
INSERT INTO `breeder` VALUES (1,'หมูขาว',1,'2019-06-18 23:05:24','damrong',NULL,NULL);
/*!40000 ALTER TABLE `breeder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `customer_code` varchar(10) NOT NULL,
  `customer_name` varchar(200) NOT NULL,
  `address` varchar(200) NOT NULL,
  `ship_to` varchar(200) NOT NULL,
  `tax_id` varchar(13) DEFAULT NULL,
  `contact_no` varchar(20) DEFAULT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customer_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES ('001','Iron Man','10880 Malibu Point, Florida United Sta\r\n320032','Malibu','1234455587','0981562333',1,'2019-07-03 18:20:28','system','2019-07-20 14:16:45','system'),('002','จอนวิค','1880 สารทร กรุงเทพ 120520','บางรัก','1759000021','0981562200',1,'2019-07-03 15:48:53','system','2019-07-20 14:17:03','system'),('003','สมชาย ใจดี','12/7 ต.นาขวาง อ.เมือง\r\nจ.สมุทรสาคร 75000','โกดัง 15 ท่าเรือมมหาชัย','1254785695','0997847589',1,'2019-07-16 09:42:45','system','2019-07-20 14:05:56','system'),('NAV','Nav Project','11/123 อ.เมืองปราจีนบุรี จ.ปราจีนบุรี 12345','11/123 อ.เมืองปราจีนบุรี จ.ปราจีนบุรี 12345','1234564878','8989899',1,'2019-10-03 20:42:40','system',NULL,NULL),('PKP0001','PKP Inter Foods','609/20 ม.7 ต.ท่าตูม อ.ศรีมหาโพธิ์ จ.ปราจีนบุรี รหัส 25140','609/20 ม.7 ต.ท่าตูม อ.ศรีมหาโพธิ์ จ.ปราจีนบุรี รหัส 25140','1190400033451','0924241955',1,'2019-10-24 23:49:26','system',NULL,NULL);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

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
INSERT INTO `document_generate` VALUES ('BF',0,'2019-10-14 21:49:22',NULL,'ยกมา'),('INV',6,'2019-06-14 19:18:00','2019-10-25 12:25:04','เอกสาร invoice'),('ISS',1,'2019-06-14 19:18:00',NULL,'เอกสารเบิก'),('PDL',1,'2019-06-22 16:17:31',NULL,'product lot no'),('PDS',14,'2019-09-21 17:01:31','2019-10-24 20:40:23','product slip'),('PO',5,'2019-07-03 16:28:14','2019-09-15 08:00:12',NULL),('REV',8,'2019-06-14 19:18:00','2019-10-25 14:58:26','เอกสารรับหมูเป็น'),('SO',38,'2019-06-14 19:18:00','2019-10-25 12:09:10','เอกสาร sales order'),('STK',21,'2019-06-28 18:55:46',NULL,'Stock document no'),('SWL',1,'2019-06-22 15:49:34',NULL,'Lot No รับหมูเป็น'),('TP',4,'2019-10-14 21:49:22',NULL,'?????????????');
/*!40000 ALTER TABLE `document_generate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `farm`
--

DROP TABLE IF EXISTS `farm`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `farm` (
  `farm_code` varchar(10) NOT NULL,
  `farm_name` varchar(200) NOT NULL,
  `address` varchar(500) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`farm_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `farm`
--

LOCK TABLES `farm` WRITE;
/*!40000 ALTER TABLE `farm` DISABLE KEYS */;
INSERT INTO `farm` VALUES ('001','ฟาร์มเอ','120/15 บางใหญ่ กรุงเทพ 10111',0,'2019-06-15 20:30:44','system','2019-10-25 14:56:57','system'),('002','ฟาร์มปราจีน','1/22 นาแก  ทดสอบ',1,'2019-09-22 10:24:21','system','2019-10-25 14:44:27','system'),('003','ฟาร์มทดสอบ','ปปปปปปป',0,'2019-09-23 16:21:42','system','2019-10-25 14:56:52','system'),('004','กสา่ดสกหด','วสากฟหก',0,'2019-10-24 21:55:31','system','2019-10-25 14:56:49','system'),('005','ฟาร์ม หาดสะแก','56 หมู่6 หาดสะแก',1,'2019-10-25 14:56:39','system',NULL,NULL);
/*!40000 ALTER TABLE `farm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice` (
  `invoice_no` varchar(10) NOT NULL,
  `invoice_date` date NOT NULL,
  `ref_document_no` varchar(10) NOT NULL,
  `customer_code` varchar(10) NOT NULL,
  `truck_no` varchar(10) NOT NULL,
  `gross_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `disc_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `disc_amt_bill` decimal(12,2) NOT NULL DEFAULT '0.00',
  `vat_rate` decimal(12,2) NOT NULL DEFAULT '0.00',
  `vat_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `net_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `invoice_flag` int(1) NOT NULL DEFAULT '0' COMMENT '0= Create\n1= Close',
  `comments` varchar(200) DEFAULT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`invoice_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
INSERT INTO `invoice` VALUES ('INV0000002','2019-10-01','SO00000028','002','กก-5800',2240.00,0.00,0.00,0.00,0.00,2240.00,0,'',1,'2019-10-01 22:00:32','system',NULL,NULL),('INV0000003','2019-10-24','SO00000035','001','กก-1234',2576.00,0.00,576.00,0.00,0.00,2000.00,0,'',1,'2019-10-24 20:35:17','system',NULL,NULL),('INV0000004','2019-10-24','SO00000036','PKP0001','2ฒย 791',10598.00,0.00,0.00,0.00,0.00,10598.00,0,'',1,'2019-10-25 02:33:59','system',NULL,NULL),('INV0000005','2019-10-25','SO00000037','PKP0001','2ฒต 3389',4830.00,0.00,200.00,0.00,0.00,4630.00,0,'',1,'2019-10-25 12:25:04','system',NULL,NULL);
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `after_invoice_created` AFTER INSERT ON `invoice` FOR EACH ROW BEGIN
 UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='INV';
 

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `invoice_item`
--

DROP TABLE IF EXISTS `invoice_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice_item` (
  `invoice_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `qty` int(11) NOT NULL DEFAULT '0',
  `wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unit_disc` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unit_net` decimal(10,2) NOT NULL DEFAULT '0.00',
  `disc_amt` decimal(12,2) DEFAULT '0.00',
  `gross_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `net_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `sale_unit_method` varchar(3) NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`invoice_no`,`product_code`),
  KEY `fk_invitem_product_idx` (`product_code`),
  CONSTRAINT `fk_invitem_inv` FOREIGN KEY (`invoice_no`) REFERENCES `invoice` (`invoice_no`),
  CONSTRAINT `fk_invitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_item`
--

LOCK TABLES `invoice_item` WRITE;
/*!40000 ALTER TABLE `invoice_item` DISABLE KEYS */;
INSERT INTO `invoice_item` VALUES ('INV0000002','P004',1,1,7.00,320.00,0.00,0.00,0.00,2240.00,0.00,'W','2019-10-01 22:00:32','system',NULL,NULL),('INV0000003','P0024',1,23,23.00,12.00,0.00,0.00,0.00,276.00,0.00,'W','2019-10-24 20:35:17','system',NULL,NULL),('INV0000003','P0032',2,23,23.00,100.00,0.00,0.00,0.00,2300.00,0.00,'W','2019-10-24 20:35:17','system',NULL,NULL),('INV0000004','0001',1,2,151.40,70.00,0.00,0.00,0.00,10598.00,0.00,'W','2019-10-25 02:33:59','system',NULL,NULL),('INV0000005','0001',1,1,69.00,70.00,0.00,0.00,0.00,4830.00,0.00,'W','2019-10-25 12:25:04','system',NULL,NULL);
/*!40000 ALTER TABLE `invoice_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `location` (
  `location_code` int(11) NOT NULL AUTO_INCREMENT,
  `location_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`location_code`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `location`
--

LOCK TABLES `location` WRITE;
/*!40000 ALTER TABLE `location` DISABLE KEYS */;
INSERT INTO `location` VALUES (0,'NA',1,'2019-09-21 17:33:30','system',NULL,NULL),(1,'ลานพักหมูเป็น',1,'2019-06-22 15:10:45','system',NULL,NULL),(2,'ห้องเก็บหมุซีก',1,'2019-06-29 20:53:54','system',NULL,NULL),(3,'ห้องเก็บเครื่องในแดง',1,'2019-06-29 20:53:54','system',NULL,NULL),(4,'ห้องเก็บเครื่องในขาว',1,'2019-06-29 20:53:54','system',NULL,NULL),(5,'ห้องเก็บชิ้นส่วน1',1,'2019-06-29 20:53:54','system',NULL,NULL),(6,'ห้องเก็บชิ้นส่วน2',1,'2019-06-29 20:53:54','system',NULL,NULL),(7,'ห้องตัดแต่ง',1,'2019-06-29 20:53:54','system',NULL,NULL),(8,'ห้องเก็บหัว',1,'2019-06-29 20:53:54','system',NULL,NULL);
/*!40000 ALTER TABLE `location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_no` varchar(10) NOT NULL,
  `order_date` date NOT NULL,
  `customer_code` varchar(10) NOT NULL,
  `order_flag` int(1) NOT NULL DEFAULT '0' COMMENT '0= Create\n1= Close',
  `invoice_flag` int(1) NOT NULL DEFAULT '0' COMMENT '0= inv not use 1= Inv use',
  `comments` varchar(200) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`order_no`),
  KEY `fk_order_customer_idx` (`customer_code`),
  CONSTRAINT `fk_order_customer` FOREIGN KEY (`customer_code`) REFERENCES `customer` (`customer_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('SO00000022','2019-09-23','001',0,0,'zz',1,'2019-09-23 14:35:52','system',NULL,NULL),('SO00000023','2019-09-28','001',0,0,'',0,'2019-09-28 13:46:01','system','2019-09-28 13:47:23','system'),('SO00000024','2019-09-29','002',0,0,'',1,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000025','2019-09-29','001',0,0,'dfg',1,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000026','2019-09-30','001',0,0,'ป',1,'2019-09-30 11:10:57','system','2019-09-30 11:17:58','system'),('SO00000027','2019-10-01','003',0,1,'',0,'2019-10-01 19:32:11','system',NULL,NULL),('SO00000028','2019-10-01','002',0,1,'xxx',1,'2019-10-01 21:59:11','system','2019-10-01 21:59:33','system'),('SO00000029','2019-10-02','001',0,0,'       ',1,'2019-10-02 00:27:15','system','2019-10-02 00:27:56','system'),('SO00000030','2019-10-03','NAV',0,0,'ทดสอบ',1,'2019-10-03 20:44:34','system',NULL,NULL),('SO00000031','2019-10-04','001',0,0,'sd',1,'2019-10-04 19:42:47','system',NULL,NULL),('SO00000032','2019-10-10','001',0,0,'',1,'2019-10-10 19:18:10','system','2019-10-10 19:26:54','system'),('SO00000033','2019-10-20','001',0,0,'zxzxzxzx',1,'2019-10-19 15:19:00','system',NULL,NULL),('SO00000034','2019-10-22','001',0,0,'ASD',1,'2019-10-22 19:35:26','system',NULL,NULL),('SO00000035','2019-10-24','001',0,1,'As',1,'2019-10-24 19:29:05','system',NULL,NULL),('SO00000036','2019-10-24','PKP0001',0,1,'ทดสอบ',1,'2019-10-25 00:31:38','system',NULL,NULL),('SO00000037','2019-10-25','PKP0001',0,1,'',1,'2019-10-25 12:09:10','system',NULL,NULL);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `after_order_created` AFTER INSERT ON `orders` FOR EACH ROW BEGIN
	UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='SO';
	

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `orders_item`
--

DROP TABLE IF EXISTS `orders_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders_item` (
  `order_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `bom_code` int(11) NOT NULL DEFAULT '0',
  `seq` int(11) NOT NULL,
  `order_qty` int(11) NOT NULL DEFAULT '0',
  `order_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unload_qty` int(11) NOT NULL DEFAULT '0',
  `unload_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `order_set_qty` int(11) DEFAULT '0',
  `order_set_wgh` decimal(10,2) DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`order_no`,`product_code`,`bom_code`),
  KEY `fk_order_product_idx` (`product_code`),
  CONSTRAINT `fk_order_orderitem` FOREIGN KEY (`order_no`) REFERENCES `orders` (`order_no`),
  CONSTRAINT `fk_order_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders_item`
--

LOCK TABLES `orders_item` WRITE;
/*!40000 ALTER TABLE `orders_item` DISABLE KEYS */;
INSERT INTO `orders_item` VALUES ('SO00000022','P009',0,1,3,0.00,0,0.00,0,0.00,'2019-09-23 14:35:52','system',NULL,NULL),('SO00000023','P0021',5,1,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0022',5,2,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0023',5,3,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0024',5,4,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0025',5,5,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0026',5,6,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0027',5,7,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000023','P0028',5,8,2,0.00,0,0.00,2,0.00,'2019-09-28 13:47:23','system',NULL,NULL),('SO00000024','P0021',5,1,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0022',5,2,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0023',5,3,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0024',5,4,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0025',5,5,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0026',5,6,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0027',5,7,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000024','P0028',5,8,1,0.00,0,0.00,1,0.00,'2019-09-29 01:08:54','system',NULL,NULL),('SO00000025','P003',2,1,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0031',2,2,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0032',0,8,0,45.00,0,0.00,0,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0032',2,3,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0033',2,4,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0034',2,5,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0035',2,6,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000025','P0036',2,7,4,0.00,0,0.00,4,0.00,'2019-09-29 10:02:00','system',NULL,NULL),('SO00000026','P0021',5,9,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0021',7,17,1,1.00,0,0.00,1,110.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0022',5,10,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0022',7,18,1,1.00,0,0.00,1,110.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0023',5,11,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0024',5,12,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0024',7,19,1,1.00,0,0.00,1,110.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0025',5,13,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0026',5,14,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0027',5,15,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0028',5,16,1,1.00,0,0.00,1,1168.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P003',2,2,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0031',2,3,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0032',0,1,1,1.00,0,0.00,0,0.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0032',2,4,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0033',2,5,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0034',2,6,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0035',2,7,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000026','P0036',2,8,1,1.00,0,0.00,1,1.00,'2019-09-30 11:17:58','system',NULL,NULL),('SO00000027','P002',12,1,1,1168.00,1,1168.00,1,1.00,'2019-10-01 19:32:11','system',NULL,NULL),('SO00000027','P003',12,2,1,1.00,1,1.00,1,1.00,'2019-10-01 19:32:11','system',NULL,NULL),('SO00000027','P004',12,3,1,1.00,1,1.00,1,1.00,'2019-10-01 19:32:11','system',NULL,NULL),('SO00000027','P005',12,4,1,1.00,1,1.00,1,1.00,'2019-10-01 19:32:11','system',NULL,NULL),('SO00000028','P004',3,1,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000028','P0041',3,2,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000028','P0042',3,3,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000028','P0043',3,4,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000028','P0044',3,5,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000028','P0045',3,6,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000028','P0046',3,7,1,1.00,1,1.00,1,1.00,'2019-10-01 21:59:33','system',NULL,NULL),('SO00000029','P002',12,15,1,1168.00,1,75.90,1,1.00,'2019-10-02 00:27:56','system','2019-10-03 00:12:43','auto'),('SO00000029','P0021',7,11,2,2.00,0,0.00,2,220.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0022',7,12,2,2.00,0,0.00,2,220.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0024',0,1,3,3.00,0,0.00,0,0.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0024',7,13,2,2.00,0,0.00,2,220.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P003',2,4,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P003',12,16,1,1.00,0,0.00,1,1.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0031',0,2,1,1.00,0,0.00,0,0.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0031',2,5,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0032',0,3,1,1.00,0,0.00,0,0.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0032',2,6,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0033',2,7,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0034',2,8,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0035',2,9,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P0036',2,10,2,2.00,0,0.00,2,2.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P004',12,17,1,1.00,0,0.00,1,1.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000029','P005',12,18,1,1.00,0,0.00,1,1.00,'2019-10-02 00:27:56','system',NULL,NULL),('SO00000030','P004',12,3,2,2.00,0,0.00,2,2.00,'2019-10-03 20:44:34','system',NULL,NULL),('SO00000030','P005',12,4,2,2.00,0,0.00,2,2.00,'2019-10-03 20:44:34','system',NULL,NULL),('SO00000031','P0021',7,1,1,1.00,0,0.00,1,110.00,'2019-10-04 19:42:47','system',NULL,NULL),('SO00000031','P0022',7,2,1,1.00,0,0.00,1,110.00,'2019-10-04 19:42:47','system',NULL,NULL),('SO00000031','P0024',7,3,1,1.00,0,0.00,1,110.00,'2019-10-04 19:42:47','system',NULL,NULL),('SO00000031','P0031',0,4,23,23.00,0,0.00,0,0.00,'2019-10-04 19:42:47','system',NULL,NULL),('SO00000031','P0032',0,5,25,25.00,0,0.00,0,0.00,'2019-10-04 19:42:47','system',NULL,NULL),('SO00000032','P002',12,1,1,95.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P003',2,5,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P003',12,2,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0031',2,6,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0032',2,7,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0033',2,8,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0034',2,9,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0035',2,10,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0036',2,11,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P004',12,3,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0041',3,12,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0042',3,13,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0043',3,14,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0044',3,15,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0045',3,16,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P0046',3,17,1,1.00,0,0.00,1,1.00,'2019-10-10 19:26:54','system',NULL,NULL),('SO00000032','P005',12,4,1,1.00,1,4.55,2,5.55,'2019-10-10 19:26:54','system','2019-10-15 01:02:55','192.168.56.1'),('SO00000033','P0024',0,2,3,3.00,0,0.00,0,0.00,'2019-10-19 15:19:00','system',NULL,NULL),('SO00000033','P0032',0,1,34,34.00,0,0.00,0,0.00,'2019-10-19 15:19:00','system',NULL,NULL),('SO00000034','P009',0,1,3,3.00,0,0.00,0,0.00,'2019-10-22 19:35:26','system',NULL,NULL),('SO00000035','P0024',0,2,23,23.00,23,23.00,0,0.00,'2019-10-24 19:29:05','system',NULL,NULL),('SO00000035','P0032',0,1,23,23.00,23,23.00,0,0.00,'2019-10-24 19:29:05','system',NULL,NULL),('SO00000036','P002',17,1,2,190.00,2,130.75,2,130.00,'2019-10-25 00:31:38','system','2019-10-25 01:04:08','192.168.56.1'),('SO00000036','P003',17,2,2,2.00,0,0.00,2,130.00,'2019-10-25 00:31:38','system',NULL,NULL),('SO00000036','P004',17,3,2,2.00,2,10.75,2,130.00,'2019-10-25 00:31:38','system','2019-10-25 02:12:31','192.168.56.1'),('SO00000036','P005',17,4,2,2.00,2,9.90,2,130.00,'2019-10-25 00:31:38','system','2019-10-25 02:25:04','192.168.56.1'),('SO00000037','P002',17,1,3,285.00,1,69.00,3,195.00,'2019-10-25 12:09:10','system','2019-10-25 12:19:04','192.168.56.1'),('SO00000037','P003',17,2,3,3.00,0,0.00,3,195.00,'2019-10-25 12:09:10','system',NULL,NULL),('SO00000037','P004',17,3,3,3.00,0,0.00,3,195.00,'2019-10-25 12:09:10','system',NULL,NULL),('SO00000037','P005',17,4,3,3.00,0,0.00,3,195.00,'2019-10-25 12:09:10','system',NULL,NULL);
/*!40000 ALTER TABLE `orders_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plant`
--

DROP TABLE IF EXISTS `plant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plant` (
  `plant_id` int(11) NOT NULL AUTO_INCREMENT,
  `production_date` date NOT NULL,
  `plant_name` varchar(100) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `est_no` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`plant_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plant`
--

LOCK TABLES `plant` WRITE;
/*!40000 ALTER TABLE `plant` DISABLE KEYS */;
INSERT INTO `plant` VALUES (1,'2019-10-24','บริษัท พี.เค.พี 6 จำกัด','85/1 หมู่ 1 ตำบลไม้เค็ด อำเภอเมืองปราจีนบุรี จ.ปราจีนบุรี 25230',NULL);
/*!40000 ALTER TABLE `plant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `product_code` varchar(10) NOT NULL,
  `product_name` varchar(200) NOT NULL,
  `product_group_code` int(11) NOT NULL,
  `unit_of_qty` int(11) NOT NULL,
  `unit_of_wgh` int(11) NOT NULL,
  `min_weight` decimal(10,2) DEFAULT '0.00',
  `max_weight` decimal(10,2) DEFAULT '0.00',
  `std_yield` decimal(10,2) DEFAULT '0.00',
  `sale_unit_method` varchar(1) NOT NULL,
  `issue_unit_method` varchar(1) NOT NULL,
  `shelflife` int(3) DEFAULT NULL,
  `packing_size` decimal(10,2) DEFAULT '1.00',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_code`),
  KEY `fk_product_group_idx` (`product_group_code`),
  KEY `fk_unit_qty_idx` (`unit_of_qty`),
  KEY `fk_unit_wgh_idx` (`unit_of_wgh`),
  CONSTRAINT `fk_product_group` FOREIGN KEY (`product_group_code`) REFERENCES `product_group` (`product_group_code`),
  CONSTRAINT `fk_unit_qty` FOREIGN KEY (`unit_of_qty`) REFERENCES `unit_of_measurement` (`unit_code`),
  CONSTRAINT `fk_unit_wgh` FOREIGN KEY (`unit_of_wgh`) REFERENCES `unit_of_measurement` (`unit_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('0001','หมูซีก รวมหัวเครื่องใน',7,7,4,60.00,90.00,65.00,'W','Q',NULL,65.00,1,'2019-10-25 00:00:18','system',NULL,NULL),('NA','NA',1,1,1,0.00,0.00,0.00,'W','Q',0,1.00,0,'2019-08-11 12:24:32','system',NULL,NULL),('P001','หมูเป็น',1,1,4,60.00,150.00,100.00,'W','Q',60,100.00,0,'2019-06-22 14:52:35','system','2019-10-25 14:46:39','system'),('P002','หมูซีก',1,2,4,40.00,130.00,78.50,'W','Q',60,110.00,1,'2019-06-22 14:53:11','system','2019-10-25 14:48:10','system'),('P0021','สะโพก- Raw',5,4,4,0.00,0.00,0.00,'W','W',60,65.00,1,'2019-06-22 14:53:11','system','2019-09-29 00:25:24','system'),('P0022','สามชั้น- Raw',5,4,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-09-23 11:34:42','system'),('P0023','เนื้อไหล่- Raw',5,4,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-09-23 11:34:51','system'),('P0024','สันนอก- Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0025','สันคอ- Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0026','ซี่โครงแผ่น - Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0027','สันใน- Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0028','คอหมูย่าง- Raw',1,5,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-10-24 19:46:40','system'),('P003','เครื่องในแดง-ชุด',6,7,4,0.00,0.00,3.83,'W','Q',60,1.00,1,'2019-06-23 15:18:30','system','2019-10-10 19:25:57','system'),('P0031','ตับ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0032','ปอด',6,8,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-09-23 13:30:30','system'),('P0033','หัวใจ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0034','ขั้วตับ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0035','ม้าม',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0036','ไต',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-10-24 19:36:20','system'),('P004','เครื่องในขาว-ชุด',6,7,4,0.50,7.00,5.17,'W','Q',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-10 19:25:08','system'),('P0041','ไส้อ่อน',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0042','ไส้ขม',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-24 19:36:29','system'),('P0043','ไส้ใหญ่',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0044','กระเพาะ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0045','เศษมัน',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0046','ไส้ตัน',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P005','หัวหมู',6,7,4,0.50,5.00,5.00,'W','Q',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-24 19:36:36','system'),('P0051','กระโหลก',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0052','หน้ากาก',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0053','ลิ้น',1,5,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-24 19:46:47','system'),('P0054','เศษมันคอ',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0055','เนื้อแก้ม',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P009','หมูชุด ซีก+หัว+เครื่องใน+เลือด',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:13:01','system','2019-10-24 19:34:30','system'),('P010','หมูชุด ซีก+หัว+เครื่องใน+เลือด ขึ้นโครง',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:13:55','system','2019-10-24 19:34:46','system'),('P011','หมูชุด ไม่หัว ไม่เครื่องใน',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:14:52','system','2019-10-24 19:35:52','system'),('P012','หมูชุด ไม่หัว ไม่เครื่องใน (ขึ้นโครง)',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:16:07','system','2019-10-24 19:35:42','system'),('P0201','สามชั้นแผ่นตัดเส้น',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:37:13','system',NULL,NULL),('P0202','สามชั้นแผ่นสไลด์ ชาบู',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:38:55','system',NULL,NULL),('P0203','สันนอกแผ่นสไลด์ ชาบู',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:44:51','system',NULL,NULL),('P0204','สันคอแผ่นสไลด์ ชาบู',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:45:36','system',NULL,NULL),('P0205','สันคอสเต็ก',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:46:06','system',NULL,NULL),('P0206','สันนอกสเต็ก',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:46:49','system',NULL,NULL),('P0207','เนื้อหมูสไลด์',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:48:21','system',NULL,NULL),('P0208','คอหมูย่าง',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:48:47','system',NULL,NULL),('P0209','หมูบด 10% 1 kg',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:49:34','system',NULL,NULL),('P0210','หมูบด 20% 1 kg',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:50:19','system',NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_group`
--

DROP TABLE IF EXISTS `product_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_group` (
  `product_group_code` int(11) NOT NULL AUTO_INCREMENT,
  `product_group_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_group_code`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_group`
--

LOCK TABLES `product_group` WRITE;
/*!40000 ALTER TABLE `product_group` DISABLE KEYS */;
INSERT INTO `product_group` VALUES (1,'Raw Product',1,'2019-06-22 14:48:42','system','2019-09-20 15:13:25','system'),(5,'เนื้อหลัก',1,'2019-09-23 10:16:30','system','2019-10-24 23:54:38','system'),(6,'เครื่องในแดง',1,'2019-09-23 10:33:25','system','2019-10-24 23:54:02','system'),(7,'สินค้าหลัก',1,'2019-10-24 19:38:20','system','2019-10-24 23:53:08','system'),(8,'เครื่องในขาว',1,'2019-10-24 23:54:10','system',NULL,NULL),(9,'มันและหนัง',1,'2019-10-24 23:54:21','system',NULL,NULL),(10,'กระดูก',1,'2019-10-24 23:54:28','system',NULL,NULL);
/*!40000 ALTER TABLE `product_group` ENABLE KEYS */;
UNLOCK TABLES;

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

--
-- Table structure for table `product_slip`
--

DROP TABLE IF EXISTS `product_slip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_slip` (
  `product_slip_no` varchar(10) NOT NULL,
  `product_slip_date` date NOT NULL,
  `ref_document_no` varchar(10) NOT NULL,
  `product_slip_flag` int(1) NOT NULL DEFAULT '0' COMMENT '''0= Create\\\\n1= Close''',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_slip_no`),
  KEY `fk_product_slip_order` (`ref_document_no`),
  CONSTRAINT `fk_product_slip_order` FOREIGN KEY (`ref_document_no`) REFERENCES `orders` (`order_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_slip`
--

LOCK TABLES `product_slip` WRITE;
/*!40000 ALTER TABLE `product_slip` DISABLE KEYS */;
INSERT INTO `product_slip` VALUES ('PDS0000008','2019-09-30','SO00000026',0,0,'2019-09-30 19:25:35','system',NULL,NULL),('PDS0000009','2019-10-02','SO00000029',0,1,'2019-10-02 00:28:11','system',NULL,NULL),('PDS0000010','2019-10-04','SO00000031',0,1,'2019-10-04 19:43:00','system',NULL,NULL),('PDS0000011','2019-10-10','SO00000032',0,1,'2019-10-10 19:43:07','system',NULL,NULL),('PDS0000012','2019-10-22','SO00000034',0,1,'2019-10-22 19:36:59','system',NULL,NULL),('PDS0000013','2019-10-24','SO00000035',0,1,'2019-10-24 20:40:23','system',NULL,NULL);
/*!40000 ALTER TABLE `product_slip` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `product_slip_AFTER_INSERT` AFTER INSERT ON `product_slip` FOR EACH ROW BEGIN
	UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='PDS'; 
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

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

--
-- Table structure for table `production_order`
--

DROP TABLE IF EXISTS `production_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production_order` (
  `po_no` varchar(10) NOT NULL,
  `po_date` date NOT NULL,
  `po_flag` int(1) NOT NULL DEFAULT '0' COMMENT '0= Create\n1= Close',
  `comments` varchar(200) DEFAULT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`po_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_order`
--

LOCK TABLES `production_order` WRITE;
/*!40000 ALTER TABLE `production_order` DISABLE KEYS */;
INSERT INTO `production_order` VALUES ('PO00000001','2019-09-10',0,'323232',1,'2019-09-10 19:32:43','system',NULL,NULL),('PO00000002','2019-09-15',0,'dsddfdsf',0,'2019-09-15 07:59:28','system',NULL,NULL),('PO00000003','2019-09-15',0,'esdf',1,'2019-09-15 07:59:58','system',NULL,NULL),('PO00000004','2019-09-15',0,'sddsdds',1,'2019-09-15 08:00:12','system',NULL,NULL);
/*!40000 ALTER TABLE `production_order` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `after_production_order_created` AFTER INSERT ON `production_order` FOR EACH ROW BEGIN
 UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='PO';
 

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `production_order_item`
--

DROP TABLE IF EXISTS `production_order_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production_order_item` (
  `po_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `po_qty` int(11) NOT NULL DEFAULT '0',
  `po_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unload_qty` int(11) NOT NULL DEFAULT '0',
  `unload_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`po_no`,`product_code`),
  KEY `fk_porderitem_product_idx` (`product_code`),
  CONSTRAINT `fk_porderitem_order` FOREIGN KEY (`po_no`) REFERENCES `production_order` (`po_no`),
  CONSTRAINT `fk_porderitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_order_item`
--

LOCK TABLES `production_order_item` WRITE;
/*!40000 ALTER TABLE `production_order_item` DISABLE KEYS */;
INSERT INTO `production_order_item` VALUES ('PO00000001','P003',1,23,0.00,0,0.00,'2019-09-10 19:32:43','system',NULL,NULL),('PO00000002','P001',1,34,0.00,0,0.00,'2019-09-15 07:59:29','system',NULL,NULL),('PO00000003','P001',1,4,0.00,0,0.00,'2019-09-15 07:59:58','system',NULL,NULL),('PO00000004','P001',1,545,0.00,0,0.00,'2019-09-15 08:00:12','system',NULL,NULL);
/*!40000 ALTER TABLE `production_order_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receive_item`
--

DROP TABLE IF EXISTS `receive_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `receive_item` (
  `receive_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `sex_flag` varchar(1) NOT NULL DEFAULT 'F',
  `receive_qty` int(11) NOT NULL DEFAULT '0',
  `receive_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `chill_qty` int(11) DEFAULT '0',
  `chill_wgh` decimal(10,2) DEFAULT '0.00',
  `transfer_qty` int(11) NOT NULL DEFAULT '0',
  `transfer_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `barcode_no` bigint(13) NOT NULL DEFAULT '0',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`receive_no`,`product_code`,`seq`),
  KEY `fk_receives_02_idx` (`product_code`),
  CONSTRAINT `fk_receives_01` FOREIGN KEY (`receive_no`) REFERENCES `receives` (`receive_no`),
  CONSTRAINT `fk_receives_02` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receive_item`
--

LOCK TABLES `receive_item` WRITE;
/*!40000 ALTER TABLE `receive_item` DISABLE KEYS */;
INSERT INTO `receive_item` VALUES ('REV0000001','P001',1,'11924910609','F',1,100.00,0,0.00,0,0.00,0,'2019-09-07 19:57:20','auto',NULL,NULL),('REV0000001','P001',2,'11924910609','F',1,100.00,0,0.00,0,0.00,0,'2019-09-07 20:00:20','auto',NULL,NULL),('REV0000001','P001',3,'11924910609','F',1,100.00,0,0.00,0,0.00,0,'2019-09-07 20:01:37','auto',NULL,NULL),('REV0000001','P001',4,'11924910609','F',1,100.00,0,0.00,0,0.00,0,'2019-09-07 20:01:50','auto',NULL,NULL),('REV0000001','P001',5,'11924910609','F',1,100.00,0,0.00,0,0.00,0,'2019-09-07 20:01:55','auto',NULL,NULL),('REV0000001','P002',1,'11924910609','',1,80.23,1,75.50,0,0.00,0,'2019-09-07 20:43:59','auto','2019-10-02 23:36:24','auto'),('REV0000001','P002',2,'11924910609','',1,80.23,1,78.50,0,0.00,0,'2019-09-07 20:44:37','auto','2019-10-02 23:49:00','auto'),('REV0000001','P002',3,'11924910609','',1,80.23,1,75.90,0,0.00,0,'2019-09-07 20:44:49','auto','2019-10-03 00:12:43','auto'),('REV0000001','P002',4,'11924910609','',1,80.23,1,65.50,0,0.00,0,'2019-09-07 20:44:52','auto','2019-10-09 18:30:27','192.168.56.1'),('REV0000001','P002',5,'11924910609','',1,80.23,1,66.50,0,0.00,0,'2019-09-07 20:44:54','auto','2019-10-09 18:47:23','192.168.56.1'),('REV0000001','P0021',1,'11924910609','',1,12.67,NULL,NULL,0,0.00,0,'2019-09-21 16:57:13','auto',NULL,NULL),('REV0000001','P0021',2,'11924910609','',1,11.88,NULL,NULL,0,0.00,0,'2019-09-21 16:58:29','auto',NULL,NULL),('REV0000001','P0021',3,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:03:12','auto',NULL,NULL),('REV0000001','P0021',4,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:05:11','auto',NULL,NULL),('REV0000001','P0021',5,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:29:04','auto',NULL,NULL),('REV0000001','P0021',6,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:31:02','auto',NULL,NULL),('REV0000001','P0021',7,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:31:39','auto',NULL,NULL),('REV0000001','P0021',8,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 16:36:04','auto',NULL,NULL),('REV0000001','P0021',9,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 16:37:04','auto',NULL,NULL),('REV0000001','P0021',10,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 16:44:26','auto',NULL,NULL),('REV0000001','P0021',11,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 16:45:53','auto',NULL,NULL),('REV0000001','P0021',12,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 16:57:32','auto',NULL,NULL),('REV0000001','P0021',13,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 17:01:49','auto',NULL,NULL),('REV0000001','P0021',14,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 17:03:25','auto',NULL,NULL),('REV0000001','P0021',15,'11924910609','',1,0.21,NULL,NULL,0,0.00,0,'2019-09-22 17:18:58','auto',NULL,NULL),('REV0000001','P0021',16,'11924910609','',1,0.09,NULL,NULL,0,0.00,0,'2019-09-22 17:20:21','auto',NULL,NULL),('REV0000001','P0021',17,'11924910609','',1,0.09,NULL,NULL,0,0.00,0,'2019-09-22 17:32:56','auto',NULL,NULL),('REV0000001','P0021',18,'11924910609','',1,1.20,NULL,NULL,0,0.00,0,'2019-09-22 17:42:41','auto',NULL,NULL),('REV0000001','P0021',19,'11924910609','',1,0.09,NULL,NULL,0,0.00,0,'2019-09-22 17:50:36','auto',NULL,NULL),('REV0000001','P0021',20,'11924910609','',1,0.09,NULL,NULL,0,0.00,0,'2019-09-22 17:51:41','auto',NULL,NULL),('REV0000001','P0021',21,'11924910609','',1,0.04,NULL,NULL,0,0.00,0,'2019-09-22 17:52:52','auto',NULL,NULL),('REV0000001','P0021',22,'11924910609','',1,0.10,NULL,NULL,0,0.00,0,'2019-09-22 17:57:45','auto',NULL,NULL),('REV0000001','P0021',23,'11924910609','',1,0.09,NULL,NULL,0,0.00,0,'2019-09-22 17:59:28','auto',NULL,NULL),('REV0000001','P0021',24,'11924910609','',1,1.19,NULL,NULL,0,0.00,0,'2019-09-22 21:22:04','auto',NULL,NULL),('REV0000001','P0022',1,'11924910609','',1,1.19,NULL,NULL,0,0.00,0,'2019-09-22 21:20:52','auto',NULL,NULL),('REV0000001','P0027',1,'11924910609','',1,0.56,NULL,NULL,0,0.00,0,'2019-09-22 21:09:37','auto',NULL,NULL),('REV0000001','P0027',2,'11924910609','',1,1.20,NULL,NULL,0,0.00,0,'2019-09-22 21:14:34','auto',NULL,NULL),('REV0000001','P0027',3,'11924910609','',1,1.19,NULL,NULL,0,0.00,0,'2019-09-23 00:15:12','auto',NULL,NULL),('REV0000001','P0028',1,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:33:14','auto',NULL,NULL),('REV0000001','P0028',2,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 15:33:51','auto',NULL,NULL),('REV0000001','P0028',3,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 17:05:17','auto',NULL,NULL),('REV0000001','P0028',4,'11924910609','',1,0.22,NULL,NULL,0,0.00,0,'2019-09-22 17:08:33','auto',NULL,NULL),('REV0000001','P0028',5,'11924910609','',1,1.20,NULL,NULL,0,0.00,1000000000139,'2019-09-22 21:20:18','auto',NULL,NULL),('REV0000001','P0028',6,'11924910609','',1,1.20,NULL,NULL,0,0.00,1000000000138,'2019-09-22 21:20:35','auto',NULL,NULL),('REV0000002','P001',1,'11926512209','F',1,1.20,0,0.00,0,0.00,0,'2019-09-23 16:12:40','auto',NULL,NULL),('REV0000003','P001',1,'11926612309','F',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:26:18','auto',NULL,NULL),('REV0000003','P001',2,'11926612309','F',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:28:10','auto',NULL,NULL),('REV0000003','P001',3,'11926612309','M',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:29:15','auto',NULL,NULL),('REV0000003','P001',4,'11926612309','M',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:29:27','auto',NULL,NULL),('REV0000003','P001',5,'11926612309','M',1,1.20,0,0.00,0,0.00,0,'2019-09-23 16:29:52','auto',NULL,NULL),('REV0000003','P001',6,'11926612309','F',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:55:29','auto',NULL,NULL),('REV0000003','P001',7,'11926612309','F',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:58:05','auto',NULL,NULL),('REV0000003','P001',8,'11926612309','M',1,1.19,0,0.00,0,0.00,0,'2019-09-23 16:59:27','auto',NULL,NULL),('REV0000003','P001',9,'11926612309','F',1,1.19,0,0.00,0,0.00,0,'2019-09-23 17:03:09','auto',NULL,NULL),('REV0000003','P001',10,'11926612309','F',1,1.19,0,0.00,0,0.00,0,'2019-09-23 17:03:30','auto',NULL,NULL),('REV0000003','P002',1,'11926612309','',1,11.96,1,67.12,1,67.12,0,'2019-09-24 19:35:24','auto','2019-10-09 18:48:05','192.168.56.1'),('REV0000003','P002',2,'11926612309','',1,11.94,1,69.00,1,69.00,0,'2019-09-24 19:38:30','auto','2019-10-25 12:19:04','192.168.56.1'),('REV0000003','P002',3,'11926612309','',1,11.96,0,0.00,0,0.00,0,'2019-09-24 19:38:50','auto',NULL,NULL),('REV0000003','P002',4,'11926612309','',1,11.94,0,0.00,0,0.00,0,'2019-09-24 19:41:44','auto',NULL,NULL),('REV0000003','P002',5,'11926612309','',1,6.98,0,0.00,0,0.00,0,'2019-09-24 19:42:14','auto',NULL,NULL),('REV0000003','P002',6,'11926612309','',1,17.56,0,0.00,0,0.00,0,'2019-09-24 19:45:20','auto',NULL,NULL),('REV0000003','P002',7,'11926612309','',1,2.50,0,0.00,0,0.00,0,'2019-09-26 21:46:22','auto',NULL,NULL),('REV0000003','P002',8,'11926612309','',1,2.50,0,0.00,0,0.00,0,'2019-09-26 21:46:31','auto',NULL,NULL),('REV0000003','P002',9,'11926612309','',1,2.50,0,0.00,0,0.00,0,'2019-09-26 21:46:40','auto',NULL,NULL),('REV0000003','P002',10,'11926612309','',1,2.50,0,0.00,0,0.00,0,'2019-09-26 21:46:49','auto',NULL,NULL),('REV0000003','P004',1,'11926612309','',1,6.78,0,0.00,0,0.00,1000000000149,'2019-10-03 20:06:06','192.168.56.1',NULL,NULL),('REV0000003','P004',2,'11926612309','',1,6.66,0,0.00,0,0.00,1000000000150,'2019-10-03 20:06:56','192.168.56.1',NULL,NULL),('REV0000003','P004',3,'11926612309','',1,5.89,0,0.00,0,0.00,1000000000151,'2019-10-03 20:07:37','192.168.56.1',NULL,NULL),('REV0000003','P005',1,'11926612309','',1,5.25,NULL,NULL,0,0.00,1000000000140,'2019-10-03 16:12:43','192.168.56.1',NULL,NULL),('REV0000003','P005',2,'11926612309','',1,4.95,0,0.00,0,0.00,0,'2019-10-03 16:59:04','auto',NULL,NULL),('REV0000003','P005',3,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000141,'2019-10-03 17:13:35','192.168.56.1',NULL,NULL),('REV0000003','P005',4,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000142,'2019-10-03 17:23:23','192.168.56.1',NULL,NULL),('REV0000003','P005',5,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000143,'2019-10-03 19:32:34','192.168.56.1',NULL,NULL),('REV0000003','P005',6,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000144,'2019-10-03 19:32:41','192.168.56.1',NULL,NULL),('REV0000003','P005',7,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000145,'2019-10-03 19:32:48','192.168.56.1',NULL,NULL),('REV0000003','P005',8,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000146,'2019-10-03 19:32:53','192.168.56.1',NULL,NULL),('REV0000003','P005',9,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000147,'2019-10-03 19:32:59','192.168.56.1',NULL,NULL),('REV0000003','P005',10,'11926612309','',1,4.55,0,0.00,0,0.00,1000000000148,'2019-10-03 19:33:04','192.168.56.1',NULL,NULL),('REV0000004','P001',1,'1192831101001','F',1,78.00,0,0.00,0,0.00,0,'2019-10-10 18:49:12','192.168.56.1',NULL,NULL),('REV0000004','P001',2,'1192831101001','F',1,77.00,0,0.00,0,0.00,0,'2019-10-10 18:51:16','192.168.56.1',NULL,NULL),('REV0000004','P002',1,'1192831101001','',1,65.00,0,0.00,0,0.00,0,'2019-10-10 18:57:58','192.168.56.1',NULL,NULL),('REV0000004','P005',1,'1192831101001','',1,4.55,0,0.00,0,0.00,1000000000154,'2019-10-10 19:08:07','192.168.56.1',NULL,NULL),('REV0000004','P005',2,'1192831101001','',1,4.55,0,0.00,0,0.00,1000000000155,'2019-10-10 19:08:26','192.168.56.1',NULL,NULL),('REV0000005','P001',1,'1192971241001','F',1,95.00,0,0.00,0,0.00,0,'2019-10-24 21:47:25','192.168.56.1',NULL,NULL),('REV0000005','P001',2,'1192971241001','F',1,95.50,0,0.00,0,0.00,0,'2019-10-24 22:07:01','192.168.56.1',NULL,NULL),('REV0000005','P001',3,'1192971241001','F',1,93.70,0,0.00,0,0.00,0,'2019-10-24 22:07:25','192.168.56.1',NULL,NULL),('REV0000005','P001',4,'1192971241001','F',1,95.70,0,0.00,0,0.00,0,'2019-10-24 22:07:41','192.168.56.1',NULL,NULL),('REV0000005','P001',5,'1192971241001','F',1,96.20,0,0.00,0,0.00,0,'2019-10-24 22:07:51','192.168.56.1',NULL,NULL),('REV0000005','P001',6,'1192971241001','F',1,94.20,0,0.00,0,0.00,0,'2019-10-24 22:07:59','192.168.56.1',NULL,NULL),('REV0000005','P001',7,'1192971241001','F',1,96.20,0,0.00,0,0.00,0,'2019-10-24 22:08:08','192.168.56.1',NULL,NULL),('REV0000005','P001',8,'1192971241001','F',1,91.20,0,0.00,0,0.00,0,'2019-10-24 22:08:23','192.168.56.1',NULL,NULL),('REV0000005','P001',9,'1192971241001','F',1,90.20,0,0.00,0,0.00,0,'2019-10-24 22:08:34','192.168.56.1',NULL,NULL),('REV0000005','P001',10,'1192971241001','F',1,93.40,0,0.00,0,0.00,0,'2019-10-24 22:08:59','192.168.56.1',NULL,NULL),('REV0000005','P002',1,'1192971241001','',1,78.25,1,65.25,1,65.25,0,'2019-10-24 22:25:43','192.168.56.1','2019-10-25 01:01:30','192.168.56.1'),('REV0000005','P002',2,'1192971241001','',1,79.50,1,65.50,1,65.50,0,'2019-10-24 22:27:36','192.168.56.1','2019-10-25 01:04:08','192.168.56.1'),('REV0000005','P002',3,'1192971241001','',1,81.50,0,0.00,0,0.00,0,'2019-10-24 22:28:02','192.168.56.1',NULL,NULL),('REV0000005','P002',4,'1192971241001','',1,81.50,0,0.00,0,0.00,0,'2019-10-24 22:28:08','192.168.56.1',NULL,NULL),('REV0000005','P002',5,'1192971241001','',1,81.50,0,0.00,0,0.00,0,'2019-10-24 22:28:14','192.168.56.1',NULL,NULL),('REV0000005','P002',6,'1192971241001','',1,81.50,0,0.00,0,0.00,0,'2019-10-24 22:28:28','192.168.56.1',NULL,NULL),('REV0000005','P002',7,'1192971241001','',1,81.50,0,0.00,0,0.00,0,'2019-10-24 22:28:36','192.168.56.1',NULL,NULL),('REV0000005','P002',8,'1192971241001','',1,80.70,0,0.00,0,0.00,0,'2019-10-24 22:28:48','192.168.56.1',NULL,NULL),('REV0000005','P002',9,'1192971241001','',1,81.23,0,0.00,0,0.00,0,'2019-10-24 22:29:02','192.168.56.1',NULL,NULL),('REV0000005','P002',10,'1192971241001','',1,78.23,0,0.00,0,0.00,0,'2019-10-24 22:30:29','192.168.56.1',NULL,NULL),('REV0000005','P004',1,'1192971241001','',1,5.53,0,0.00,0,0.00,1000000000166,'2019-10-24 22:59:35','192.168.56.1',NULL,NULL),('REV0000005','P004',2,'1192971241001','',1,5.53,0,0.00,0,0.00,1000000000167,'2019-10-24 23:00:05','192.168.56.1',NULL,NULL),('REV0000005','P004',3,'1192971241001','',1,5.22,0,0.00,0,0.00,1000000000168,'2019-10-24 23:03:04','192.168.56.1',NULL,NULL),('REV0000005','P005',1,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000156,'2019-10-24 22:44:18','192.168.56.1',NULL,NULL),('REV0000005','P005',2,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000157,'2019-10-24 22:45:42','192.168.56.1',NULL,NULL),('REV0000005','P005',3,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000158,'2019-10-24 22:45:46','192.168.56.1',NULL,NULL),('REV0000005','P005',4,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000159,'2019-10-24 22:45:49','192.168.56.1',NULL,NULL),('REV0000005','P005',5,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000160,'2019-10-24 22:45:53','192.168.56.1',NULL,NULL),('REV0000005','P005',6,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000161,'2019-10-24 22:45:58','192.168.56.1',NULL,NULL),('REV0000005','P005',7,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000162,'2019-10-24 22:46:03','192.168.56.1',NULL,NULL),('REV0000005','P005',8,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000163,'2019-10-24 22:46:06','192.168.56.1',NULL,NULL),('REV0000005','P005',9,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000164,'2019-10-24 22:46:07','192.168.56.1',NULL,NULL),('REV0000005','P005',10,'1192971241001','',1,4.95,0,0.00,0,0.00,1000000000165,'2019-10-24 22:46:09','192.168.56.1',NULL,NULL),('REV0000006','P001',1,'1192981251001','F',1,90.00,0,0.00,0,0.00,0,'2019-10-25 11:24:26','192.168.56.1',NULL,NULL),('REV0000006','P001',2,'1192981251001','F',1,95.00,0,0.00,0,0.00,0,'2019-10-25 11:25:31','192.168.56.1',NULL,NULL),('REV0000006','P001',3,'1192981251001','F',1,93.00,0,0.00,0,0.00,0,'2019-10-25 11:26:11','192.168.56.1',NULL,NULL),('REV0000006','P001',4,'1192981251001','F',1,93.00,0,0.00,0,0.00,0,'2019-10-25 11:26:34','192.168.56.1',NULL,NULL),('REV0000006','P001',5,'1192981251001','F',1,91.00,0,0.00,0,0.00,0,'2019-10-25 11:26:45','192.168.56.1',NULL,NULL),('REV0000006','P002',1,'1192981251001','',1,65.00,0,0.00,0,0.00,0,'2019-10-25 11:53:11','192.168.56.1',NULL,NULL),('REV0000006','P002',2,'1192981251001','',1,69.00,0,0.00,0,0.00,0,'2019-10-25 11:55:28','192.168.56.1',NULL,NULL),('REV0000006','P002',3,'1192981251001','',1,65.00,0,0.00,0,0.00,0,'2019-10-25 11:55:37','192.168.56.1',NULL,NULL),('REV0000006','P002',4,'1192981251001','',1,65.00,0,0.00,0,0.00,0,'2019-10-25 11:55:43','192.168.56.1',NULL,NULL),('REV0000006','P002',5,'1192981251001','',1,69.00,0,0.00,0,0.00,0,'2019-10-25 11:55:52','192.168.56.1',NULL,NULL),('REV0000007','P001',1,'1192982251001','F',1,110.00,0,0.00,0,0.00,0,'2019-10-25 15:03:24','192.168.56.1',NULL,NULL),('REV0000007','P001',2,'1192982251001','M',1,105.00,0,0.00,0,0.00,0,'2019-10-25 15:04:32','192.168.56.1',NULL,NULL),('REV0000007','P001',3,'1192982251001','F',1,105.00,0,0.00,0,0.00,0,'2019-10-25 15:05:03','192.168.56.1',NULL,NULL),('REV0000007','P001',4,'1192982251001','F',1,105.00,0,0.00,0,0.00,0,'2019-10-25 15:05:09','192.168.56.1',NULL,NULL),('REV0000007','P002',1,'1192982251001','',1,90.00,0,0.00,0,0.00,0,'2019-10-25 15:13:41','192.168.56.1',NULL,NULL),('REV0000007','P002',2,'1192982251001','',1,88.00,0,0.00,0,0.00,0,'2019-10-25 15:14:02','192.168.56.1',NULL,NULL),('REV0000007','P002',3,'1192982251001','',1,88.00,0,0.00,0,0.00,0,'2019-10-25 15:14:34','192.168.56.1',NULL,NULL),('REV0000007','P002',4,'1192982251001','',1,88.00,0,0.00,0,0.00,0,'2019-10-25 15:14:37','192.168.56.1',NULL,NULL),('REV0000007','P005',1,'1192982251001','',1,4.95,0,0.00,0,0.00,1000000000171,'2019-10-25 15:26:36','192.168.56.1',NULL,NULL);
/*!40000 ALTER TABLE `receive_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receives`
--

DROP TABLE IF EXISTS `receives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `receives` (
  `receive_no` varchar(10) NOT NULL,
  `receive_date` date NOT NULL,
  `transport_doc_no` varchar(10) NOT NULL,
  `truck_no` varchar(10) NOT NULL,
  `farm_code` varchar(10) NOT NULL,
  `coop_no` varchar(5) NOT NULL,
  `breeder_code` int(11) NOT NULL,
  `queue_no` int(11) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `farm_qty` int(11) NOT NULL DEFAULT '0',
  `farm_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `factory_qty` int(11) NOT NULL DEFAULT '0',
  `factory_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `receive_flag` int(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`receive_no`),
  KEY `fk_farm_01_idx` (`farm_code`),
  KEY `fk_breeder_01_idx` (`breeder_code`),
  KEY `idx_01` (`receive_date`,`receive_flag`),
  CONSTRAINT `fk_breeder_01` FOREIGN KEY (`breeder_code`) REFERENCES `breeder` (`breeder_code`),
  CONSTRAINT `fk_farm_01` FOREIGN KEY (`farm_code`) REFERENCES `farm` (`farm_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receives`
--

LOCK TABLES `receives` WRITE;
/*!40000 ALTER TABLE `receives` DISABLE KEYS */;
INSERT INTO `receives` VALUES ('REV0000001','2019-09-06','TS001','1234','001','1',1,1,'11924910609',5,500.00,5,500.00,0,'2019-09-06 18:23:54','damrong','2019-09-06 18:24:06',NULL),('REV0000002','2019-09-22','1223','12','001','1',1,1,'11926512209',1,11.00,1,1.20,0,'2019-09-22 10:38:04','damrong',NULL,NULL),('REV0000003','2019-09-23','TS20190923','1234','003','A1',1,1,'11926612309',10,500.00,10,100.00,1,'2019-09-23 16:23:48','damrong',NULL,NULL),('REV0000004','2019-10-10','123','23','001','A101',1,1,'1192831101001',23,230.00,2,155.00,1,'2019-10-10 18:46:46','system',NULL,NULL),('REV0000005','2019-10-24','TP19100001','ออ 1234','001','5',1,1,'1192971241001',10,1000.00,10,941.30,1,'2019-10-24 21:22:05','system','2019-10-24 22:10:07',NULL),('REV0000006','2019-10-25','191025001','1234','002','1',1,1,'1192981251001',5,500.00,5,462.00,1,'2019-10-25 11:10:52','system',NULL,NULL),('REV0000007','2019-10-25','65/3205','2?? 791','005','5',1,2,'1192982251001',30,3237.00,4,425.00,1,'2019-10-25 14:58:26','system',NULL,NULL);
/*!40000 ALTER TABLE `receives` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `after_receive_created` AFTER INSERT ON `receives` FOR EACH ROW BEGIN
	UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='REV';
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `stock`
--

DROP TABLE IF EXISTS `stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock` (
  `stock_date` date NOT NULL,
  `stock_no` varchar(15) NOT NULL,
  `stock_item` int(11) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `stock_qty` int(11) NOT NULL DEFAULT '0',
  `stock_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `ref_document_type` varchar(10) DEFAULT NULL,
  `ref_document_no` varchar(10) DEFAULT NULL,
  `lot_no` varchar(13) NOT NULL,
  `location_code` int(11) NOT NULL,
  `barcode_no` bigint(13) NOT NULL,
  `transaction_type` int(1) NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  PRIMARY KEY (`stock_date`,`stock_no`,`stock_item`,`product_code`),
  KEY `fk_stock_product_idx` (`product_code`),
  KEY `fk_stock_location_idx` (`location_code`),
  CONSTRAINT `fk_stock_location` FOREIGN KEY (`location_code`) REFERENCES `location` (`location_code`),
  CONSTRAINT `fk_stock_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES ('2019-06-22','STK0000012',1,'P005',1,4.55,'SO','SO00000032','1192831101001',0,1000000000155,2,'2019-10-15 01:02:54','192.168.56.1'),('2019-09-06','STK0000001',1,'P001',1,100.00,'REV','REV0000001','11924910609',1,0,1,'2019-09-07 19:57:20','auto'),('2019-09-06','STK0000001',2,'P001',1,100.00,'REV','REV0000001','11924910609',1,0,1,'2019-09-07 20:00:20','auto'),('2019-09-06','STK0000001',3,'P001',1,100.00,'REV','REV0000001','11924910609',1,0,1,'2019-09-07 20:01:37','auto'),('2019-09-06','STK0000001',4,'P001',1,100.00,'REV','REV0000001','11924910609',1,0,1,'2019-09-07 20:01:50','auto'),('2019-09-06','STK0000001',5,'P001',1,100.00,'REV','REV0000001','11924910609',1,0,1,'2019-09-07 20:01:55','auto'),('2019-09-07','STK0000001',1,'P002',1,80.23,'REV','REV0000001','11924910609',2,0,1,'2019-09-07 20:43:59','auto'),('2019-09-07','STK0000001',2,'P002',1,80.23,'REV','REV0000001','11924910609',2,0,1,'2019-09-07 20:44:37','auto'),('2019-09-07','STK0000001',3,'P002',1,80.23,'REV','REV0000001','11924910609',2,0,1,'2019-09-07 20:44:49','auto'),('2019-09-07','STK0000001',4,'P002',1,80.23,'REV','REV0000001','11924910609',2,0,1,'2019-09-07 20:44:52','auto'),('2019-09-07','STK0000001',5,'P002',1,80.23,'REV','REV0000001','11924910609',2,0,1,'2019-09-07 20:44:55','auto'),('2019-09-07','STK0000091',1,'P003',1,12.00,'REV','REV0000091','11924910001',3,0,1,'2019-09-07 20:44:55','auto'),('2019-09-07','STK0000092',1,'P003',2,12.00,'REV','REV0000092','11924910002',3,0,1,'2019-09-07 20:44:55','auto'),('2019-09-22','STK0000001',6,'P0028',1,1.20,'REV','REV0000001','11924910609',7,1000000000138,1,'2019-09-22 23:55:14','192.168.56.1'),('2019-09-22','STK0000003',1,'P001',1,1.20,'REV','REV0000002','11926512209',1,0,1,'2019-09-23 16:12:40','auto'),('2019-09-23','STK0000001',3,'P0027',1,1.19,'REV','REV0000001','11924910609',7,1000000000139,1,'2019-09-23 00:15:12','auto'),('2019-09-23','STK0000002',1,'P0028',1,1.20,'REV','REV0000001','11924910609',6,1000000000138,1,'2019-09-23 12:53:52','192.168.56.1'),('2019-09-23','STK0000002',2,'P0028',1,1.20,'REV','REV0000001','11924910609',6,1000000000139,1,'2019-09-23 12:55:45','192.168.56.1'),('2019-09-23','STK0000002',3,'P0027',1,1.19,'STK','STK0000001','11924910609',7,1000000000139,2,'2019-09-23 12:55:45','192.168.56.1'),('2019-09-23','STK0000002',6,'P0028',1,1.20,'STK','STK0000001','11924910609',7,1000000000138,2,'2019-09-23 12:53:52','192.168.56.1'),('2019-09-23','STK0000004',1,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:26:18','auto'),('2019-09-23','STK0000004',2,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:28:10','auto'),('2019-09-23','STK0000004',3,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:29:15','auto'),('2019-09-23','STK0000004',4,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:29:27','auto'),('2019-09-23','STK0000004',5,'P001',1,1.20,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:29:52','auto'),('2019-09-23','STK0000004',6,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:55:29','auto'),('2019-09-23','STK0000004',7,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:58:05','auto'),('2019-09-23','STK0000004',8,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 16:59:27','auto'),('2019-09-23','STK0000004',9,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 17:03:09','auto'),('2019-09-23','STK0000004',10,'P001',1,1.19,'REV','REV0000003','11926612309',1,0,1,'2019-09-23 17:03:30','auto'),('2019-09-24','STK0000004',1,'P002',1,11.96,'REV','REV0000003','11926612309',2,0,1,'2019-09-24 19:35:25','auto'),('2019-09-24','STK0000004',2,'P002',1,11.94,'REV','REV0000003','11926612309',2,0,1,'2019-09-24 19:38:30','auto'),('2019-09-24','STK0000004',3,'P002',1,11.96,'REV','REV0000003','11926612309',2,0,1,'2019-09-24 19:38:50','auto'),('2019-09-24','STK0000004',4,'P002',1,11.94,'REV','REV0000003','11926612309',2,0,1,'2019-09-24 19:41:44','auto'),('2019-09-24','STK0000004',5,'P002',1,6.98,'REV','REV0000003','11926612309',2,0,1,'2019-09-24 19:42:14','auto'),('2019-09-24','STK0000004',6,'P002',1,17.56,'REV','REV0000003','11926612309',2,0,1,'2019-09-24 19:45:20','auto'),('2019-09-26','STK0000004',7,'P002',1,2.50,'REV','REV0000003','11926612309',2,0,1,'2019-09-26 21:46:22','auto'),('2019-09-26','STK0000004',8,'P002',1,2.50,'REV','REV0000003','11926612309',2,0,1,'2019-09-26 21:46:31','auto'),('2019-09-26','STK0000004',9,'P002',1,2.50,'REV','REV0000003','11926612309',2,0,1,'2019-09-26 21:46:40','auto'),('2019-09-26','STK0000004',10,'P002',1,2.50,'REV','REV0000003','11926612309',2,0,1,'2019-09-26 21:46:49','auto'),('2019-10-02','STK0000005',1,'P002',1,75.50,'ISS','ISS0000001','11924910609',2,0,2,'2019-10-02 23:36:37','auto'),('2019-10-02','STK0000005',2,'P002',1,78.50,'ISS','ISS0000001','11924910609',2,0,2,'2019-10-02 23:49:00','auto'),('2019-10-03','STK0000004',1,'P004',1,6.78,'REV','REV0000003','11926612309',4,1000000000149,1,'2019-10-03 20:06:06','192.168.56.1'),('2019-10-03','STK0000004',1,'P005',1,5.25,'REV','REV0000003','11926612309',0,1000000000140,1,'2019-10-03 16:12:43','192.168.56.1'),('2019-10-03','STK0000004',2,'P004',1,6.66,'REV','REV0000003','11926612309',4,1000000000150,1,'2019-10-03 20:06:56','192.168.56.1'),('2019-10-03','STK0000004',2,'P005',1,4.95,'REV','REV0000003','11926612309',8,0,1,'2019-10-03 16:59:04','auto'),('2019-10-03','STK0000004',3,'P004',1,5.89,'REV','REV0000003','11926612309',4,1000000000151,1,'2019-10-03 20:07:37','192.168.56.1'),('2019-10-03','STK0000004',3,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000141,1,'2019-10-03 17:13:35','192.168.56.1'),('2019-10-03','STK0000004',4,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000142,1,'2019-10-03 17:23:23','192.168.56.1'),('2019-10-03','STK0000004',5,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000143,1,'2019-10-03 19:32:34','192.168.56.1'),('2019-10-03','STK0000004',6,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000144,1,'2019-10-03 19:32:41','192.168.56.1'),('2019-10-03','STK0000004',7,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000145,1,'2019-10-03 19:32:48','192.168.56.1'),('2019-10-03','STK0000004',8,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000146,1,'2019-10-03 19:32:53','192.168.56.1'),('2019-10-03','STK0000004',9,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000147,1,'2019-10-03 19:32:59','192.168.56.1'),('2019-10-03','STK0000004',10,'P005',1,4.55,'REV','REV0000003','11926612309',8,1000000000148,1,'2019-10-03 19:33:04','192.168.56.1'),('2019-10-03','STK0000006',1,'P002',1,75.90,'SO','SO00000029','11924910609',2,0,2,'2019-10-03 00:12:57','auto'),('2019-10-09','STK0000005',3,'P002',1,66.50,'ISS','ISS0000001','11924910609',2,0,2,'2019-10-09 18:47:23','192.168.56.1'),('2019-10-09','STK0000007',1,'P002',1,65.50,'SO','SO00000030','11924910609',2,0,2,'2019-10-09 18:30:28','192.168.56.1'),('2019-10-09','STK0000007',2,'P002',1,67.12,'SO','SO00000030','11926612309',2,0,2,'2019-10-09 18:48:04','192.168.56.1'),('2019-10-10','STK0000008',1,'P0046',1,5.25,NULL,NULL,'11924910609',7,1000000000152,1,'2019-10-10 17:25:07','192.168.56.1'),('2019-10-10','STK0000008',2,'P0046',1,4.11,NULL,NULL,'11924910609',7,1000000000153,1,'2019-10-10 17:25:58','192.168.56.1'),('2019-10-10','STK0000010',1,'P001',1,78.00,'REV','REV0000004','1192831101001',1,0,1,'2019-10-10 18:49:12','192.168.56.1'),('2019-10-10','STK0000010',1,'P002',1,65.00,'REV','REV0000004','1192831101001',2,0,1,'2019-10-10 18:57:58','192.168.56.1'),('2019-10-10','STK0000010',1,'P005',1,4.55,'REV','REV0000004','1192831101001',8,1000000000154,1,'2019-10-10 19:08:07','192.168.56.1'),('2019-10-10','STK0000010',2,'P001',1,77.00,'REV','REV0000004','1192831101001',1,0,1,'2019-10-10 18:51:16','192.168.56.1'),('2019-10-10','STK0000010',2,'P005',1,4.55,'REV','REV0000004','1192831101001',8,1000000000155,1,'2019-10-10 19:08:26','192.168.56.1'),('2019-10-19','STK0000500',1,'P0024',1,0.50,'TEST','TEST01','A001',8,0,1,'2019-10-10 19:08:26','192.168.56.1'),('2019-10-19','STK0000501',1,'P0024',1,1.50,'TEST','TEST01','A003',8,0,1,'2019-10-10 19:08:26','192.168.56.1'),('2019-10-19','STK0000502',1,'P0024',1,0.50,'TEST','TEST01','A002',8,0,1,'2019-10-10 19:08:26','192.168.56.1'),('2019-10-20','BF20191020',1,'P0024',1,7.00,'BF','BF001','A001',8,0,1,'2019-10-19 20:07:59','auto'),('2019-10-20','BF20191020',2,'P0024',1,0.50,'BF','BF001','A002',8,0,1,'2019-10-19 20:07:59','auto'),('2019-10-20','BF20191020',3,'P0024',1,1.50,'BF','BF001','A003',8,0,1,'2019-10-19 20:07:59','auto'),('2019-10-21','BF20191021',1,'P0024',1,0.50,'BF','BF001','A001',8,0,1,'2019-10-19 20:08:51','auto'),('2019-10-21','BF20191021',2,'P0024',1,0.50,'BF','BF001','A002',8,0,1,'2019-10-19 20:08:51','auto'),('2019-10-21','BF20191021',3,'P0024',1,1.50,'BF','BF001','A003',8,0,1,'2019-10-19 20:08:51','auto'),('2019-10-22','BF20191022',1,'P0024',1,0.50,'BF','BF001','A001',8,0,1,'2019-10-19 20:10:24','auto'),('2019-10-22','BF20191022',2,'P0024',1,0.50,'BF','BF001','A002',8,0,1,'2019-10-19 20:10:24','auto'),('2019-10-22','BF20191022',3,'P0024',1,1.50,'BF','BF001','A003',8,0,1,'2019-10-19 20:10:24','auto'),('2019-10-22','STK0000502',1,'P0024',1,0.50,'TEST','TEST01','A002',8,0,2,'2019-10-10 19:08:26','192.168.56.1'),('2019-10-23','BF20191023',1,'P0024',1,0.50,'BF','BF001','A001',8,0,1,'2019-10-19 20:21:56','auto'),('2019-10-23','BF20191023',2,'P0024',1,1.50,'BF','BF001','A003',8,0,1,'2019-10-19 20:21:56','auto'),('2019-10-24','BF20191024',1,'P0024',1,0.50,'BF','BF001','A001',8,0,1,'2019-10-19 20:30:29','auto'),('2019-10-24','BF20191024',2,'P0024',1,1.50,'BF','BF001','A003',8,0,1,'2019-10-19 20:30:29','auto'),('2019-10-24','STK0000013',1,'P001',1,95.00,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 21:47:25','192.168.56.1'),('2019-10-24','STK0000013',1,'P002',1,78.25,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:25:43','192.168.56.1'),('2019-10-24','STK0000013',1,'P004',1,5.53,'REV','REV0000005','1192971241001',4,1000000000166,1,'2019-10-24 22:59:35','192.168.56.1'),('2019-10-24','STK0000013',1,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000156,1,'2019-10-24 22:44:18','192.168.56.1'),('2019-10-24','STK0000013',2,'P001',1,95.50,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:07:01','192.168.56.1'),('2019-10-24','STK0000013',2,'P002',1,79.50,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:27:36','192.168.56.1'),('2019-10-24','STK0000013',2,'P004',1,5.53,'REV','REV0000005','1192971241001',4,1000000000167,1,'2019-10-24 23:00:05','192.168.56.1'),('2019-10-24','STK0000013',2,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000157,1,'2019-10-24 22:45:42','192.168.56.1'),('2019-10-24','STK0000013',3,'P001',1,93.70,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:07:25','192.168.56.1'),('2019-10-24','STK0000013',3,'P002',1,81.50,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:28:02','192.168.56.1'),('2019-10-24','STK0000013',3,'P004',1,5.22,'REV','REV0000005','1192971241001',4,1000000000168,1,'2019-10-24 23:03:04','192.168.56.1'),('2019-10-24','STK0000013',3,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000158,1,'2019-10-24 22:45:46','192.168.56.1'),('2019-10-24','STK0000013',4,'P001',1,95.70,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:07:41','192.168.56.1'),('2019-10-24','STK0000013',4,'P002',1,81.50,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:28:08','192.168.56.1'),('2019-10-24','STK0000013',4,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000159,1,'2019-10-24 22:45:49','192.168.56.1'),('2019-10-24','STK0000013',5,'P001',1,96.20,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:07:51','192.168.56.1'),('2019-10-24','STK0000013',5,'P002',1,81.50,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:28:14','192.168.56.1'),('2019-10-24','STK0000013',5,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000160,1,'2019-10-24 22:45:53','192.168.56.1'),('2019-10-24','STK0000013',6,'P001',1,94.20,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:07:59','192.168.56.1'),('2019-10-24','STK0000013',6,'P002',1,81.50,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:28:28','192.168.56.1'),('2019-10-24','STK0000013',6,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000161,1,'2019-10-24 22:45:58','192.168.56.1'),('2019-10-24','STK0000013',7,'P001',1,96.20,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:08:08','192.168.56.1'),('2019-10-24','STK0000013',7,'P002',1,81.50,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:28:36','192.168.56.1'),('2019-10-24','STK0000013',7,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000162,1,'2019-10-24 22:46:03','192.168.56.1'),('2019-10-24','STK0000013',8,'P001',1,91.20,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:08:23','192.168.56.1'),('2019-10-24','STK0000013',8,'P002',1,80.70,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:28:48','192.168.56.1'),('2019-10-24','STK0000013',8,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000163,1,'2019-10-24 22:46:06','192.168.56.1'),('2019-10-24','STK0000013',9,'P001',1,90.20,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:08:34','192.168.56.1'),('2019-10-24','STK0000013',9,'P002',1,81.23,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:29:02','192.168.56.1'),('2019-10-24','STK0000013',9,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000164,1,'2019-10-24 22:46:07','192.168.56.1'),('2019-10-24','STK0000013',10,'P001',1,93.40,'REV','REV0000005','1192971241001',1,0,1,'2019-10-24 22:08:59','192.168.56.1'),('2019-10-24','STK0000013',10,'P002',1,78.23,'REV','REV0000005','1192971241001',2,0,1,'2019-10-24 22:30:29','192.168.56.1'),('2019-10-24','STK0000013',10,'P005',1,4.95,'REV','REV0000005','1192971241001',8,1000000000165,1,'2019-10-24 22:46:09','192.168.56.1'),('2019-10-24','STK0000014',1,'P002',1,65.25,'SO','SO00000036','1192971241001',2,0,2,'2019-10-25 01:01:30','192.168.56.1'),('2019-10-24','STK0000014',2,'P002',1,65.50,'SO','SO00000036','1192971241001',2,0,2,'2019-10-25 01:04:07','192.168.56.1'),('2019-10-24','STK0000014',3,'P004',1,5.22,'SO','SO00000036','1192971241001',0,1000000000168,2,'2019-10-25 02:08:16','192.168.56.1'),('2019-10-24','STK0000014',4,'P004',1,5.53,'SO','SO00000036','1192971241001',0,1000000000167,2,'2019-10-25 02:12:30','192.168.56.1'),('2019-10-24','STK0000014',5,'P005',1,4.95,'SO','SO00000036','1192971241001',0,1000000000165,2,'2019-10-25 02:21:14','192.168.56.1'),('2019-10-24','STK0000014',6,'P005',1,4.95,'SO','SO00000036','1192971241001',0,1000000000164,2,'2019-10-25 02:25:03','192.168.56.1'),('2019-10-24','STK0000017',1,'P0021',1,10.55,NULL,NULL,'11924910609',7,1000000000169,1,'2019-10-25 02:57:41','192.168.56.1'),('2019-10-24','STK0000017',2,'P0021',1,11.20,NULL,NULL,'11924910609',7,1000000000170,1,'2019-10-25 03:05:34','192.168.56.1'),('2019-10-24','STK0000018',1,'P001',1,90.00,'REV','REV0000006','1192981251001',1,0,1,'2019-10-25 11:24:26','192.168.56.1'),('2019-10-24','STK0000018',1,'P002',1,65.00,'REV','REV0000006','1192981251001',2,0,1,'2019-10-25 11:53:11','192.168.56.1'),('2019-10-24','STK0000018',2,'P001',1,95.00,'REV','REV0000006','1192981251001',1,0,1,'2019-10-25 11:25:31','192.168.56.1'),('2019-10-24','STK0000018',2,'P002',1,69.00,'REV','REV0000006','1192981251001',2,0,1,'2019-10-25 11:55:28','192.168.56.1'),('2019-10-24','STK0000018',3,'P001',1,93.00,'REV','REV0000006','1192981251001',1,0,1,'2019-10-25 11:26:11','192.168.56.1'),('2019-10-24','STK0000018',3,'P002',1,65.00,'REV','REV0000006','1192981251001',2,0,1,'2019-10-25 11:55:37','192.168.56.1'),('2019-10-24','STK0000018',4,'P001',1,93.00,'REV','REV0000006','1192981251001',1,0,1,'2019-10-25 11:26:34','192.168.56.1'),('2019-10-24','STK0000018',4,'P002',1,65.00,'REV','REV0000006','1192981251001',2,0,1,'2019-10-25 11:55:43','192.168.56.1'),('2019-10-24','STK0000018',5,'P001',1,91.00,'REV','REV0000006','1192981251001',1,0,1,'2019-10-25 11:26:45','192.168.56.1'),('2019-10-24','STK0000018',5,'P002',1,69.00,'REV','REV0000006','1192981251001',2,0,1,'2019-10-25 11:55:52','192.168.56.1'),('2019-10-24','STK0000019',1,'P002',1,69.00,'SO','SO00000037','11926612309',2,0,2,'2019-10-25 12:19:04','192.168.56.1'),('2019-10-24','STK0000020',1,'P001',1,110.00,'REV','REV0000007','1192982251001',1,0,1,'2019-10-25 15:03:24','192.168.56.1'),('2019-10-24','STK0000020',1,'P002',1,90.00,'REV','REV0000007','1192982251001',2,0,1,'2019-10-25 15:13:41','192.168.56.1'),('2019-10-24','STK0000020',1,'P005',1,4.95,'REV','REV0000007','1192982251001',8,1000000000171,1,'2019-10-25 15:26:36','192.168.56.1'),('2019-10-24','STK0000020',2,'P001',1,105.00,'REV','REV0000007','1192982251001',1,0,1,'2019-10-25 15:04:32','192.168.56.1'),('2019-10-24','STK0000020',2,'P002',1,88.00,'REV','REV0000007','1192982251001',2,0,1,'2019-10-25 15:14:02','192.168.56.1'),('2019-10-24','STK0000020',3,'P001',1,105.00,'REV','REV0000007','1192982251001',1,0,1,'2019-10-25 15:05:03','192.168.56.1'),('2019-10-24','STK0000020',3,'P002',1,88.00,'REV','REV0000007','1192982251001',2,0,1,'2019-10-25 15:14:34','192.168.56.1'),('2019-10-24','STK0000020',4,'P001',1,105.00,'REV','REV0000007','1192982251001',1,0,1,'2019-10-25 15:05:09','192.168.56.1'),('2019-10-24','STK0000020',4,'P002',1,88.00,'REV','REV0000007','1192982251001',2,0,1,'2019-10-25 15:14:37','192.168.56.1');
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_item_running`
--

DROP TABLE IF EXISTS `stock_item_running`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stock_item_running` (
  `doc_no` varchar(15) NOT NULL,
  `stock_no` varchar(15) NOT NULL,
  `stock_item` int(11) NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`doc_no`,`stock_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock_item_running`
--

LOCK TABLES `stock_item_running` WRITE;
/*!40000 ALTER TABLE `stock_item_running` DISABLE KEYS */;
INSERT INTO `stock_item_running` VALUES ('ISS0000001','STK0000005',3,'2019-10-02 23:36:37','auto',NULL,NULL),('REV0000001','STK0000001',6,'2019-06-28 19:23:58','system',NULL,NULL),('REV0000002','STK0000003',1,'2019-09-23 16:12:40','auto',NULL,NULL),('REV0000003','STK0000004',10,'2019-09-23 16:26:18','auto',NULL,NULL),('REV0000004','STK0000010',2,'2019-10-10 18:49:12','192.168.56.1',NULL,NULL),('REV0000005','STK0000013',10,'2019-10-24 21:47:25','192.168.56.1',NULL,NULL),('REV0000006','STK0000018',5,'2019-10-25 11:24:26','192.168.56.1',NULL,NULL),('REV0000007','STK0000020',4,'2019-10-25 15:03:24','192.168.56.1',NULL,NULL),('SO00000029','STK0000006',1,'2019-10-03 00:12:57','auto',NULL,NULL),('SO00000030','STK0000007',2,'2019-10-09 18:30:28','192.168.56.1',NULL,NULL),('SO00000036','STK0000014',2,'2019-10-25 01:01:30','192.168.56.1',NULL,NULL),('SO00000037','STK0000019',1,'2019-10-25 12:19:04','192.168.56.1',NULL,NULL),('STK0000001','STK0000002',2,'2019-09-23 12:53:52','192.168.56.1',NULL,NULL);
/*!40000 ALTER TABLE `stock_item_running` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transport`
--

DROP TABLE IF EXISTS `transport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transport` (
  `transport_no` varchar(10) NOT NULL,
  `transport_date` date NOT NULL,
  `ref_document_no` varchar(10) NOT NULL,
  `truck_no` varchar(10) DEFAULT NULL,
  `transport_flag` int(1) NOT NULL DEFAULT '0',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`transport_no`),
  KEY `idx_ref_docuemnt_no` (`ref_document_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transport`
--

LOCK TABLES `transport` WRITE;
/*!40000 ALTER TABLE `transport` DISABLE KEYS */;
INSERT INTO `transport` VALUES ('TP00000002','2019-10-25','SO00000036','2ฒย 791',0,'2019-10-25 01:01:30','192.168.56.1',NULL,NULL),('TP00000003','2019-10-25','SO00000037','2?? 3389',0,'2019-10-25 12:19:04','192.168.56.1',NULL,NULL);
/*!40000 ALTER TABLE `transport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transport_item`
--

DROP TABLE IF EXISTS `transport_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transport_item` (
  `transport_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `transport_qty` int(11) NOT NULL,
  `transport_wgh` decimal(10,0) NOT NULL,
  `stock_no` varchar(15) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `truck_no` varchar(10) NOT NULL,
  `barcode_no` bigint(13) NOT NULL,
  `bom_code` int(11) NOT NULL DEFAULT '0',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  PRIMARY KEY (`transport_no`,`product_code`,`seq`),
  KEY `fk_transport_product` (`product_code`),
  CONSTRAINT `fk_transport_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transport_item`
--

LOCK TABLES `transport_item` WRITE;
/*!40000 ALTER TABLE `transport_item` DISABLE KEYS */;
INSERT INTO `transport_item` VALUES ('TP00000002','P002',1,1,65,'STK0000014','1192971241001','2ฒย 791',0,17,'2019-10-25 01:01:30','192.168.56.1'),('TP00000002','P002',2,1,66,'STK0000014','1192971241001','2ฒย 791',0,17,'2019-10-25 01:04:07','192.168.56.1'),('TP00000002','P004',3,1,5,'STK0000014','1192971241001','2ฒย 791',1000000000168,17,'2019-10-25 02:08:16','192.168.56.1'),('TP00000002','P004',4,1,6,'STK0000014','1192971241001','2ฒย 791',1000000000167,17,'2019-10-25 02:12:30','192.168.56.1'),('TP00000002','P005',5,1,5,'STK0000014','1192971241001','2ฒย 791',1000000000165,17,'2019-10-25 02:21:14','192.168.56.1'),('TP00000002','P005',6,1,5,'STK0000014','1192971241001','2ฒย 791',1000000000164,17,'2019-10-25 02:25:03','192.168.56.1'),('TP00000003','P002',1,1,69,'STK0000019','11926612309','2?? 3389',0,17,'2019-10-25 12:19:04','192.168.56.1');
/*!40000 ALTER TABLE `transport_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `truck`
--

DROP TABLE IF EXISTS `truck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `truck` (
  `truck_no` varchar(10) NOT NULL,
  `driver` varchar(255) NOT NULL,
  `truck_type_id` int(11) NOT NULL DEFAULT '1',
  `active` tinyint(1) DEFAULT '1',
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`truck_no`),
  KEY `fk_truck_type_idx` (`truck_type_id`),
  CONSTRAINT `fk_truck_type` FOREIGN KEY (`truck_type_id`) REFERENCES `truck_type` (`truck_type_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `truck`
--

LOCK TABLES `truck` WRITE;
/*!40000 ALTER TABLE `truck` DISABLE KEYS */;
INSERT INTO `truck` VALUES ('2ฒต 3389','ธวัชชัย ไวเจริญ',1,1,'2019-10-24 23:50:13','system',NULL,NULL),('2ฒย 791','รัตนศักดิ์ สุขาฉายี',1,1,'2019-10-24 23:50:23','system',NULL,NULL),('555','กกกกกกกกก',2,1,'2019-10-25 15:47:19','system','2019-10-25 15:51:58',NULL),('82-4383','พรเทพ สืบวงศ์',1,1,'2019-10-24 23:50:03','system',NULL,NULL);
/*!40000 ALTER TABLE `truck` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `truck_type`
--

DROP TABLE IF EXISTS `truck_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `truck_type` (
  `truck_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `truck_type_desc` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) COLLATE utf8_unicode_ci NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`truck_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `truck_type`
--

LOCK TABLES `truck_type` WRITE;
/*!40000 ALTER TABLE `truck_type` DISABLE KEYS */;
INSERT INTO `truck_type` VALUES (1,'ส่งหมูเป็น',1,'2019-10-25 14:04:00','system',NULL,NULL),(2,'รับสินค้า',1,'2019-10-25 14:04:00','system',NULL,NULL);
/*!40000 ALTER TABLE `truck_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit_of_measurement`
--

DROP TABLE IF EXISTS `unit_of_measurement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit_of_measurement` (
  `unit_code` int(11) NOT NULL AUTO_INCREMENT,
  `unit_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`unit_code`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit_of_measurement`
--

LOCK TABLES `unit_of_measurement` WRITE;
/*!40000 ALTER TABLE `unit_of_measurement` DISABLE KEYS */;
INSERT INTO `unit_of_measurement` VALUES (1,'ตัว',1,'2019-06-22 14:50:59','system',NULL,NULL),(2,'ซีก',1,'2019-06-22 14:50:59','system',NULL,NULL),(3,'กรัม',1,'2019-06-22 14:50:59','system','2019-10-20 12:06:55','system'),(4,'กิโลกรัม',1,'2019-06-22 14:50:59','system',NULL,NULL),(5,'ชิ้น',1,'2019-07-20 17:03:32','system',NULL,NULL),(6,'ถุง',1,'2019-08-29 18:20:15','system',NULL,NULL),(7,'ชุด',1,'2019-08-29 18:20:21','system',NULL,NULL),(8,'พวง',1,'2019-09-23 13:30:09','system',NULL,NULL);
/*!40000 ALTER TABLE `unit_of_measurement` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 15:52:54
