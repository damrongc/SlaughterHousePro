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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:58
