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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:59
