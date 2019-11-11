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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:58:00
