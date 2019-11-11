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
  `sale_unit_method` varchar(1) NOT NULL,
  `issue_unit_method` varchar(1) NOT NULL,
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
INSERT INTO `product` VALUES ('0001','หมูซีก รวมหัวเครื่องใน',7,7,4,60.00,90.00,65.00,'W','Q',NULL,65.00,1,'2019-10-25 00:00:18','system',NULL,NULL),('NA','NA',1,1,1,0.00,0.00,0.00,'W','Q',0,1.00,0,'2019-08-11 12:24:32','system',NULL,NULL),('P001','หมูเป็น',1,1,4,0.50,150.00,100.00,'W','Q',60,110.00,0,'2019-06-22 14:52:35','system','2019-09-28 20:54:06','system'),('P002','หมูซีก',1,2,4,0.50,90.00,78.50,'W','Q',60,95.00,1,'2019-06-22 14:53:11','system','2019-09-30 09:39:42','system'),('P0021','สะโพก- Raw',5,4,4,0.00,0.00,0.00,'W','W',60,65.00,1,'2019-06-22 14:53:11','system','2019-09-29 00:25:24','system'),('P0022','สามชั้น- Raw',5,4,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-09-23 11:34:42','system'),('P0023','เนื้อไหล่- Raw',5,4,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-09-23 11:34:51','system'),('P0024','สันนอก- Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0025','สันคอ- Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0026','ซี่โครงแผ่น - Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0027','สันใน- Raw',5,2,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-07-20 17:00:51','system'),('P0028','คอหมูย่าง- Raw',1,5,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-22 14:53:11','system','2019-10-24 19:46:40','system'),('P003','เครื่องในแดง-ชุด',6,7,4,0.00,0.00,3.83,'W','Q',60,1.00,1,'2019-06-23 15:18:30','system','2019-10-10 19:25:57','system'),('P0031','ตับ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0032','ปอด',6,8,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-09-23 13:30:30','system'),('P0033','หัวใจ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0034','ขั้วตับ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0035','ม้าม',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-08-29 18:21:31','system'),('P0036','ไต',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-06-23 15:18:30','system','2019-10-24 19:36:20','system'),('P004','เครื่องในขาว-ชุด',6,7,4,0.50,7.00,5.17,'W','Q',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-10 19:25:08','system'),('P0041','ไส้อ่อน',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0042','ไส้ขม',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-24 19:36:29','system'),('P0043','ไส้ใหญ่',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0044','กระเพาะ',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0045','เศษมัน',6,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0046','ไส้ตัน',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P005','หัวหมู',6,7,4,0.50,5.00,5.00,'W','Q',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-24 19:36:36','system'),('P0051','กระโหลก',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0052','หน้ากาก',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0053','ลิ้น',1,5,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-10-24 19:46:47','system'),('P0054','เศษมันคอ',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P0055','เนื้อแก้ม',1,7,4,0.00,0.00,0.00,'W','W',60,1.00,1,'2019-07-20 18:00:09','system','2019-08-29 18:21:00','system'),('P009','หมูชุด ซีก+หัว+เครื่องใน+เลือด',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:13:01','system','2019-10-24 19:34:30','system'),('P010','หมูชุด ซีก+หัว+เครื่องใน+เลือด ขึ้นโครง',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:13:55','system','2019-10-24 19:34:46','system'),('P011','หมูชุด ไม่หัว ไม่เครื่องใน',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:14:52','system','2019-10-24 19:35:52','system'),('P012','หมูชุด ไม่หัว ไม่เครื่องใน (ขึ้นโครง)',7,7,4,0.00,0.00,0.00,'W','Q',NULL,1.00,1,'2019-09-23 10:16:07','system','2019-10-24 19:35:42','system'),('P0201','สามชั้นแผ่นตัดเส้น',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:37:13','system',NULL,NULL),('P0202','สามชั้นแผ่นสไลด์ ชาบู',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:38:55','system',NULL,NULL),('P0203','สันนอกแผ่นสไลด์ ชาบู',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:44:51','system',NULL,NULL),('P0204','สันคอแผ่นสไลด์ ชาบู',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:45:36','system',NULL,NULL),('P0205','สันคอสเต็ก',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:46:06','system',NULL,NULL),('P0206','สันนอกสเต็ก',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:46:49','system',NULL,NULL),('P0207','เนื้อหมูสไลด์',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:48:21','system',NULL,NULL),('P0208','คอหมูย่าง',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:48:47','system',NULL,NULL),('P0209','หมูบด 10% 1 kg',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:49:34','system',NULL,NULL),('P0210','หมูบด 20% 1 kg',1,4,4,0.00,0.00,0.00,'W','W',NULL,1.00,1,'2019-09-23 12:50:19','system',NULL,NULL);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-25 13:57:51
