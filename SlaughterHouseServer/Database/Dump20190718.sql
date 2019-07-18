CREATE DATABASE  IF NOT EXISTS `slaughterhouse` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `slaughterhouse`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: slaughterhouse
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `barcode`
--

DROP TABLE IF EXISTS `barcode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `barcode` (
  `barcode_no` int(13) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `qty` int(11) NOT NULL DEFAULT '0',
  `wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  PRIMARY KEY (`barcode_no`),
  KEY `fk_barcode_product_idx` (`product_code`),
  CONSTRAINT `fk_barcode_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `barcode`
--

LOCK TABLES `barcode` WRITE;
/*!40000 ALTER TABLE `barcode` DISABLE KEYS */;
/*!40000 ALTER TABLE `barcode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `breeder`
--

DROP TABLE IF EXISTS `breeder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `customer_code` varchar(10) NOT NULL,
  `customer_name` varchar(200) NOT NULL,
  `address` varchar(200) NOT NULL,
  `ship_to` varchar(200) NOT NULL,
  `tax_id` varchar(10) DEFAULT NULL,
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
INSERT INTO `customer` VALUES ('001','customer001','xx','xx','xx','xx',1,'2019-07-03 18:20:28','system',NULL,NULL);
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `document_generate`
--

DROP TABLE IF EXISTS `document_generate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
INSERT INTO `document_generate` VALUES ('INV',1,'2019-06-14 19:18:00',NULL,'เอกสาร invoice'),('ISS',1,'2019-06-14 19:18:00',NULL,'เอกสารเบิก'),('PDL',1,'2019-06-22 16:17:31',NULL,'product lot no'),('PO',1,'2019-07-18 19:32:23',NULL,'Production order no'),('REV',4,'2019-06-14 19:18:00','2019-07-04 20:27:31','เอกสารรับหมูเป็น'),('SO',2,'2019-06-14 19:18:00','2019-06-14 19:49:39','เอกสาร sales order'),('STK',5,'2019-06-28 18:55:46',NULL,'Stock document no'),('SWL',1,'2019-06-22 15:49:34',NULL,'Lot No รับหมูเป็น');
/*!40000 ALTER TABLE `document_generate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `farm`
--

DROP TABLE IF EXISTS `farm`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
INSERT INTO `farm` VALUES ('001','ฟาร์มเอ','บางใหญ่',1,'2019-06-15 20:30:44','system','2019-06-20 23:41:33','system'),('002','ฟาร์มบี','บางบังทอง',1,'2019-06-15 21:41:16','system','2019-06-20 23:41:40','system'),('011','fafafsa','ส้กาฟหก่ฟหก\r\nาฟห้กสฟาหกฟ',1,'2019-06-15 15:50:56','damrong','2019-06-15 21:27:13','system'),('111','asdasd','asdasd',1,'2019-06-24 12:53:24','system',NULL,NULL);
/*!40000 ALTER TABLE `farm` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `invoice` (
  `invoice_no` varchar(10) NOT NULL,
  `invoice_date` date NOT NULL,
  `ref_document_no` varchar(10) NOT NULL,
  `customer_code` varchar(10) NOT NULL,
  `gross_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `discount` decimal(12,2) NOT NULL DEFAULT '0.00',
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
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice_item`
--

DROP TABLE IF EXISTS `invoice_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `invoice_item` (
  `invoice_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `qty` int(11) NOT NULL DEFAULT '0',
  `wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `gross_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `net_amt` decimal(12,2) NOT NULL DEFAULT '0.00',
  `sale_unit_method` varchar(3) NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`invoice_no`,`product_code`),
  KEY `fk_invitem_product_idx` (`product_code`),
  CONSTRAINT `fk_invitem_inv` FOREIGN KEY (`invoice_no`) REFERENCES `invoice` (`invoice_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_invitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice_item`
--

LOCK TABLES `invoice_item` WRITE;
/*!40000 ALTER TABLE `invoice_item` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoice_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `location`
--

DROP TABLE IF EXISTS `location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `location` (
  `location_code` int(11) NOT NULL AUTO_INCREMENT,
  `location_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`location_code`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `location`
--

LOCK TABLES `location` WRITE;
/*!40000 ALTER TABLE `location` DISABLE KEYS */;
INSERT INTO `location` VALUES (1,'ลานพักหมูเป็น',1,'2019-06-22 15:10:45','system',NULL,NULL),(2,'ห้องเย็นเก็บหมุซีก',1,'2019-06-29 20:53:54','system',NULL,NULL),(3,'ห้องเย็นเก็บเครื่องในแดง',1,'2019-06-29 20:53:54','system',NULL,NULL),(4,'ห้องเย็นเก็บเครื่องในขาว',1,'2019-06-29 20:53:54','system',NULL,NULL),(5,'ห้องเก็บชิ้นส่วน1',1,'2019-06-29 20:53:54','system',NULL,NULL),(6,'ห้องเก็บชิ้นส่วน2',1,'2019-06-29 20:53:54','system',NULL,NULL);
/*!40000 ALTER TABLE `location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_item`
--

DROP TABLE IF EXISTS `order_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_item` (
  `order_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `order_qty` int(11) NOT NULL DEFAULT '0',
  `order_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `unload_qty` int(11) NOT NULL DEFAULT '0',
  `unload_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`order_no`,`product_code`),
  KEY `fk_order_product_idx` (`product_code`),
  CONSTRAINT `fk_order_orderitem` FOREIGN KEY (`order_no`) REFERENCES `orders` (`order_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_item`
--

LOCK TABLES `order_item` WRITE;
/*!40000 ALTER TABLE `order_item` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  CONSTRAINT `fk_order_customer` FOREIGN KEY (`customer_code`) REFERENCES `customer` (`customer_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER after_order_created
AFTER INSERT ON `orders` FOR EACH ROW BEGIN
	UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='SO';
	

END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `plant`
--

DROP TABLE IF EXISTS `plant`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
INSERT INTO `plant` VALUES (1,'2019-06-22','บริษัท พี.เค.พี 6 จำกัด','85/1 หมู่ 1 ตำบลไม้เค็ด อำเภอเมืองปราจีนบุรี จ.ปราจีนบุรี 25230','000');
/*!40000 ALTER TABLE `plant` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `product_code` varchar(10) NOT NULL,
  `product_name` varchar(200) NOT NULL,
  `product_group_code` int(11) NOT NULL,
  `unit_of_qty` int(11) NOT NULL,
  `unit_of_wgh` int(11) NOT NULL,
  `min_weight` decimal(10,2) DEFAULT '0.00',
  `max_weight` decimal(10,2) DEFAULT '0.00',
  `std_yield` decimal(10,2) DEFAULT '0.00',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_code`),
  KEY `fk_product_group_idx` (`product_group_code`),
  KEY `fk_unit_qty_idx` (`unit_of_qty`),
  KEY `fk_unit_wgh_idx` (`unit_of_wgh`),
  CONSTRAINT `fk_product_group` FOREIGN KEY (`product_group_code`) REFERENCES `product_group` (`product_group_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_unit_qty` FOREIGN KEY (`unit_of_qty`) REFERENCES `unit_of_measurement` (`unit_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_unit_wgh` FOREIGN KEY (`unit_of_wgh`) REFERENCES `unit_of_measurement` (`unit_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('P001','หมูเป็น',1,1,4,0.00,0.00,0.00,1,'2019-06-22 14:52:35','system',NULL,NULL),('P002','หมูซีก',1,2,4,0.00,0.00,0.00,1,'2019-06-22 14:53:11','system',NULL,NULL),('P003','หัว',1,1,4,0.00,0.00,0.00,1,'2019-06-23 13:27:34','system',NULL,NULL),('P004','เครื่องในแดง',2,1,4,0.00,0.00,0.00,1,'2019-06-23 15:18:30','system',NULL,NULL),('P005','เครื่องในขาว',3,1,4,0.00,0.00,0.00,1,'2019-07-08 23:06:39','system',NULL,NULL),('P4001','หัวใจ',2,1,4,0.00,0.00,0.00,1,'2019-07-08 23:08:18','system',NULL,NULL),('P4002','ตับ',2,1,1,0.00,0.00,0.00,1,'2019-07-08 23:08:18','system',NULL,NULL),('P4003','ไต',2,1,4,0.00,0.00,0.00,1,'2019-07-08 23:08:18','system',NULL,NULL),('P5001','กระเพาะ',3,1,4,0.00,0.00,0.00,1,'2019-07-08 23:09:14','system',NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_group`
--

DROP TABLE IF EXISTS `product_group`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_group` (
  `product_group_code` int(11) NOT NULL AUTO_INCREMENT,
  `product_group_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`product_group_code`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_group`
--

LOCK TABLES `product_group` WRITE;
/*!40000 ALTER TABLE `product_group` DISABLE KEYS */;
INSERT INTO `product_group` VALUES (1,'สินค้ารับเข้า',1,'2019-06-22 14:48:42','system',NULL,NULL),(2,'เครื่องในแดง',1,'2019-07-08 22:52:47','system',NULL,NULL),(3,'เครื่องในขาว',1,'2019-07-08 22:53:08','system',NULL,NULL);
/*!40000 ALTER TABLE `product_group` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_price`
--

DROP TABLE IF EXISTS `product_price`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_price` (
  `product_code` varchar(10) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `sale_unit_method` varchar(2) NOT NULL COMMENT 'Q/W',
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
-- Table structure for table `production_order`
--

DROP TABLE IF EXISTS `production_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
INSERT INTO `production_order` VALUES ('PO00000001','2019-07-18',0,'ทดสอบ',1,'2019-07-18 19:46:05','system',NULL,NULL);
/*!40000 ALTER TABLE `production_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production_order_item`
--

DROP TABLE IF EXISTS `production_order_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  CONSTRAINT `fk_porderitem_order` FOREIGN KEY (`po_no`) REFERENCES `production_order` (`po_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_porderitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_order_item`
--

LOCK TABLES `production_order_item` WRITE;
/*!40000 ALTER TABLE `production_order_item` DISABLE KEYS */;
INSERT INTO `production_order_item` VALUES ('PO00000001','P002',1,5,0.00,0,0.00,'2019-07-18 19:46:12','system',NULL,NULL);
/*!40000 ALTER TABLE `production_order_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receive_item`
--

DROP TABLE IF EXISTS `receive_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `receive_item` (
  `receive_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `lot_no` varchar(13) DEFAULT NULL,
  `sex_flag` varchar(1) NOT NULL DEFAULT 'F',
  `receive_qty` int(11) NOT NULL DEFAULT '0',
  `receive_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `chill_qty` int(11) DEFAULT '0',
  `chill_wgh` decimal(10,2) DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`receive_no`,`product_code`,`seq`),
  KEY `fk_receives_02_idx` (`product_code`),
  CONSTRAINT `fk_receives_01` FOREIGN KEY (`receive_no`) REFERENCES `receives` (`receive_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_receives_02` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receive_item`
--

LOCK TABLES `receive_item` WRITE;
/*!40000 ALTER TABLE `receive_item` DISABLE KEYS */;
INSERT INTO `receive_item` VALUES ('REV0000003','P001',1,'11918510407','F',1,100.00,0,0.00,'2019-07-04 22:38:21','auto',NULL,NULL),('REV0000003','P001',2,'11918510407','F',1,100.00,0,0.00,'2019-07-04 22:39:06','auto',NULL,NULL),('REV0000003','P001',3,'11918510407','M',1,100.00,0,0.00,'2019-07-04 22:45:45','auto',NULL,NULL),('REV0000003','P001',4,'11918510407','F',1,100.00,0,0.00,'2019-07-04 22:46:47','auto',NULL,NULL),('REV0000003','P001',5,'11918510407','F',1,100.00,0,0.00,'2019-07-04 22:46:50','auto',NULL,NULL),('REV0000003','P002',1,'11918510407','',1,85.00,0,0.00,'2019-07-04 23:23:27','auto',NULL,NULL),('REV0000003','P002',2,'11918510408','',1,85.00,0,0.00,'2019-07-04 23:29:54','auto',NULL,NULL),('REV0000003','P002',3,'11918510409','',1,85.00,0,0.00,'2019-07-04 23:30:52','auto',NULL,NULL),('REV0000003','P002',4,'11918510407','',1,85.00,0,0.00,'2019-07-04 23:30:55','auto',NULL,NULL),('REV0000003','P002',5,'11918510407','',1,85.00,0,0.00,'2019-07-04 23:30:56','auto',NULL,NULL);
/*!40000 ALTER TABLE `receive_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `receives`
--

DROP TABLE IF EXISTS `receives`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
  KEY `receives_receive_flag_index` (`receive_flag`),
  CONSTRAINT `fk_breeder_01` FOREIGN KEY (`breeder_code`) REFERENCES `breeder` (`breeder_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_farm_01` FOREIGN KEY (`farm_code`) REFERENCES `farm` (`farm_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `receives`
--

LOCK TABLES `receives` WRITE;
/*!40000 ALTER TABLE `receives` DISABLE KEYS */;
INSERT INTO `receives` VALUES ('REV0000001','2019-06-19','132456','1234','001','5',1,1,'',100,200.55,3,0.00,1,'2019-06-19 00:02:14','damrong',NULL,NULL),('REV0000002','2019-06-19','132456','1234','001','5',1,2,'',100,255.54,4,0.00,0,'2019-06-19 00:08:56','damrong',NULL,NULL),('REV0000003','2019-07-04','T001','a001','001','1',1,1,'11918510407',5,200.00,5,500.00,1,'2019-07-04 20:27:31','damrong','2019-07-04 23:13:36','system');
/*!40000 ALTER TABLE `receives` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER after_receive_created
AFTER INSERT ON `receives` FOR EACH ROW BEGIN
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
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stock` (
  `stock_date` date NOT NULL,
  `stock_no` varchar(15) NOT NULL,
  `stock_item` int(11) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `stock_qty` int(11) NOT NULL DEFAULT '0',
  `stock_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `ref_document_type` varchar(10) NOT NULL,
  `ref_document_no` varchar(10) NOT NULL,
  `lot_no` varchar(13) NOT NULL,
  `location_code` int(11) NOT NULL,
  `barcode_no` int(11) NOT NULL,
  `transaction_type` int(1) NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  PRIMARY KEY (`stock_date`,`stock_no`,`stock_item`,`product_code`),
  KEY `fk_stock_product_idx` (`product_code`),
  KEY `fk_stock_location_idx` (`location_code`),
  CONSTRAINT `fk_stock_location` FOREIGN KEY (`location_code`) REFERENCES `location` (`location_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_stock_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stock`
--

LOCK TABLES `stock` WRITE;
/*!40000 ALTER TABLE `stock` DISABLE KEYS */;
INSERT INTO `stock` VALUES ('2019-07-04','STK0000004',1,'P001',1,100.00,'REV','REV0000003','11918510407',1,0,1,'2019-07-04 22:38:21','auto'),('2019-07-04','STK0000004',1,'P002',1,85.00,'REV','REV0000003','11918510407',2,0,1,'2019-07-04 23:23:27','auto'),('2019-07-04','STK0000004',2,'P001',1,100.00,'REV','REV0000003','11918510407',1,0,1,'2019-07-04 22:39:06','auto'),('2019-07-04','STK0000004',2,'P002',1,85.00,'REV','REV0000003','11918510407',2,0,1,'2019-07-04 23:29:54','auto'),('2019-07-04','STK0000004',3,'P001',1,100.00,'REV','REV0000003','11918510407',1,0,1,'2019-07-04 22:45:45','auto'),('2019-07-04','STK0000004',3,'P002',1,85.00,'REV','REV0000003','11918510407',2,0,1,'2019-07-04 23:30:52','auto'),('2019-07-04','STK0000004',4,'P001',1,100.00,'REV','REV0000003','11918510407',1,0,1,'2019-07-04 22:46:47','auto'),('2019-07-04','STK0000004',4,'P002',1,85.00,'REV','REV0000003','11918510407',2,0,1,'2019-07-04 23:30:55','auto'),('2019-07-04','STK0000004',5,'P001',1,100.00,'REV','REV0000003','11918510407',1,0,1,'2019-07-04 22:46:50','auto'),('2019-07-04','STK0000004',5,'P002',1,85.00,'REV','REV0000003','11918510407',2,0,1,'2019-07-04 23:30:56','auto');
/*!40000 ALTER TABLE `stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stock_item_running`
--

DROP TABLE IF EXISTS `stock_item_running`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
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
INSERT INTO `stock_item_running` VALUES ('REV0000001','STK0000001',1,'2019-06-28 19:23:58','system',NULL,NULL),('REV0000003','STK0000004',5,'2019-07-04 22:38:21','auto',NULL,NULL);
/*!40000 ALTER TABLE `stock_item_running` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit_of_measurement`
--

DROP TABLE IF EXISTS `unit_of_measurement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unit_of_measurement` (
  `unit_code` int(11) NOT NULL AUTO_INCREMENT,
  `unit_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`unit_code`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit_of_measurement`
--

LOCK TABLES `unit_of_measurement` WRITE;
/*!40000 ALTER TABLE `unit_of_measurement` DISABLE KEYS */;
INSERT INTO `unit_of_measurement` VALUES (1,'ตัว',1,'2019-06-22 14:50:59','system',NULL,NULL),(2,'ซีก',1,'2019-06-22 14:50:59','system',NULL,NULL),(3,'กรัม',1,'2019-06-22 14:50:59','system',NULL,NULL),(4,'กิโลกรัม',1,'2019-06-22 14:50:59','system',NULL,NULL);
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

-- Dump completed on 2019-07-18 21:06:35
