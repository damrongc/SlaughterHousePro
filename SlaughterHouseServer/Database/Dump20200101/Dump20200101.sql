CREATE DATABASE  IF NOT EXISTS `slaughterhouse` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `slaughterhouse`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
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
INSERT INTO `barcode` VALUES (1000000000001,'04001','2019-11-27','1193301261101',1,4.55,1,'2019-11-28 20:02:59','192.168.56.1'),(1000000000003,'04001','2019-11-27','1193301261101',1,4.26,1,'2019-11-28 20:23:59','192.168.56.1'),(1000000000004,'04001','2019-11-27','1193301261101',1,4.26,1,'2019-11-28 20:28:42','192.168.56.1'),(1000000000005,'04001','2019-11-27','1193301261101',1,4.56,1,'2019-12-03 18:59:13','192.168.56.1'),(1000000000006,'04001','2019-11-27','1193301261101',1,4.56,1,'2019-12-03 18:59:22','192.168.56.1'),(1000000000007,'00201','2019-11-27','1193301261101',1,8.52,1,'2019-12-03 19:00:29','192.168.56.1'),(1000000000008,'00201','2019-11-27','1193301261101',1,8.52,1,'2019-12-03 19:00:35','192.168.56.1'),(1000000000009,'00201','2019-11-27','1193301261101',1,8.52,1,'2019-12-03 19:00:41','192.168.56.1'),(1000000000010,'00201','2019-11-27','1193301261101',1,8.52,1,'2019-12-03 19:00:46','192.168.56.1'),(1000000000011,'00201','2019-11-27','1193301261101',1,8.52,1,'2019-12-03 19:00:51','192.168.56.1'),(1000000000012,'00101','2019-11-27','1193301261101',1,7.89,1,'2019-12-03 19:04:47','192.168.56.1'),(1000000000013,'00101','2019-11-27','1193301261101',1,8.99,1,'2019-12-03 19:12:52','192.168.56.1'),(1000000000014,'00101','2019-11-27','1193301261101',1,8.89,1,'2019-12-03 19:14:37','192.168.56.1'),(1000000000015,'00101','2019-11-27','1193301261101',1,8.45,1,'2019-12-03 22:38:31','192.168.56.1'),(1000000000016,'00101','2019-11-27','1193301261101',1,8.45,1,'2019-12-03 22:38:34','192.168.56.1');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bom`
--

LOCK TABLES `bom` WRITE;
/*!40000 ALTER TABLE `bom` DISABLE KEYS */;
INSERT INTO `bom` VALUES (0,'NA',1,'2019-08-11 12:25:45','system',NULL,NULL),(1,'00001',1,'2019-12-05 22:21:03','system',NULL,NULL),(2,'00003',1,'2019-12-06 09:53:55','system',NULL,NULL),(3,'00002',1,'2019-12-06 09:56:07','system',NULL,NULL),(4,'00004',1,'2019-12-06 09:56:32','system',NULL,NULL);
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
INSERT INTO `bom_item` VALUES (0,'NA',1,1.00),(1,'00000',1,1.00),(1,'00101',1,1.00),(1,'00201',1,1.00),(1,'04001',1,1.00),(2,'00000',1,1.00),(2,'00101',1,1.00),(2,'00201',1,1.00),(2,'04001',1,1.00),(3,'00000',1,1.00),(4,'00000',1,1.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
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
INSERT INTO `customer` VALUES ('PKP0001','PKP Inter Foods','609/20 ม.7 ต.ท่าตูม อ.ศรีมหาโพธิ์ จ.ปราจีนบุรี รหัส 25140','609/20 ม.7 ต.ท่าตูม อ.ศรีมหาโพธิ์ จ.ปราจีนบุรี รหัส 25140','1190400033451','0924241955',1,'2019-10-24 23:49:26','system','2019-12-25 00:37:27','system'),('PKP0002','PKP Market','609/20 ม.7 ต.ท่าตูม อ.ศรีมหาโพธิ์ จ.ปราจีนบุรี รหัส 25140','609/20 ม.7 ต.ท่าตูม อ.ศรีมหาโพธิ์ จ.ปราจีนบุรี รหัส 25140','1190400033451','0924241955',1,'2019-11-26 18:42:55','system','2019-12-25 00:37:19','system');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_class`
--

DROP TABLE IF EXISTS `customer_class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_class` (
  `customer_code` varchar(10) NOT NULL,
  `start_date` date NOT NULL,
  `class_id` int(11) NOT NULL,
  `end_date` date NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customer_code`,`start_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_class`
--

LOCK TABLES `customer_class` WRITE;
/*!40000 ALTER TABLE `customer_class` DISABLE KEYS */;
INSERT INTO `customer_class` VALUES ('PKP0001','2019-12-01',3,'2020-01-31','2019-12-31 16:02:53','system',NULL,NULL),('PKP0001','2019-12-31',4,'2020-01-31','2019-12-31 16:03:03','system','2020-01-01 16:39:05','system'),('PKP0001','2020-01-01',2,'2020-01-31','2020-01-01 16:39:13','system',NULL,NULL),('PKP0002','2020-01-01',3,'2020-01-31','2020-01-01 15:51:52','system','2020-01-01 15:57:03','system');
/*!40000 ALTER TABLE `customer_class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_class_discount`
--

DROP TABLE IF EXISTS `customer_class_discount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_class_discount` (
  `class_id` int(11) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `discount_per` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`class_id`,`start_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_class_discount`
--

LOCK TABLES `customer_class_discount` WRITE;
/*!40000 ALTER TABLE `customer_class_discount` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer_class_discount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer_class_price`
--

DROP TABLE IF EXISTS `customer_class_price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer_class_price` (
  `class_id` int(11) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`class_id`,`product_code`,`start_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer_class_price`
--

LOCK TABLES `customer_class_price` WRITE;
/*!40000 ALTER TABLE `customer_class_price` DISABLE KEYS */;
INSERT INTO `customer_class_price` VALUES (1,'02201','2019-12-31','2020-01-31',300.00,'2019-12-31 16:26:14','system',NULL,NULL),(1,'02301','2019-12-31','2020-01-31',200.00,'2019-12-31 16:25:58','system',NULL,NULL),(1,'02501','2019-12-31','2020-01-31',100.00,'2019-12-31 16:24:41','system',NULL,NULL),(2,'02601','2020-01-01','2020-01-31',60.00,'2020-01-01 16:33:08','system',NULL,NULL),(3,'02501','2019-12-31','2020-01-31',90.00,'2019-12-31 16:24:59','system',NULL,NULL),(4,'02301','2019-12-31','2020-01-31',185.00,'2019-12-31 16:27:08','system','2020-01-01 15:53:40','system'),(4,'02501','2019-12-31','2020-01-31',85.00,'2019-12-31 16:25:18','system',NULL,NULL);
/*!40000 ALTER TABLE `customer_class_price` ENABLE KEYS */;
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
INSERT INTO `customer_price` VALUES ('PKP0001','02301','2020-01-01','2020-01-31',169.00,'2020-01-01 16:40:05','system',NULL,NULL),('PKP0002','02301','2020-01-01','2020-01-31',170.00,'2020-01-01 15:59:47','system',NULL,NULL);
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
  `current year` varchar(45) NOT NULL DEFAULT '2019',
  PRIMARY KEY (`document_type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `document_generate`
--

LOCK TABLES `document_generate` WRITE;
/*!40000 ALTER TABLE `document_generate` DISABLE KEYS */;
INSERT INTO `document_generate` VALUES ('BF',0,'2019-10-14 21:49:22',NULL,'ยกมา','2019'),('ISS',1,'2019-06-14 19:18:00',NULL,'เอกสารเบิก','2019'),('IV',2,'2019-06-14 19:18:00','2019-12-06 09:45:20','เอกสาร invoice','2019'),('PDL',1,'2019-06-22 16:17:31',NULL,'product lot no','2019'),('PDS',1,'2019-09-21 17:01:31','2019-11-10 01:39:33','product slip','2019'),('PO',1,'2019-07-03 16:28:14','2019-09-15 08:00:12',NULL,'2019'),('RC',2,'2019-11-09 20:39:50','2019-12-06 09:45:20',NULL,'2019'),('REV',3,'2019-06-14 19:18:00','2019-11-29 19:06:25','เอกสารรับหมูเป็น','2019'),('SO',5,'2019-06-14 19:18:00','2020-01-01 15:43:54','เอกสาร sales order','2019'),('STK',3,'2019-06-28 18:55:46',NULL,'Stock document no','2019'),('SWL',1,'2019-06-22 15:49:34',NULL,'Lot No รับหมูเป็น','2019'),('TP',2,'2019-10-14 21:49:22',NULL,'???????????','2019');
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
INSERT INTO `farm` VALUES ('FARM0001','PLF ฟาร์มดงยาง','65  ม.7 ต.โนนห้อม อ.เมือง จ.ปราจีนบุรี',1,'2019-06-15 20:30:44','system','2019-10-25 14:56:57','system'),('FARM0002','PLF ฟาร์มโพธิ์งาม','41 ม.18 ต.โพธิ์งาม อ.ประจันตคาม จ.ปราจีนบุรี 25130',1,'2019-09-22 10:24:21','system','2019-10-25 14:44:27','system'),('FARM0003','PLF ฟาร์มกลาง','3/1 ม.3 ต.บางบริบูรณ์ อ.เมือง จ.ปราจีนบุรี 25000',1,'2019-09-23 16:21:42','system','2019-10-25 14:56:52','system'),('FARM0004','PLF ฟาร์มนอก','95 ม.2 ต.บางบริบูรณ์ อ.เมือง จ.ปราจีนบุรี 25000',1,'2019-10-24 21:55:31','system','2019-10-25 14:56:49','system'),('FARM0005','PLF ฟาร์มหาดสะแก','56 ม.6 ต.บางบริบูรณ์ อ.เมือง จ.ปราจีนบุรี 25000',1,'2019-10-25 14:56:39','system',NULL,NULL),('FARM0006','PLF ฟาร์มสะพานหิน','51/4 สะพานหิน ม.1 ต.บางเดชะ อ.เมือง จ.ปราจีนบุรี 25000',1,'2019-11-26 18:48:42','system',NULL,NULL),('FARM0007','PLF ฟาร์มบ้านสร้าง','1 ม.4 ต.บางพลวง อ.บ้านสร้าง จ.ปราจีนบุรี 25150',1,'2019-11-26 18:48:42','system',NULL,NULL);
/*!40000 ALTER TABLE `farm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `group`
--

DROP TABLE IF EXISTS `group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `group` (
  `group_id` int(11) NOT NULL AUTO_INCREMENT,
  `group_name` varchar(100) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`group_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `group`
--

LOCK TABLES `group` WRITE;
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
INSERT INTO `group` VALUES (1,'Administrator',1,'2019-11-24 11:34:54','system',NULL,NULL),(2,'Account',1,'2019-11-24 11:35:56','system',NULL,NULL),(3,'Production',1,'2019-11-24 11:35:56','system',NULL,NULL);
/*!40000 ALTER TABLE `group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice` (
  `invoice_no` varchar(15) NOT NULL,
  `invoice_date` date NOT NULL,
  `ref_document_no` varchar(15) NOT NULL,
  `receipt_no` varchar(15) DEFAULT NULL,
  `customer_code` varchar(10) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `gross_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `disc_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `disc_amt_bill` decimal(12,2) NOT NULL DEFAULT '0.00',
  `vat_rate` decimal(12,2) NOT NULL DEFAULT '0.00',
  `vat_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `net_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `invoice_flag` int(1) NOT NULL DEFAULT '0' COMMENT '0= Create\n1= Close',
  `comments` varchar(200) DEFAULT NULL,
  `print_no` int(2) DEFAULT '0',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`invoice_no`),
  KEY `fk_invoice_truck_idx` (`truck_id`),
  CONSTRAINT `fk_invoice_truck` FOREIGN KEY (`truck_id`) REFERENCES `truck` (`truck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
INSERT INTO `invoice` VALUES ('IV1912050001','2019-12-05','SO1912050001','RC1912050001','PKP0001',1,5794.25,0.00,100.00,7.00,398.60,6092.85,0,'ทดสอบ',4,0,'2019-12-06 09:45:20','system','2019-12-06 09:51:57','system');
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `after_invoice_created` AFTER INSERT ON `invoice` FOR EACH ROW BEGIN
 UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='IV';
  UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='RC';

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
  `invoice_no` varchar(15) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `qty` int(11) NOT NULL DEFAULT '0',
  `wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unit_price_current` decimal(10,2) DEFAULT NULL,
  `disc_per` decimal(10,2) DEFAULT '0.00',
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unit_disc` decimal(10,2) NOT NULL DEFAULT '0.00',
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
INSERT INTO `invoice_item` VALUES ('IV1912050001','00001',1,1,75.25,77.00,0.00,77.00,0.00,0.00,5794.25,0.00,'W','2019-12-06 09:45:20','system',NULL,NULL);
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
-- Table structure for table `master_class`
--

DROP TABLE IF EXISTS `master_class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `master_class` (
  `class_id` int(11) NOT NULL AUTO_INCREMENT,
  `class_name` varchar(45) NOT NULL,
  `default_flag` tinyint(1) DEFAULT '0',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`class_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `master_class`
--

LOCK TABLES `master_class` WRITE;
/*!40000 ALTER TABLE `master_class` DISABLE KEYS */;
INSERT INTO `master_class` VALUES (1,'ทั่วไป',1,1,'2019-11-26 18:44:00','system','2019-12-06 18:45:05','system'),(2,'เกรด A',0,1,'2019-12-06 10:42:27','system','2019-12-06 18:45:10','system'),(3,'VIP 1',0,1,'2019-12-06 18:42:56','system','2019-12-25 01:34:31','system'),(4,'VIP 2',0,1,'2019-12-06 18:45:17','system',NULL,NULL);
/*!40000 ALTER TABLE `master_class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_no` varchar(12) NOT NULL,
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
INSERT INTO `orders` VALUES ('SO1912050001','2019-12-05','PKP0001',0,0,'',1,'2019-12-05 22:14:53','system','2019-12-05 22:29:21','system'),('SO1912060002','2019-12-06','PKP0001',0,0,'',1,'2019-12-06 16:14:19','system',NULL,NULL),('SO2001010003','2020-01-01','PKP0001',0,0,'',1,'2019-12-31 16:58:03','system',NULL,NULL),('SO2001010004','2020-01-01','PKP0002',0,0,'',1,'2020-01-01 15:43:54','system',NULL,NULL);
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
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `slaughterhouse`.`after_orders_created` AFTER INSERT ON `orders` FOR EACH ROW
BEGIN 
	UPDATE document_generate  SET running= running+1, modified_at =NOW()
    WHERE document_type='SO' 
    ;
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
  `order_no` varchar(15) NOT NULL,
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
INSERT INTO `orders_item` VALUES ('SO1912050001','00000',1,1,1,100.00,1,75.25,1,1.00,'2019-12-05 22:29:21','system','2019-12-05 22:44:22','192.168.56.1'),('SO1912050001','00101',1,2,1,1.00,0,0.00,1,1.00,'2019-12-05 22:29:21','system',NULL,NULL),('SO1912050001','00201',1,3,1,1.00,0,0.00,1,1.00,'2019-12-05 22:29:21','system',NULL,NULL),('SO1912050001','04001',1,4,1,1.00,0,0.00,1,1.00,'2019-12-05 22:29:21','system',NULL,NULL),('SO1912060002','00000',1,1,5,500.00,0,0.00,5,5.00,'2019-12-06 16:14:19','system',NULL,NULL),('SO1912060002','00101',1,2,5,5.00,0,0.00,5,5.00,'2019-12-06 16:14:19','system',NULL,NULL),('SO1912060002','00201',1,3,5,5.00,0,0.00,5,5.00,'2019-12-06 16:14:19','system',NULL,NULL),('SO1912060002','04001',1,4,5,5.00,0,0.00,5,5.00,'2019-12-06 16:14:19','system',NULL,NULL),('SO2001010003','02201',0,2,2,2.00,0,0.00,0,0.00,'2019-12-31 16:58:04','system',NULL,NULL),('SO2001010003','02301',0,3,2,2.00,0,0.00,0,0.00,'2019-12-31 16:58:04','system',NULL,NULL),('SO2001010003','02501',0,1,2,2.00,0,0.00,0,0.00,'2019-12-31 16:58:03','system',NULL,NULL),('SO2001010004','02201',0,3,1,1.00,0,0.00,0,0.00,'2020-01-01 15:43:54','system',NULL,NULL),('SO2001010004','02301',0,2,1,1.00,0,0.00,0,0.00,'2020-01-01 15:43:54','system',NULL,NULL),('SO2001010004','02501',0,1,1,1.00,0,0.00,0,0.00,'2020-01-01 15:43:54','system',NULL,NULL);
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
  `logo_image` longblob,
  `active` tinyint(1) DEFAULT '1',
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`plant_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plant`
--

LOCK TABLES `plant` WRITE;
/*!40000 ALTER TABLE `plant` DISABLE KEYS */;
INSERT INTO `plant` VALUES (1,'2020-01-01','บริษัท พี.เค.พี 6 จำกัด','85/1 หมู่ 1 ตำบลไม้เค็ด อำเภอเมืองปราจีนบุรี จ.ปราจีนบุรี 25230','1',NULL,1,'2019-11-07 20:38:27',NULL,'2019-12-05 22:09:49',NULL);
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
  `sale_unit_method` varchar(1) NOT NULL DEFAULT 'W',
  `issue_unit_method` varchar(1) NOT NULL DEFAULT 'W',
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
INSERT INTO `product` VALUES ('00000','หมูซีก',1,1,4,60.00,150.00,78.00,'W','Q',60,100.00,1,'2019-06-22 14:52:35','system','2019-12-06 10:53:03','system'),('00001','หมูซีกรวมหัวและเครื่องใน',2,2,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('00002','หมูซีกไม่รวมหัวและเครื่องใน',2,2,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('00003','หมูซีกรวมหัวและเครื่องใน ขึ้นกระดูก',2,2,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('00004','หมูซีกไม่รวมหัวและเครื่องใน ขึ้นกระดูก',2,2,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('00101','เครื่องในแดง',2,7,4,0.50,9.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system','2019-11-28 20:18:42','system'),('00201','เครื่องในขาว',2,7,4,0.50,9.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system','2019-11-28 20:18:52','system'),('01001','สามชั้นแผ่น (สด)',4,11,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01011','สามชั้นแผ่นตัดเส้น (สด) หน้ากว้าง 1 นิ้ว',4,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01012','สามชั้นแผ่นตัดเส้น (สด) หน้ากว้าง 2 นิ้ว',4,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01013','สามชั้นแผ่นตัดเส้น (สด) หน้ากว้าง 3 นิ้ว',4,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01021','สามชั้นบด 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01022','สามชั้นบด 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01023','สามชั้นบด 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01031','สามชั้นสไลด์ หน้ากว้าง 2 นิ้ว หนา 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01032','สามชั้นสไลด์ หน้ากว้าง 2 นิ้ว หนา 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01033','สามชั้นสไลด์ หน้ากว้าง 3 นิ้ว หนา 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01034','สามชั้นสไลด์ หน้ากว้าง 5 นิ้ว หนา 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01041','สามชั้นสเต็ก หน้ากว้าง 3.5 นิ้ว หนา 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01042','สามชั้นสเต็ก หน้ากว้าง 4.0 นิ้ว หนา 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01043','สามชั้นสเต็ก หน้ากว้าง 5.0 นิ้ว หนา 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:28:59','system',NULL,NULL),('01044','สามชั้นสเต็ก หน้ากว้าง 3.5 นิ้ว หนา 15 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01045','สามชั้นสเต็ก หน้ากว้าง 4.0 นิ้ว หนา 15 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01046','สามชั้นสเต็ก หน้ากว้าง 5.0 นิ้ว หนา 15 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01051','สามชั้นชาบู หน้ากว้าง 3.5 นิ้ว หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01052','สามชั้นชาบู หน้ากว้าง 4.0 นิ้ว หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01053','สามชั้นชาบู หน้ากว้าง 5.0 นิ้ว หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01054','สามชั้นชาบู หน้ากว้าง 3.5 นิ้ว หนา 1.5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01055','สามชั้นชาบู หน้ากว้าง 4.0 นิ้ว หนา 1.5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01056','สามชั้นชาบู หน้ากว้าง 5.0 นิ้ว หนา 1.5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01061','สามชั้นลอกหนังชาบู หน้ากว้าง 3.5 นิ้ว หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01062','สามชั้นลอกหนังชาบู หน้ากว้าง 4.0 นิ้ว หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01063','สามชั้นลอกหนังชาบู หน้ากว้าง 5.0 นิ้ว หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01064','สามชั้นลอกหนังชาบู หน้ากว้าง 3.5 นิ้ว หนา 1.5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01065','สามชั้นลอกหนังชาบู หน้ากว้าง 4.0 นิ้ว หนา 1.5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01066','สามชั้นลอกหนังชาบู หน้ากว้าง 5.0 นิ้ว หนา 1.5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01101','ไหล่ปั้น',4,15,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01111','ไหล่หน้า 1 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01112','ไหล่หน้า 2 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01113','ไหล่หน้า 3 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01121','ไหล่บด 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01122','ไหล่บด 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01123','ไหล่บด 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01131','ไหล่สไลด์ กว้าง 1 นิ้ว ยาว 1 นิ้ว หนา 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01132','ไหล่สไลด์ กว้าง 1 นิ้ว ยาว 1 นิ้ว หนา 4 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01133','ไหล่สไลด์ กว้าง 1 นิ้ว ยาว 1 นิ้ว หนา 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01134','ไหล่สไลด์ กว้าง 1 นิ้ว ยาว 2 นิ้ว หนา 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01135','ไหล่สไลด์ กว้าง 1 นิ้ว ยาว 2 นิ้ว หนา 4 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01136','ไหล่สไลด์ กว้าง 1 นิ้ว ยาว 2 นิ้ว หนา 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01201','สะโพกปั้น',4,15,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01211','สะโพกหน้า 1 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01212','สะโพกหน้า 2 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01213','สะโพกหน้า 3 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01221','สะโพกบด 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01222','สะโพกบด 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01223','สะโพกบด 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01231','สะโพกสไลด์ กว้าง 1 นิ้ว ยาว 1 นิ้ว หนา 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01232','สะโพกสไลด์ กว้าง 1 นิ้ว ยาว 1 นิ้ว หนา 4 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01233','สะโพกสไลด์ กว้าง 1 นิ้ว ยาว 1 นิ้ว หนา 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01234','สะโพกสไลด์ กว้าง 1 นิ้ว ยาว 2 นิ้ว หนา 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01235','สะโพกสไลด์ กว้าง 1 นิ้ว ยาว 2 นิ้ว หนา 4 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01236','สะโพกสไลด์ กว้าง 1 นิ้ว ยาว 2 นิ้ว หนา 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01301','สันคอปั้น',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01311','สันคอก้อนหนา 2 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01312','สันคอก้อนหนา 3 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01313','สันคอก้อนหนา 4 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01321','สันคอบด 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01322','สันคอบด 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01323','สันคอบด 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01351','สันคอชาบู หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01401','สันนอกเส้น',4,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01411','สันนอกก้อนหนา 2 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01412','สันนอกก้อนหนา 3 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01413','สันนอกก้อนหนา 4 นิ้ว',4,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01421','สันนอกบด 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01422','สันนอกบด 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01423','สันนอกบด 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01451','สันนอกชาบู หนา 2 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01501','สันในเส้น',4,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01521','สันในบด 3 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01522','สันในบด 5 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01523','สันในบด 8 มม',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01601','คอหมูย่าง',4,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01701','ขาหน้าเต็ม',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01711','ขาหน้าตัด+คากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01712','ขาหน้าตัด ไม่รวมคากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01721','ขาหน้าเลาะ ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01722','ขาหน้าเลาะ + คากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01723','ขาหน้าเลาะ + คากิหั่นแว่น',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01724','ขาหน้าเลาะ + คากิหั่นเต๋า',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01731','ขาหน้าเลาะหั่นเต๋า',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01732','ขาหน้าเลาะหั่นเต๋า + คากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01733','ขาหน้าเลาะหั่นเต๋า + คากิหั่นแว่น',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01734','ขาหน้าเลาะหั่นเต๋า + คากิหั่นเต๋า',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01801','ขาหลังเต็ม',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01811','ขาหลังตัด+คากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01812','ขาหลังตัด ไม่รวมคากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:00','system',NULL,NULL),('01821','ขาหลังเลาะ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01822','ขาหลังเลาะ + คากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01823','ขาหลังเลาะ + คากิหั่นแว่น',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01824','ขาหลังเลาะ + คากิหั่นเต๋า',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01831','ขาหลังเลาะหั่นเต๋า',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01832','ขาหลังเลาะหั่นเต๋า + คากิ',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01833','ขาหลังเลาะหั่นเต๋า + คากิหั่นแว่น',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('01834','ขาหลังเลาะหั่นเต๋า + คากิหั่นเต๋า',4,10,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02001','ซี่โครง',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02011','ซี่โครงตัดเส้น',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02021','ซี่โครงตัดชิ้น',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02031','ซี่โครงบาร์บีคิว',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02101','ซี่โครงอ่อน',5,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02121','ซี่โครงอ่อนตัดชิ้น',5,14,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02201','กระดูกอ่อน',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02221','กระดูกอ่อนหั่นชิ้น',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02301','กระดูกซุป',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02401','หาง',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02501','กระดูกข้อขา',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('02601','กระดูกใบพาย',5,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03001','หนังแผ่น',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03101','มันแคปไหล่',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03111','มันแคปไหล่หั่น กว้าง 1 นิ้ว ยาว 1 นิ้ว',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03201','มันแคปสะโพก',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03211','มันแคปสะโพกหั่น กว้าง 1 นิ้ว ยาว 1 นิ้ว',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03301','มันแคปสัน',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03311','มันแคปสันหั่น กว้าง 1 นิ้ว ยาว 1 นิ้ว',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03401','มันแคปคาง',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03411','มันแคปคางหั่น กว้าง 1 นิ้ว ยาว 1 นิ้ว',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03501','มันเปลว',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('03601','มันราวนม',6,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('04001','หัวหมู',7,13,4,0.50,5.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system','2019-11-28 20:19:06','system'),('04011','หน้ากากหมู',7,13,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('04101','หัวใจ',7,16,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('04201','ตับ',7,8,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('04301','ไต',7,12,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('04401','ปอด',7,8,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('04501','ลิ้น',7,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('05001','ม้าม',8,5,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('05101','กระเพาะ',8,12,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('05201','ไส้อ่อน',8,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('05301','ไส้ขม',8,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('05401','ไส้ใหญ่',8,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('05501','ไส้ตัน',8,9,4,0.00,0.00,0.00,'W','W',10,1.00,1,'2019-11-26 19:29:01','system',NULL,NULL),('NA','NA',1,1,1,0.00,0.00,0.00,'W','Q',0,1.00,0,'2019-08-11 12:24:32','system',NULL,NULL),('P001','หมูเป็น',1,1,4,60.00,150.00,100.00,'W','Q',60,100.00,0,'2019-06-22 14:52:35','system','2019-10-25 14:46:39','system');
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
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_group`
--

LOCK TABLES `product_group` WRITE;
/*!40000 ALTER TABLE `product_group` DISABLE KEYS */;
INSERT INTO `product_group` VALUES (1,'Raw Product',1,'2019-06-22 14:48:42','system','2019-09-20 15:13:25','system'),(2,'หมูซีก',1,'2019-09-23 10:16:30','system','2019-10-24 23:54:38','system'),(3,'เครื่องในชุด',1,'2019-09-23 10:33:25','system','2019-10-24 23:54:02','system'),(4,'เนื้อหลัก',1,'2019-10-24 19:38:20','system','2019-10-24 23:53:08','system'),(5,'กระดูก',1,'2019-10-24 23:54:10','system',NULL,NULL),(6,'มันและหนัง',1,'2019-10-24 23:54:21','system',NULL,NULL),(7,'เครื่องในขาว',1,'2019-11-26 18:40:43','system',NULL,NULL),(8,'เครื่องในแดง',1,'2019-11-26 18:40:43','system',NULL,NULL);
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
/*!40000 ALTER TABLE `product_price` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_slip`
--

DROP TABLE IF EXISTS `product_slip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_slip` (
  `product_slip_no` varchar(15) NOT NULL,
  `product_slip_date` date NOT NULL,
  `ref_document_no` varchar(15) NOT NULL,
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
  `product_slip_no` varchar(15) NOT NULL,
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
/*!40000 ALTER TABLE `product_slip_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production_order`
--

DROP TABLE IF EXISTS `production_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production_order` (
  `po_no` varchar(15) NOT NULL,
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
  `po_no` varchar(15) NOT NULL,
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
/*!40000 ALTER TABLE `production_order_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receive_item`
--

DROP TABLE IF EXISTS `receive_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `receive_item` (
  `receive_no` varchar(15) NOT NULL,
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
  KEY `idx_receive_item_01` (`seq`),
  CONSTRAINT `fk_receives_01` FOREIGN KEY (`receive_no`) REFERENCES `receives` (`receive_no`),
  CONSTRAINT `fk_receives_02` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receive_item`
--

LOCK TABLES `receive_item` WRITE;
/*!40000 ALTER TABLE `receive_item` DISABLE KEYS */;
INSERT INTO `receive_item` VALUES ('REV1911260001','00000',1,'1193301261101','',1,75.45,1,75.25,1,75.25,0,'2019-11-29 19:04:16','192.168.56.1','2019-12-05 22:44:22','192.168.56.1'),('REV1911260001','00000',2,'1193301261101','',1,78.50,0,0.00,0,0.00,0,'2019-12-03 22:50:31','192.168.56.1',NULL,NULL),('REV1911260001','00000',3,'1193301261101','',1,78.65,0,0.00,0,0.00,0,'2019-12-03 23:09:23','192.168.56.1',NULL,NULL),('REV1911260001','00000',4,'1193301261101','',1,78.65,0,0.00,0,0.00,0,'2019-12-03 23:09:29','192.168.56.1',NULL,NULL),('REV1911260001','00000',5,'1193301261101','',1,78.65,0,0.00,0,0.00,0,'2019-12-03 23:09:34','192.168.56.1',NULL,NULL),('REV1911260001','00101',1,'1193301261101','',1,7.89,0,0.00,0,0.00,12,'2019-12-03 19:04:47','192.168.56.1',NULL,NULL),('REV1911260001','00101',2,'1193301261101','',1,8.99,0,0.00,0,0.00,13,'2019-12-03 19:12:53','192.168.56.1',NULL,NULL),('REV1911260001','00101',3,'1193301261101','',1,8.89,0,0.00,0,0.00,14,'2019-12-03 19:14:37','192.168.56.1',NULL,NULL),('REV1911260001','00101',4,'1193301261101','',1,8.45,0,0.00,0,0.00,15,'2019-12-03 22:38:31','192.168.56.1',NULL,NULL),('REV1911260001','00101',5,'1193301261101','',1,8.45,0,0.00,0,0.00,16,'2019-12-03 22:38:34','192.168.56.1',NULL,NULL),('REV1911260001','00201',1,'1193301261101','',1,8.52,0,0.00,0,0.00,7,'2019-12-03 19:00:29','192.168.56.1',NULL,NULL),('REV1911260001','00201',2,'1193301261101','',1,8.52,0,0.00,0,0.00,8,'2019-12-03 19:00:35','192.168.56.1',NULL,NULL),('REV1911260001','00201',3,'1193301261101','',1,8.52,0,0.00,0,0.00,9,'2019-12-03 19:00:41','192.168.56.1',NULL,NULL),('REV1911260001','00201',4,'1193301261101','',1,8.52,0,0.00,0,0.00,10,'2019-12-03 19:00:46','192.168.56.1',NULL,NULL),('REV1911260001','00201',5,'1193301261101','',1,8.52,0,0.00,0,0.00,11,'2019-12-03 19:00:51','192.168.56.1',NULL,NULL),('REV1911260001','04001',1,'1193301261101','',1,4.55,0,0.00,0,0.00,1,'2019-11-28 20:02:59','192.168.56.1',NULL,NULL),('REV1911260001','04001',2,'1193301261101','',1,4.26,0,0.00,0,0.00,3,'2019-11-28 20:23:59','192.168.56.1',NULL,NULL),('REV1911260001','04001',3,'1193301261101','',1,4.26,0,0.00,0,0.00,4,'2019-11-28 20:28:42','192.168.56.1',NULL,NULL),('REV1911260001','04001',4,'1193301261101','',1,4.56,0,0.00,0,0.00,5,'2019-12-03 18:59:13','192.168.56.1',NULL,NULL),('REV1911260001','04001',5,'1193301261101','',1,4.56,0,0.00,0,0.00,6,'2019-12-03 18:59:22','192.168.56.1',NULL,NULL),('REV1911260001','P001',1,'1193301261101','F',1,70.00,0,0.00,0,0.00,0,'2019-11-27 19:07:49','192.168.56.1',NULL,NULL),('REV1911260001','P001',2,'1193301261101','F',1,70.00,0,0.00,0,0.00,0,'2019-11-27 19:07:56','192.168.56.1',NULL,NULL),('REV1911260001','P001',3,'1193301261101','F',1,70.00,0,0.00,0,0.00,0,'2019-11-27 19:08:00','192.168.56.1',NULL,NULL),('REV1911260001','P001',4,'1193301261101','F',1,70.00,0,0.00,0,0.00,0,'2019-11-27 19:08:04','192.168.56.1',NULL,NULL),('REV1911260001','P001',5,'1193301261101','F',1,70.00,0,0.00,0,0.00,0,'2019-11-27 19:08:08','192.168.56.1',NULL,NULL);
/*!40000 ALTER TABLE `receive_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receives`
--

DROP TABLE IF EXISTS `receives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `receives` (
  `receive_no` varchar(15) NOT NULL,
  `receive_date` date NOT NULL,
  `transport_doc_no` varchar(12) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `farm_code` varchar(10) NOT NULL,
  `coop_no` varchar(5) NOT NULL,
  `breeder_code` int(11) NOT NULL,
  `queue_no` int(11) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `farm_qty` int(11) NOT NULL DEFAULT '0',
  `farm_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `factory_qty` int(11) NOT NULL DEFAULT '0',
  `factory_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `carcass_qty` int(11) DEFAULT '0',
  `carcass_wgh` decimal(10,2) DEFAULT '0.00',
  `head_qty` int(11) DEFAULT '0',
  `head_wgh` decimal(10,2) DEFAULT '0.00',
  `byproduct_red_qty` int(11) DEFAULT '0',
  `byproduct_red_wgh` decimal(10,2) DEFAULT '0.00',
  `byproduct_white_qty` int(11) DEFAULT '0',
  `byproduct_white_wgh` decimal(10,2) DEFAULT '0.00',
  `receive_flag` int(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`receive_no`),
  KEY `fk_farm_01_idx` (`farm_code`),
  KEY `fk_breeder_01_idx` (`breeder_code`),
  KEY `idx_01` (`receive_date`,`receive_flag`),
  KEY `fk_truck_01_idx` (`truck_id`),
  CONSTRAINT `fk_breeder_01` FOREIGN KEY (`breeder_code`) REFERENCES `breeder` (`breeder_code`),
  CONSTRAINT `fk_farm_01` FOREIGN KEY (`farm_code`) REFERENCES `farm` (`farm_code`),
  CONSTRAINT `fk_truck_01` FOREIGN KEY (`truck_id`) REFERENCES `truck` (`truck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receives`
--

LOCK TABLES `receives` WRITE;
/*!40000 ALTER TABLE `receives` DISABLE KEYS */;
INSERT INTO `receives` VALUES ('REV1911260001','2019-11-26','SS20190121',3,'FARM0001','1',1,1,'1193301261101',5,500.00,5,350.00,5,389.90,5,22.19,5,42.67,5,42.60,1,'2019-11-26 19:43:38','system',NULL,NULL),('REV1911290002','2019-11-29','144545',3,'FARM0007','1',1,1,'1193331291101',6,600.00,0,0.00,0,0.00,0,0.00,0,0.00,0,0.00,0,'2019-11-29 19:06:25','system',NULL,NULL);
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
  `ref_document_no` varchar(15) DEFAULT NULL,
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
INSERT INTO `stock` VALUES ('2019-11-27','STK0000001',1,'00000',1,75.45,'REV','REV1911260001','1193301261101',2,1000000000000,1,'2019-11-29 19:04:16','192.168.56.1'),('2019-11-27','STK0000001',1,'00101',1,7.89,'REV','REV1911260001','1193301261101',3,1000000000012,1,'2019-12-03 19:04:47','192.168.56.1'),('2019-11-27','STK0000001',1,'00201',1,8.52,'REV','REV1911260001','1193301261101',4,1000000000007,1,'2019-12-03 19:00:29','192.168.56.1'),('2019-11-27','STK0000001',1,'04001',1,4.55,'REV','REV1911260001','1193301261101',8,1000000000001,1,'2019-11-28 20:02:59','192.168.56.1'),('2019-11-27','STK0000001',1,'P001',1,70.00,'REV','REV1911260001','1193301261101',1,1000000000000,1,'2019-11-27 19:07:49','192.168.56.1'),('2019-11-27','STK0000001',2,'00000',1,78.50,'REV','REV1911260001','1193301261101',2,1000000000000,1,'2019-12-03 22:50:31','192.168.56.1'),('2019-11-27','STK0000001',2,'00101',1,8.99,'REV','REV1911260001','1193301261101',3,1000000000013,1,'2019-12-03 19:12:53','192.168.56.1'),('2019-11-27','STK0000001',2,'00201',1,8.52,'REV','REV1911260001','1193301261101',4,1000000000008,1,'2019-12-03 19:00:35','192.168.56.1'),('2019-11-27','STK0000001',2,'04001',1,4.26,'REV','REV1911260001','1193301261101',8,1000000000003,1,'2019-11-28 20:23:59','192.168.56.1'),('2019-11-27','STK0000001',2,'P001',1,70.00,'REV','REV1911260001','1193301261101',1,1000000000000,1,'2019-11-27 19:07:56','192.168.56.1'),('2019-11-27','STK0000001',3,'00000',1,78.65,'REV','REV1911260001','1193301261101',2,1000000000000,1,'2019-12-03 23:09:23','192.168.56.1'),('2019-11-27','STK0000001',3,'00101',1,8.89,'REV','REV1911260001','1193301261101',3,1000000000014,1,'2019-12-03 19:14:37','192.168.56.1'),('2019-11-27','STK0000001',3,'00201',1,8.52,'REV','REV1911260001','1193301261101',4,1000000000009,1,'2019-12-03 19:00:41','192.168.56.1'),('2019-11-27','STK0000001',3,'04001',1,4.26,'REV','REV1911260001','1193301261101',8,1000000000004,1,'2019-11-28 20:28:42','192.168.56.1'),('2019-11-27','STK0000001',3,'P001',1,70.00,'REV','REV1911260001','1193301261101',1,1000000000000,1,'2019-11-27 19:08:00','192.168.56.1'),('2019-11-27','STK0000001',4,'00000',1,78.65,'REV','REV1911260001','1193301261101',2,1000000000000,1,'2019-12-03 23:09:29','192.168.56.1'),('2019-11-27','STK0000001',4,'00101',1,8.45,'REV','REV1911260001','1193301261101',3,1000000000015,1,'2019-12-03 22:38:31','192.168.56.1'),('2019-11-27','STK0000001',4,'00201',1,8.52,'REV','REV1911260001','1193301261101',4,1000000000010,1,'2019-12-03 19:00:46','192.168.56.1'),('2019-11-27','STK0000001',4,'04001',1,4.56,'REV','REV1911260001','1193301261101',8,1000000000005,1,'2019-12-03 18:59:13','192.168.56.1'),('2019-11-27','STK0000001',4,'P001',1,70.00,'REV','REV1911260001','1193301261101',1,1000000000000,1,'2019-11-27 19:08:04','192.168.56.1'),('2019-11-27','STK0000001',5,'00000',1,78.65,'REV','REV1911260001','1193301261101',2,1000000000000,1,'2019-12-03 23:09:34','192.168.56.1'),('2019-11-27','STK0000001',5,'00101',1,8.45,'REV','REV1911260001','1193301261101',3,1000000000016,1,'2019-12-03 22:38:34','192.168.56.1'),('2019-11-27','STK0000001',5,'00201',1,8.52,'REV','REV1911260001','1193301261101',4,1000000000011,1,'2019-12-03 19:00:51','192.168.56.1'),('2019-11-27','STK0000001',5,'04001',1,4.56,'REV','REV1911260001','1193301261101',8,1000000000006,1,'2019-12-03 18:59:22','192.168.56.1'),('2019-11-27','STK0000001',5,'P001',1,70.00,'REV','REV1911260001','1193301261101',1,1000000000000,1,'2019-11-27 19:08:08','192.168.56.1'),('2019-11-27','STK0000002',1,'00000',1,75.25,'SO','SO1912050001','1193301261101',2,1000000000000,2,'2019-12-05 22:44:20','192.168.56.1'),('2019-11-28','BF20191128',1,'00000',4,314.65,'BF','BF001','1193301261101',2,0,1,'2019-12-31 16:58:39','auto'),('2019-11-28','BF20191128',2,'00101',5,42.67,'BF','BF001','1193301261101',3,0,1,'2019-12-31 16:58:39','auto'),('2019-11-28','BF20191128',3,'00201',5,42.60,'BF','BF001','1193301261101',4,0,1,'2019-12-31 16:58:39','auto'),('2019-11-28','BF20191128',4,'04001',5,22.19,'BF','BF001','1193301261101',8,0,1,'2019-12-31 16:58:39','auto'),('2019-11-28','BF20191128',5,'P001',5,350.00,'BF','BF001','1193301261101',1,0,1,'2019-12-31 16:58:39','auto'),('2019-11-29','BF20191129',1,'00000',4,314.65,'BF','BF001','1193301261101',2,0,1,'2019-12-31 16:58:45','auto'),('2019-11-29','BF20191129',2,'00101',5,42.67,'BF','BF001','1193301261101',3,0,1,'2019-12-31 16:58:45','auto'),('2019-11-29','BF20191129',3,'00201',5,42.60,'BF','BF001','1193301261101',4,0,1,'2019-12-31 16:58:45','auto'),('2019-11-29','BF20191129',4,'04001',5,22.19,'BF','BF001','1193301261101',8,0,1,'2019-12-31 16:58:45','auto'),('2019-11-29','BF20191129',5,'P001',5,350.00,'BF','BF001','1193301261101',1,0,1,'2019-12-31 16:58:45','auto'),('2019-12-31','BF20191130',1,'00000',4,314.65,'BF','BF001','1193301261101',2,0,1,'2019-12-31 16:58:53','auto'),('2019-12-31','BF20191130',2,'00101',5,42.67,'BF','BF001','1193301261101',3,0,1,'2019-12-31 16:58:53','auto'),('2019-12-31','BF20191130',3,'00201',5,42.60,'BF','BF001','1193301261101',4,0,1,'2019-12-31 16:58:53','auto'),('2019-12-31','BF20191130',4,'04001',5,22.19,'BF','BF001','1193301261101',8,0,1,'2019-12-31 16:58:53','auto'),('2019-12-31','BF20191130',5,'P001',5,350.00,'BF','BF001','1193301261101',1,0,1,'2019-12-31 16:58:53','auto'),('2020-01-01','BF20200101',1,'00000',4,314.65,'BF','BF001','1193301261101',2,0,1,'2019-12-31 17:02:01','auto'),('2020-01-01','BF20200101',2,'00101',5,42.67,'BF','BF001','1193301261101',3,0,1,'2019-12-31 17:02:01','auto'),('2020-01-01','BF20200101',3,'00201',5,42.60,'BF','BF001','1193301261101',4,0,1,'2019-12-31 17:02:01','auto'),('2020-01-01','BF20200101',4,'04001',5,22.19,'BF','BF001','1193301261101',8,0,1,'2019-12-31 17:02:01','auto'),('2020-01-01','BF20200101',5,'P001',5,350.00,'BF','BF001','1193301261101',1,0,1,'2019-12-31 17:02:01','auto');
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
INSERT INTO `stock_item_running` VALUES ('REV1911260001','STK0000001',5,'2019-11-27 19:07:49','192.168.56.1',NULL,NULL),('SO1912050001','STK0000002',1,'2019-12-05 22:44:20','192.168.56.1',NULL,NULL);
/*!40000 ALTER TABLE `stock_item_running` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transport`
--

DROP TABLE IF EXISTS `transport`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transport` (
  `transport_no` varchar(15) NOT NULL,
  `transport_date` date NOT NULL,
  `ref_document_no` varchar(15) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `transport_flag` int(1) NOT NULL DEFAULT '0',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`transport_no`),
  KEY `idx_ref_docuemnt_no` (`ref_document_no`),
  KEY `fk_truck_01_idx` (`truck_id`),
  CONSTRAINT `fk_transport_truck` FOREIGN KEY (`truck_id`) REFERENCES `truck` (`truck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transport`
--

LOCK TABLES `transport` WRITE;
/*!40000 ALTER TABLE `transport` DISABLE KEYS */;
INSERT INTO `transport` VALUES ('TP00000001','2019-12-05','SO1912050001',1,0,'2019-12-05 22:44:20','192.168.56.1',NULL,NULL);
/*!40000 ALTER TABLE `transport` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transport_item`
--

DROP TABLE IF EXISTS `transport_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transport_item` (
  `transport_no` varchar(15) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `transport_qty` int(11) NOT NULL,
  `transport_wgh` decimal(10,0) NOT NULL,
  `stock_no` varchar(15) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `barcode_no` bigint(13) NOT NULL,
  `bom_code` int(11) NOT NULL DEFAULT '0',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  PRIMARY KEY (`transport_no`,`product_code`,`seq`),
  KEY `fk_transport_product` (`product_code`),
  KEY `fk_transport_item_truck_idx` (`truck_id`),
  CONSTRAINT `fk_transport_item_truck` FOREIGN KEY (`truck_id`) REFERENCES `truck` (`truck_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transport_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transport_item`
--

LOCK TABLES `transport_item` WRITE;
/*!40000 ALTER TABLE `transport_item` DISABLE KEYS */;
INSERT INTO `transport_item` VALUES ('TP00000001','00000',1,1,75,'STK0000002','1193301261101',1,0,1,'2019-12-05 22:44:20','192.168.56.1');
/*!40000 ALTER TABLE `transport_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `truck`
--

DROP TABLE IF EXISTS `truck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `truck` (
  `truck_id` int(11) NOT NULL AUTO_INCREMENT,
  `truck_no` varchar(10) NOT NULL,
  `driver` varchar(255) NOT NULL,
  `truck_type_id` int(11) NOT NULL DEFAULT '1',
  `active` tinyint(1) DEFAULT '1',
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) DEFAULT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`truck_id`),
  KEY `fk_truck_type_idx` (`truck_type_id`),
  CONSTRAINT `fk_truck_type` FOREIGN KEY (`truck_type_id`) REFERENCES `truck_type` (`truck_type_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `truck`
--

LOCK TABLES `truck` WRITE;
/*!40000 ALTER TABLE `truck` DISABLE KEYS */;
INSERT INTO `truck` VALUES (1,'2ฒต 3389','ธวัชชัย ไวเจริญ',2,1,'2019-10-24 23:50:13','system','2019-11-03 11:11:54',NULL),(2,'2ฒย 791','รัตนศักดิ์ สุขาฉายี',2,1,'2019-10-24 23:50:23','system','2019-11-03 11:18:33',NULL),(3,'82-4383','พรเทพ สืบวงศ์',1,1,'2019-10-24 23:50:03','system',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `truck_type`
--

LOCK TABLES `truck_type` WRITE;
/*!40000 ALTER TABLE `truck_type` DISABLE KEYS */;
INSERT INTO `truck_type` VALUES (1,'ส่งหมูเป็น',1,'2019-10-25 14:04:00','system',NULL,NULL),(2,'รับสินค้า',1,'2019-10-25 14:04:00','system','2019-11-20 20:17:51','system'),(7,'อื่น ๆๆ',1,'2019-11-20 20:23:38','system','2019-11-20 20:23:43','system');
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit_of_measurement`
--

LOCK TABLES `unit_of_measurement` WRITE;
/*!40000 ALTER TABLE `unit_of_measurement` DISABLE KEYS */;
INSERT INTO `unit_of_measurement` VALUES (1,'ตัว',1,'2019-06-22 14:50:59','system',NULL,NULL),(2,'ซีก',1,'2019-06-22 14:50:59','system',NULL,NULL),(3,'กรัม',1,'2019-06-22 14:50:59','system','2019-10-20 12:06:55','system'),(4,'กิโลกรัม',1,'2019-06-22 14:50:59','system',NULL,NULL),(5,'ชิ้น',1,'2019-07-20 17:03:32','system',NULL,NULL),(6,'ถุง',1,'2019-08-29 18:20:15','system',NULL,NULL),(7,'ชุด',1,'2019-08-29 18:20:21','system',NULL,NULL),(8,'พวง',1,'2019-09-23 13:30:09','system',NULL,NULL),(9,'แพ็ค',1,'2019-11-26 19:14:42','system',NULL,NULL),(10,'ขา',1,'2019-11-26 19:15:00','system',NULL,NULL),(11,'แผ่น',1,'2019-11-26 19:15:11','system',NULL,NULL),(12,'ลูก',1,'2019-11-26 19:15:21','system',NULL,NULL),(13,'หัว',1,'2019-11-26 19:15:31','system',NULL,NULL),(14,'เส้น',1,'2019-11-26 19:15:51','system',NULL,NULL),(15,'ปั้น',1,'2019-11-26 19:16:05','system',NULL,NULL),(16,'ดวง',1,'2019-11-26 19:27:19','system',NULL,NULL);
/*!40000 ALTER TABLE `unit_of_measurement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `name` varchar(100) NOT NULL,
  `group_id` int(11) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`user_id`),
  KEY `fk_user_group_idx` (`group_id`),
  CONSTRAINT `fk_user_group` FOREIGN KEY (`group_id`) REFERENCES `group` (`group_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES ('admin','9999','Admin',1,1,'2019-11-24 11:37:41','system',NULL,NULL);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'slaughterhouse'
--

--
-- Dumping routines for database 'slaughterhouse'
--
/*!50003 DROP PROCEDURE IF EXISTS `CancelStockBfDay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `CancelStockBfDay`(IN pDate date)
BEGIN
 DELETE FROM stock
    WHERE stock_date  = pDate
    AND ref_document_type = 'BF'
    AND transaction_type = 1 ;
    
UPDATE slaughterhouse.plant 
SET 
    production_date = DATE_ADD(pDate, INTERVAL -1 DAY)
WHERE
    plant_id = 1; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `GenStockBfDay` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `GenStockBfDay`(IN pDate date)
BEGIN
 DELETE FROM stock
    WHERE stock_date  = DATE_ADD(pDate, INTERVAL 1 DAY)
    AND ref_document_type = 'BF'
    AND transaction_type = 1 ;
    
UPDATE slaughterhouse.plant 
SET 
    production_date = DATE_ADD(pDate, INTERVAL 1 DAY)
WHERE
    plant_id = 1;
    
	SET @row_number = 0;
    INSERT INTO slaughterhouse.stock
	  (stock_date,
	  stock_no,
	  stock_item,
	  product_code,
	  stock_qty,
	  stock_wgh,
	  ref_document_type,
	  ref_document_no,
	  lot_no,
	  location_code,
	  barcode_no,
	  transaction_type, 
	  create_by)
	SELECT 
    tb.stock_date,
    tb.stock_no,
    (@row_number:=@row_number + 1) AS stock_item,
    product_code,
    stock_qty,
    stock_wgh,
    ref_document_type,
    ref_document_no,
    tb.lot_no,
    tb.location_code,
    tb.barcode_no,
    tb.transaction_type,
    tb.create_by
FROM
    (SELECT 
        DATE_ADD(s.stock_date, INTERVAL 1 DAY) AS stock_date,
		CONCAT('BF', DATE_FORMAT(DATE_ADD(s.stock_date, INTERVAL 1 DAY), '%Y%m%d')) AS stock_no,
		0 AS stock_item,
		s.product_code,
		SUM(CASE
			WHEN s.transaction_type = '1' THEN s.stock_qty
			ELSE s.stock_qty * - 1
		END) AS stock_qty,
		SUM(CASE
			WHEN s.transaction_type = '1' THEN s.stock_wgh
			ELSE s.stock_wgh * - 1
		END) AS stock_wgh,
		'BF' AS ref_document_type,
		'BF001' AS ref_document_no,
		s.lot_no,
		s.location_code,
		0 AS barcode_no,
		1 AS transaction_type,
		'auto' AS create_by
    FROM
        slaughterhouse.stock s
    WHERE
        s.stock_date = pDate
    GROUP BY   s.product_code , s.lot_no , s.location_code , DATE_ADD(s.stock_date, INTERVAL 1 DAY),
		CONCAT('BF', DATE_FORMAT(DATE_ADD(s.stock_date, INTERVAL 1 DAY), '%Y%m%d'))
    ) tb
    where tb.stock_qty > 0
; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-01 17:16:39
