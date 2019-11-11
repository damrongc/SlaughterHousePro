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
INSERT INTO `receives` VALUES ('REV0000001','2019-09-06','TS001','1234','001','1',1,1,'11924910609',5,500.00,5,500.00,0,'2019-09-06 18:23:54','damrong','2019-09-06 18:24:06',NULL),('REV0000002','2019-09-22','1223','12','001','1',1,1,'11926512209',1,11.00,1,1.20,0,'2019-09-22 10:38:04','damrong',NULL,NULL),('REV0000003','2019-09-23','TS20190923','1234','003','A1',1,1,'11926612309',10,500.00,10,100.00,1,'2019-09-23 16:23:48','damrong',NULL,NULL),('REV0000004','2019-10-10','123','23','001','A101',1,1,'1192831101001',23,230.00,2,155.00,1,'2019-10-10 18:46:46','system',NULL,NULL),('REV0000005','2019-10-24','TP19100001','ออ 1234','001','5',1,1,'1192971241001',10,1000.00,10,941.30,1,'2019-10-24 21:22:05','system','2019-10-24 22:10:07',NULL),('REV0000006','2019-10-25','191025001','1234','002','1',1,1,'1192981251001',5,500.00,5,462.00,1,'2019-10-25 11:10:52','system',NULL,NULL);
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:52
