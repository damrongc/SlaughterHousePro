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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:55
