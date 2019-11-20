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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:56
