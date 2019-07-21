-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 21, 2019 at 07:34 PM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `slaughterhouse`
--

-- --------------------------------------------------------

--
-- Table structure for table `barcode`
--

CREATE TABLE `barcode` (
  `barcode_no` int(13) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `qty` int(11) NOT NULL DEFAULT '0',
  `wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `breeder`
--

CREATE TABLE `breeder` (
  `breeder_code` int(11) NOT NULL,
  `breeder_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `breeder`
--

INSERT INTO `breeder` (`breeder_code`, `breeder_name`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
(1, 'หมูขาว', 1, '2019-06-18 23:05:24', 'damrong', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`customer_code`, `customer_name`, `address`, `ship_to`, `tax_id`, `contact_no`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('001', 'Iron Man', '10880 Malibu Point, Florida United Sta\r\n320032', 'Malibu', '1234455587', '0981562333', 1, '2019-07-03 18:20:28', 'system', '2019-07-20 14:16:45', 'system'),
('002', 'จอนวิค', '1880 สารทร กรุงเทพ 120520', 'บางรัก', '1759000021', '0981562200', 1, '2019-07-03 15:48:53', 'system', '2019-07-20 14:17:03', 'system'),
('003', 'สมชาย ใจดี', '12/7 ต.นาขวาง อ.เมือง\r\nจ.สมุทรสาคร 75000', 'โกดัง 15 ท่าเรือมมหาชัย', '1254785695', '0997847589', 1, '2019-07-16 09:42:45', 'system', '2019-07-20 14:05:56', 'system');

-- --------------------------------------------------------

--
-- Table structure for table `document_generate`
--

CREATE TABLE `document_generate` (
  `document_type` varchar(3) NOT NULL,
  `running` int(11) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_at` datetime DEFAULT NULL,
  `description` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `document_generate`
--

INSERT INTO `document_generate` (`document_type`, `running`, `create_at`, `modified_at`, `description`) VALUES
('INV', 6, '2019-06-14 19:18:00', '2019-07-21 15:04:47', 'เอกสาร invoice'),
('ISS', 1, '2019-06-14 19:18:00', NULL, 'เอกสารเบิก'),
('PDL', 1, '2019-06-22 16:17:31', NULL, 'product lot no'),
('PO', 9, '2019-07-03 16:28:14', '2019-07-20 14:51:01', NULL),
('REV', 4, '2019-06-14 19:18:00', '2019-07-20 14:20:27', 'เอกสารรับหมูเป็น'),
('SO', 14, '2019-06-14 19:18:00', '2019-07-21 15:03:41', 'เอกสาร sales order'),
('STK', 1, '2019-06-28 18:55:46', NULL, 'Stock document no'),
('SWL', 1, '2019-06-22 15:49:34', NULL, 'Lot No รับหมูเป็น');

-- --------------------------------------------------------

--
-- Table structure for table `farm`
--

CREATE TABLE `farm` (
  `farm_code` varchar(10) NOT NULL,
  `farm_name` varchar(200) NOT NULL,
  `address` varchar(500) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `farm`
--

INSERT INTO `farm` (`farm_code`, `farm_name`, `address`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('001', 'ฟาร์มเอ', '120/15 บางใหญ่ กรุงเทพ 10111', 1, '2019-06-15 20:30:44', 'system', '2019-07-20 14:05:47', 'system');

-- --------------------------------------------------------

--
-- Table structure for table `invoice`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `invoice`
--

INSERT INTO `invoice` (`invoice_no`, `invoice_date`, `ref_document_no`, `customer_code`, `gross_amt`, `discount`, `vat_rate`, `vat_amt`, `net_amt`, `invoice_flag`, `comments`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('INV0000001', '2019-07-16', 'SO00000008', '003', '27300.00', '200.00', '0.00', '0.00', '27100.00', 0, '', 0, '2019-07-16 11:20:35', 'system', '2019-07-20 12:00:55', 'system'),
('INV0000002', '2019-07-16', 'SO00000008', '003', '27300.00', '150.00', '0.00', '0.00', '27150.00', 0, '', 0, '2019-07-16 23:01:50', 'system', '2019-07-18 22:06:34', 'system'),
('INV0000003', '2019-07-20', 'SO00000012', '002', '22500.00', '350.00', '7.00', '1550.50', '23700.50', 0, '', 1, '2019-07-20 18:31:26', 'system', '2019-07-21 17:16:41', 'system'),
('INV0000004', '2019-07-20', 'SO00000011', '001', '17135.00', '1713.00', '7.00', '1079.54', '16501.54', 0, '', 1, '2019-07-21 12:12:47', 'system', NULL, NULL),
('INV0000005', '2019-07-21', 'SO00000013', '003', '34595.00', '100.00', '0.00', '0.00', '34495.00', 0, '', 1, '2019-07-21 15:04:47', 'system', NULL, NULL);

--
-- Triggers `invoice`
--
DELIMITER $$
CREATE TRIGGER `after_invoice_created` AFTER INSERT ON `invoice` FOR EACH ROW BEGIN
 UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='INV';
 

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `invoice_item`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `invoice_item`
--

INSERT INTO `invoice_item` (`invoice_no`, `product_code`, `seq`, `qty`, `wgh`, `unit_price`, `gross_amt`, `net_amt`, `sale_unit_method`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('INV0000003', 'P002', 1, 0, '150.00', '150.00', '22500.00', '0.00', 'W', '2019-07-21 17:16:41', 'system', NULL, NULL),
('INV0000004', 'P001', 2, 0, '10.00', '98.00', '980.00', '0.00', 'W', '2019-07-21 12:12:47', 'system', NULL, NULL),
('INV0000004', 'P004', 1, 0, '200.00', '75.00', '15000.00', '0.00', 'W', '2019-07-21 12:12:47', 'system', NULL, NULL),
('INV0000004', 'P005', 3, 15, '0.00', '77.00', '1155.00', '0.00', 'Q', '2019-07-21 12:12:47', 'system', NULL, NULL),
('INV0000005', 'P001', 2, 0, '190.00', '98.00', '18620.00', '0.00', 'W', '2019-07-21 15:04:47', 'system', NULL, NULL),
('INV0000005', 'P004', 1, 0, '213.00', '75.00', '15975.00', '0.00', 'W', '2019-07-21 15:04:47', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `location`
--

CREATE TABLE `location` (
  `location_code` int(11) NOT NULL,
  `location_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `location`
--

INSERT INTO `location` (`location_code`, `location_name`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
(1, 'ลานพักหมูเป็น', 1, '2019-06-22 15:10:45', 'system', NULL, NULL),
(2, 'ห้องเย็นเก็บหมุซีก', 1, '2019-06-29 20:53:54', 'system', NULL, NULL),
(3, 'ห้องเย็นเก็บเครื่องในแดง', 1, '2019-06-29 20:53:54', 'system', NULL, NULL),
(4, 'ห้องเย็นเก็บเครื่องในขาว', 1, '2019-06-29 20:53:54', 'system', NULL, NULL),
(5, 'ห้องเก็บชิ้นส่วน1', 1, '2019-06-29 20:53:54', 'system', NULL, NULL),
(6, 'ห้องเก็บชิ้นส่วน2', 1, '2019-06-29 20:53:54', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `orders`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `orders`
--

INSERT INTO `orders` (`order_no`, `order_date`, `customer_code`, `order_flag`, `invoice_flag`, `comments`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('SO00000011', '2019-07-20', '001', 1, 1, 'ลูกค้าต้องการสินค้าบ่าย 3', 1, '2019-07-20 14:36:13', 'system', '2019-07-20 18:25:16', 'system'),
('SO00000012', '2019-07-20', '002', 1, 1, 'ขอสด ๆๆ', 1, '2019-07-20 14:38:44', 'system', '2019-07-20 18:04:54', 'system'),
('SO00000013', '2019-07-21', '003', 1, 1, 'AAAA', 1, '2019-07-21 15:03:41', 'system', NULL, NULL);

--
-- Triggers `orders`
--
DELIMITER $$
CREATE TRIGGER `after_order_created` AFTER INSERT ON `orders` FOR EACH ROW BEGIN
	UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='SO';
	

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `order_item`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `order_item`
--

INSERT INTO `order_item` (`order_no`, `product_code`, `seq`, `order_qty`, `order_wgh`, `unload_qty`, `unload_wgh`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('SO00000011', 'P001', 2, 0, '30.00', 0, '10.00', '2019-07-20 18:25:16', 'system', NULL, NULL),
('SO00000011', 'P004', 1, 0, '200.00', 0, '200.00', '2019-07-20 18:25:16', 'system', NULL, NULL),
('SO00000011', 'P005', 3, 15, '0.00', 15, '0.00', '2019-07-20 18:25:16', 'system', NULL, NULL),
('SO00000012', 'P002', 1, 0, '150.00', 0, '150.00', '2019-07-20 18:04:54', 'system', NULL, NULL),
('SO00000013', 'P001', 2, 0, '190.00', 0, '190.00', '2019-07-21 15:03:42', 'system', NULL, NULL),
('SO00000013', 'P004', 1, 0, '213.00', 0, '213.00', '2019-07-21 15:03:41', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `plant`
--

CREATE TABLE `plant` (
  `plant_id` int(11) NOT NULL,
  `production_date` date NOT NULL,
  `plant_name` varchar(100) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `est_no` varchar(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `plant`
--

INSERT INTO `plant` (`plant_id`, `production_date`, `plant_name`, `address`, `est_no`) VALUES
(1, '2019-06-22', 'บริษัท พี.เค.พี 6 จำกัด', '85/1 หมู่ 1 ตำบลไม้เค็ด อำเภอเมืองปราจีนบุรี จ.ปราจีนบุรี 25230', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

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
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`product_code`, `product_name`, `product_group_code`, `unit_of_qty`, `unit_of_wgh`, `min_weight`, `max_weight`, `std_yield`, `sale_unit_method`, `issue_unit_method`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('P001', 'หมูเป็น', 1, 1, 4, '0.00', '0.00', '0.00', 'W', 'Q', 1, '2019-06-22 14:52:35', 'system', '2019-07-20 17:00:46', 'system'),
('P002', 'หมูซีก', 1, 2, 4, '0.00', '0.00', '0.00', 'W', 'Q', 1, '2019-06-22 14:53:11', 'system', '2019-07-20 17:00:51', 'system'),
('P003', 'หัว', 1, 1, 4, '0.00', '0.00', '0.00', 'W', 'W', 1, '2019-06-23 13:27:34', 'system', '2019-07-20 17:00:59', 'system'),
('P004', 'เครื่องใน', 1, 1, 4, '0.00', '0.00', '0.00', 'W', 'W', 1, '2019-06-23 15:18:30', 'system', '2019-07-20 17:01:07', 'system'),
('P005', 'หางหมู', 2, 5, 3, '0.00', '0.00', '0.00', 'Q', 'Q', 1, '2019-07-20 17:03:15', 'system', '2019-07-20 18:01:57', 'system'),
('P006', 'ขา', 2, 5, 4, '1.00', '0.00', '0.00', 'W', 'W', 1, '2019-07-20 17:05:40', 'system', '2019-07-20 17:59:04', 'system'),
('P007', 'คอหมู', 2, 5, 4, '0.00', '0.00', '0.00', 'W', 'W', 1, '2019-07-20 18:00:09', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `production_order`
--

CREATE TABLE `production_order` (
  `po_no` varchar(10) NOT NULL,
  `po_date` date NOT NULL,
  `po_flag` int(1) NOT NULL DEFAULT '0' COMMENT '0= Create\n1= Close',
  `comments` varchar(200) DEFAULT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `production_order`
--

INSERT INTO `production_order` (`po_no`, `po_date`, `po_flag`, `comments`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('PO00000008', '2019-07-20', 0, 'zxzxzxzx', 1, '2019-07-20 14:51:01', 'system', '2019-07-20 18:07:34', 'system');

--
-- Triggers `production_order`
--
DELIMITER $$
CREATE TRIGGER `after_production_order_created` AFTER INSERT ON `production_order` FOR EACH ROW BEGIN
 UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='PO';
 

END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `production_order_item`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `production_order_item`
--

INSERT INTO `production_order_item` (`po_no`, `product_code`, `seq`, `po_qty`, `po_wgh`, `unload_qty`, `unload_wgh`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('PO00000008', 'P001', 1, 0, '10.00', 0, '0.00', '2019-07-20 18:07:34', 'system', NULL, NULL),
('PO00000008', 'P004', 2, 0, '200.00', 0, '0.00', '2019-07-20 18:07:34', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `product_group`
--

CREATE TABLE `product_group` (
  `product_group_code` int(11) NOT NULL,
  `product_group_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_group`
--

INSERT INTO `product_group` (`product_group_code`, `product_group_name`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
(1, 'สินค้ารับเข้า', 1, '2019-06-22 14:48:42', 'system', NULL, NULL),
(2, 'สินค้าออก', 1, '2019-07-20 14:17:36', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `product_price`
--

CREATE TABLE `product_price` (
  `product_code` varchar(10) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `unit_price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product_price`
--

INSERT INTO `product_price` (`product_code`, `start_date`, `end_date`, `unit_price`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('P001', '2019-07-01', '2019-07-26', '98.00', '2019-07-21 12:10:53', 'system', NULL, NULL),
('P001', '2019-07-03', '2019-10-31', '13.00', '2019-07-03 18:32:48', 'system', '2019-07-20 15:52:10', 'system'),
('P001', '2019-07-04', '2019-07-07', '12.30', '2019-07-03 19:57:15', 'system', NULL, NULL),
('P001', '2019-07-16', '2019-07-17', '20.00', '2019-07-16 11:18:40', 'system', '2019-07-20 14:42:22', 'system'),
('P002', '2019-07-04', '2019-07-14', '300.00', '2019-07-03 19:57:46', 'system', NULL, NULL),
('P002', '2019-07-16', '2019-08-15', '150.00', '2019-07-16 11:18:54', 'system', '2019-07-20 15:51:51', 'system'),
('P003', '2019-07-16', '2019-08-15', '75.00', '2019-07-16 11:19:04', 'system', '2019-07-20 15:51:56', 'system'),
('P004', '2019-07-16', '2019-08-15', '75.00', '2019-07-16 11:19:15', 'system', '2019-07-20 15:52:03', 'system'),
('P005', '2019-07-01', '2019-07-31', '77.00', '2019-07-21 12:11:25', 'system', '2019-07-21 12:11:58', 'system'),
('P005', '2019-07-21', '2019-09-19', '75.00', '2019-07-21 12:09:30', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `receives`
--

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
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `receives`
--

INSERT INTO `receives` (`receive_no`, `receive_date`, `transport_doc_no`, `truck_no`, `farm_code`, `coop_no`, `breeder_code`, `queue_no`, `lot_no`, `farm_qty`, `farm_wgh`, `factory_qty`, `factory_wgh`, `receive_flag`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('REV0000001', '2019-06-19', '132456', '1234', '001', '5', 1, 1, '', 100, '200.55', 3, '0.00', 1, '2019-06-19 00:02:14', 'damrong', NULL, NULL),
('REV0000002', '2019-06-19', '132456', '1234', '001', '5', 1, 2, '', 100, '255.54', 4, '0.00', 0, '2019-06-19 00:08:56', 'damrong', NULL, NULL),
('REV0000003', '2019-07-20', '1235001', '295 กทม.', '001', 'A101', 1, 1, '11920112007', 200, '5200.00', 0, '0.00', 1, '2019-07-20 14:20:27', 'damrong', '2019-07-20 14:20:35', 'system');

--
-- Triggers `receives`
--
DELIMITER $$
CREATE TRIGGER `after_receive_created` AFTER INSERT ON `receives` FOR EACH ROW BEGIN
	UPDATE document_generate  SET running= running+1,modified_at =NOW()
    WHERE document_type='REV';
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `receive_item`
--

CREATE TABLE `receive_item` (
  `receive_no` varchar(10) NOT NULL,
  `product_code` varchar(10) NOT NULL,
  `seq` int(11) NOT NULL,
  `sex_flag` varchar(1) NOT NULL DEFAULT 'F',
  `receive_qty` int(11) NOT NULL DEFAULT '0',
  `receive_wgh` decimal(10,2) NOT NULL DEFAULT '0.00',
  `chill_qty` int(11) DEFAULT '0',
  `chill_wgh` decimal(10,2) DEFAULT '0.00',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `receive_item`
--

INSERT INTO `receive_item` (`receive_no`, `product_code`, `seq`, `sex_flag`, `receive_qty`, `receive_wgh`, `chill_qty`, `chill_wgh`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('REV0000001', 'P001', 1, 'F', 1, '0.00', 0, '0.00', '2019-06-22 14:07:37', 'Auto', NULL, NULL),
('REV0000001', 'P001', 2, 'F', 1, '0.00', 0, '0.00', '2019-06-22 14:17:46', 'Auto', NULL, NULL),
('REV0000001', 'P001', 3, 'F', 1, '0.00', 0, '0.00', '2019-06-22 14:32:41', 'Auto', NULL, NULL),
('REV0000001', 'P002', 1, '', 1, '0.00', 0, '0.00', '2019-06-28 19:52:15', 'Auto', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `stock`
--

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
  `create_by` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stock`
--

INSERT INTO `stock` (`stock_date`, `stock_no`, `stock_item`, `product_code`, `stock_qty`, `stock_wgh`, `ref_document_type`, `ref_document_no`, `lot_no`, `location_code`, `barcode_no`, `transaction_type`, `create_at`, `create_by`) VALUES
('2019-06-05', 'STK0000001', 1, 'P001', 500, '5000.00', 'REV', 'REV0000001', '11917912206', 1, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-06', 'STK0000002', 1, 'P001', 400, '0.00', 'ISS', 'ISS0000002', '11917912206', 1, 0, 2, '2019-06-28 19:23:37', 'system'),
('2019-06-06', 'STK0000002.2', 1, 'P002', 800, '4400.00', 'ISS', 'POV0000001', '11917912206', 2, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000003', 1, 'P002', 100, '900.00', 'ISS', '', '11917912206', 2, 0, 2, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000003', 2, 'P002', 150, '1400.00', 'ISS', '', '11917912206', 2, 0, 2, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000004', 1, 'P004', 550, '5000.00', 'ISS', '', '11917912206', 3, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000004', 2, 'P004', 450, '4000.00', 'ISS', '', '11917912206', 3, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000005', 1, 'P003', 250, '1700.00', 'ISS', '', '11917912206', 5, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000006', 1, 'P006', 80, '780.00', 'ISS', '', '11917912206', 5, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-07', 'STK0000007', 1, 'P007', 200, '700.00', '', '', '11917912206', 5, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-12', 'STK00000011', 1, 'P006', 250, '1500.00', 'ISS', '', '11917912206', 5, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-12', 'STK00000011.2', 1, 'P002', 200, '4400.00', 'ISS', 'POV0000001', '11917912206', 2, 0, 1, '2019-06-28 19:23:37', 'system'),
('2019-06-12', 'STK0000008', 1, 'P001', 100, '0.00', 'ISS', '', '11917912206', 1, 0, 2, '2019-06-28 19:23:37', 'system'),
('2019-06-12', 'STK0000010', 1, 'P002', 60, '900.00', 'ISS', '', '11917912206', 2, 0, 2, '2019-06-28 19:23:37', 'system'),
('2019-06-15', 'STK00000012', 1, 'P006', 300, '1300.00', 'SO', '', '11917912206', 5, 0, 2, '2019-06-28 19:23:37', 'system'),
('2019-06-15', 'STK00000013', 1, 'P007', 52, '108.00', 'SO', '', '11917912206', 5, 0, 2, '2019-06-28 19:23:37', 'system');

-- --------------------------------------------------------

--
-- Table structure for table `stock_item_running`
--

CREATE TABLE `stock_item_running` (
  `doc_no` varchar(15) NOT NULL,
  `stock_no` varchar(15) NOT NULL,
  `stock_item` int(11) NOT NULL,
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stock_item_running`
--

INSERT INTO `stock_item_running` (`doc_no`, `stock_no`, `stock_item`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
('REV0000001', 'STK0000001', 1, '2019-06-28 19:23:58', 'system', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `unit_of_measurement`
--

CREATE TABLE `unit_of_measurement` (
  `unit_code` int(11) NOT NULL,
  `unit_name` varchar(45) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '1',
  `create_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `create_by` varchar(45) NOT NULL,
  `modified_at` datetime DEFAULT NULL,
  `modified_by` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `unit_of_measurement`
--

INSERT INTO `unit_of_measurement` (`unit_code`, `unit_name`, `active`, `create_at`, `create_by`, `modified_at`, `modified_by`) VALUES
(1, 'ตัว', 1, '2019-06-22 14:50:59', 'system', NULL, NULL),
(2, 'ซีก', 1, '2019-06-22 14:50:59', 'system', NULL, NULL),
(3, 'กรัม', 1, '2019-06-22 14:50:59', 'system', NULL, NULL),
(4, 'กิโลกรัม', 1, '2019-06-22 14:50:59', 'system', NULL, NULL),
(5, 'ชิ้น', 1, '2019-07-20 17:03:32', 'system', NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barcode`
--
ALTER TABLE `barcode`
  ADD PRIMARY KEY (`barcode_no`),
  ADD KEY `fk_barcode_product_idx` (`product_code`);

--
-- Indexes for table `breeder`
--
ALTER TABLE `breeder`
  ADD PRIMARY KEY (`breeder_code`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customer_code`);

--
-- Indexes for table `document_generate`
--
ALTER TABLE `document_generate`
  ADD PRIMARY KEY (`document_type`);

--
-- Indexes for table `farm`
--
ALTER TABLE `farm`
  ADD PRIMARY KEY (`farm_code`);

--
-- Indexes for table `invoice`
--
ALTER TABLE `invoice`
  ADD PRIMARY KEY (`invoice_no`);

--
-- Indexes for table `invoice_item`
--
ALTER TABLE `invoice_item`
  ADD PRIMARY KEY (`invoice_no`,`product_code`),
  ADD KEY `fk_invitem_product_idx` (`product_code`);

--
-- Indexes for table `location`
--
ALTER TABLE `location`
  ADD PRIMARY KEY (`location_code`);

--
-- Indexes for table `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_no`),
  ADD KEY `fk_order_customer_idx` (`customer_code`);

--
-- Indexes for table `order_item`
--
ALTER TABLE `order_item`
  ADD PRIMARY KEY (`order_no`,`product_code`),
  ADD KEY `fk_order_product_idx` (`product_code`);

--
-- Indexes for table `plant`
--
ALTER TABLE `plant`
  ADD PRIMARY KEY (`plant_id`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`product_code`),
  ADD KEY `fk_product_group_idx` (`product_group_code`),
  ADD KEY `fk_unit_qty_idx` (`unit_of_qty`),
  ADD KEY `fk_unit_wgh_idx` (`unit_of_wgh`);

--
-- Indexes for table `production_order`
--
ALTER TABLE `production_order`
  ADD PRIMARY KEY (`po_no`);

--
-- Indexes for table `production_order_item`
--
ALTER TABLE `production_order_item`
  ADD PRIMARY KEY (`po_no`,`product_code`),
  ADD KEY `fk_porderitem_product_idx` (`product_code`);

--
-- Indexes for table `product_group`
--
ALTER TABLE `product_group`
  ADD PRIMARY KEY (`product_group_code`);

--
-- Indexes for table `product_price`
--
ALTER TABLE `product_price`
  ADD PRIMARY KEY (`product_code`,`start_date`);

--
-- Indexes for table `receives`
--
ALTER TABLE `receives`
  ADD PRIMARY KEY (`receive_no`),
  ADD KEY `fk_farm_01_idx` (`farm_code`),
  ADD KEY `fk_breeder_01_idx` (`breeder_code`);

--
-- Indexes for table `receive_item`
--
ALTER TABLE `receive_item`
  ADD PRIMARY KEY (`receive_no`,`product_code`,`seq`),
  ADD KEY `fk_receives_02_idx` (`product_code`);

--
-- Indexes for table `stock`
--
ALTER TABLE `stock`
  ADD PRIMARY KEY (`stock_date`,`stock_no`,`stock_item`,`product_code`),
  ADD KEY `fk_stock_product_idx` (`product_code`),
  ADD KEY `fk_stock_location_idx` (`location_code`);

--
-- Indexes for table `stock_item_running`
--
ALTER TABLE `stock_item_running`
  ADD PRIMARY KEY (`doc_no`,`stock_no`);

--
-- Indexes for table `unit_of_measurement`
--
ALTER TABLE `unit_of_measurement`
  ADD PRIMARY KEY (`unit_code`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `breeder`
--
ALTER TABLE `breeder`
  MODIFY `breeder_code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `location`
--
ALTER TABLE `location`
  MODIFY `location_code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `plant`
--
ALTER TABLE `plant`
  MODIFY `plant_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `product_group`
--
ALTER TABLE `product_group`
  MODIFY `product_group_code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `unit_of_measurement`
--
ALTER TABLE `unit_of_measurement`
  MODIFY `unit_code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `barcode`
--
ALTER TABLE `barcode`
  ADD CONSTRAINT `fk_barcode_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `invoice_item`
--
ALTER TABLE `invoice_item`
  ADD CONSTRAINT `fk_invitem_inv` FOREIGN KEY (`invoice_no`) REFERENCES `invoice` (`invoice_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_invitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `fk_order_customer` FOREIGN KEY (`customer_code`) REFERENCES `customer` (`customer_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `order_item`
--
ALTER TABLE `order_item`
  ADD CONSTRAINT `fk_order_orderitem` FOREIGN KEY (`order_no`) REFERENCES `orders` (`order_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_order_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `fk_product_group` FOREIGN KEY (`product_group_code`) REFERENCES `product_group` (`product_group_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_unit_qty` FOREIGN KEY (`unit_of_qty`) REFERENCES `unit_of_measurement` (`unit_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_unit_wgh` FOREIGN KEY (`unit_of_wgh`) REFERENCES `unit_of_measurement` (`unit_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `production_order_item`
--
ALTER TABLE `production_order_item`
  ADD CONSTRAINT `fk_porderitem_order` FOREIGN KEY (`po_no`) REFERENCES `production_order` (`po_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_porderitem_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `receives`
--
ALTER TABLE `receives`
  ADD CONSTRAINT `fk_breeder_01` FOREIGN KEY (`breeder_code`) REFERENCES `breeder` (`breeder_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_farm_01` FOREIGN KEY (`farm_code`) REFERENCES `farm` (`farm_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `receive_item`
--
ALTER TABLE `receive_item`
  ADD CONSTRAINT `fk_receives_01` FOREIGN KEY (`receive_no`) REFERENCES `receives` (`receive_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_receives_02` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `stock`
--
ALTER TABLE `stock`
  ADD CONSTRAINT `fk_stock_location` FOREIGN KEY (`location_code`) REFERENCES `location` (`location_code`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_stock_product` FOREIGN KEY (`product_code`) REFERENCES `product` (`product_code`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
