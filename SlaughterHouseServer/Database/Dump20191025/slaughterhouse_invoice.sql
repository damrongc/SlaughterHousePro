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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:56
