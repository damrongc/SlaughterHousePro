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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:57
