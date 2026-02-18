/*M!999999\- enable the sandbox mode */ 
-- MariaDB dump 10.19  Distrib 10.11.14-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: AdhiSreeTransportDB2
-- ------------------------------------------------------
-- Server version	10.11.14-MariaDB-0ubuntu0.24.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `DestinationGroups`
--

DROP TABLE IF EXISTS `DestinationGroups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `DestinationGroups` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `TransportId` bigint(20) NOT NULL,
  `DestinationId` smallint(6) NOT NULL,
  `DestinationGroupId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_DestinationGroups_DestinationGroupId` (`DestinationGroupId`),
  KEY `IX_DestinationGroups_DestinationId` (`DestinationId`),
  CONSTRAINT `FK_DestinationGroups_Party` FOREIGN KEY (`DestinationId`) REFERENCES `Party` (`ID`),
  CONSTRAINT `FK_DestinationGroups_Party_DestinationId` FOREIGN KEY (`DestinationId`) REFERENCES `Party` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_DestinationGroups_TransportEntry_DestinationGroupId` FOREIGN KEY (`DestinationGroupId`) REFERENCES `TransportEntry` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DestinationGroups`
--

LOCK TABLES `DestinationGroups` WRITE;
/*!40000 ALTER TABLE `DestinationGroups` DISABLE KEYS */;
INSERT INTO `DestinationGroups` VALUES
(1,1,1,NULL),
(2,1,2,NULL),
(34,7,1,NULL),
(35,7,2,NULL),
(36,11,2,NULL),
(37,12,2,NULL),
(38,12,1,NULL),
(41,11,1,11),
(42,11,2,11),
(52,6,1,6),
(53,6,2,6),
(54,2,1,2),
(65,1,1,1),
(66,1,2,1),
(67,1,1,1),
(68,1,2,1),
(69,1,1,1),
(70,1,2,1),
(71,1,4,1);
/*!40000 ALTER TABLE `DestinationGroups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `District`
--

DROP TABLE IF EXISTS `District`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `District` (
  `ID` varchar(255) NOT NULL,
  `Name` longtext NOT NULL,
  `Code` longtext NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `StateId` varchar(255) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `IX_District_StateId` (`StateId`),
  CONSTRAINT `FK_District_State_StateId` FOREIGN KEY (`StateId`) REFERENCES `State` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `District`
--

LOCK TABLES `District` WRITE;
/*!40000 ALTER TABLE `District` DISABLE KEYS */;
INSERT INTO `District` VALUES
('1','Ariyalur','',1,'12'),
('10','Kanchipuram','',1,'12'),
('11','Kanyakumari','',1,'12'),
('12','Karur','',1,'12'),
('1201','Alappuzha','',1,'12'),
('1202','Ernakulam','',1,'12'),
('1203','Idukki','',1,'12'),
('1204','Kannur','',1,'12'),
('1205','Kasaragod','',1,'12'),
('1206','Kollam','',1,'12'),
('1207','Kottayam','',1,'12'),
('1208','Kozhikode','',1,'12'),
('1209','Malappuram','',1,'12'),
('1210','Palakkad','',1,'12'),
('1211','Pathanamthitta','',1,'12'),
('1212','Thiruvananthapuram','',1,'12'),
('1213','Thrissur','',1,'12'),
('1214','Wayanad','',1,'12'),
('13','Krishnagiri','',1,'12'),
('14','Madurai','',1,'12'),
('15','Mayiladuthurai','',1,'12'),
('16','Nagapattinam','',1,'12'),
('17','Namakkal','',1,'12'),
('18','Nilgiris','',1,'12'),
('19','Perambalur','',1,'12'),
('2','Chengalpattu','',1,'12'),
('20','Pudukkottai','',1,'12'),
('21','Ramanathapuram','',1,'12'),
('22','Ranipet','',1,'12'),
('23','Salem','',1,'12'),
('24','Sivaganga','',1,'12'),
('25','Tenkasi','',1,'12'),
('26','Thanjavur','',1,'12'),
('27','Theni','',1,'12'),
('28','Thoothukudi','',1,'12'),
('29','Tiruchirappalli','',1,'12'),
('3','Chennai','',1,'12'),
('30','Tirunelveli','',1,'12'),
('31','Tirupathur','',1,'12'),
('32','Tiruppur','',1,'12'),
('33','Tiruvallur','',1,'12'),
('34','Tiruvannamalai','',1,'12'),
('35','Tiruvarur','',1,'12'),
('36','Vellore','',1,'12'),
('37','Viluppuram','',1,'12'),
('39','Bagalkot','',1,'12'),
('4','Coimbatore','',1,'12'),
('40','Ballari','',1,'12'),
('41','Belagavi','',1,'12'),
('42','Bengaluru Rural','',1,'12'),
('43','Bengaluru Urban','',1,'12'),
('44','Bidar','',1,'12'),
('45','Chamarajanagar','',1,'12'),
('46','Chikkaballapur','',1,'12'),
('47','Chikkamagaluru','',1,'12'),
('48','Chitradurga','',1,'12'),
('49','Dakshina Kannada','',1,'12'),
('5','Cuddalore','',1,'12'),
('50','Davanagere','',1,'12'),
('51','Dharwad','',1,'12'),
('52','Gadag','',1,'12'),
('53','Hassan','',1,'12'),
('54','Haveri','',1,'12'),
('55','Kalaburagi','',1,'12'),
('56','Kodagu','',1,'12'),
('57','Kolar','',1,'12'),
('58','Koppal','',1,'12'),
('59','Mandya','',1,'12'),
('6','Dharmapuri','',1,'12'),
('60','Mysuru','',1,'12'),
('61','Raichur','',1,'12'),
('62','Ramanagara','',1,'12'),
('63','Shivamogga','',1,'12'),
('64','Tumakuru','',1,'12'),
('65','Udupi','',1,'12'),
('66','Uttara Kannada','',1,'12'),
('67','Vijayanagara','',1,'12'),
('68','Vijayapura','',1,'12'),
('69','Yadgir','',1,'12'),
('7','Dindigul','',1,'12'),
('70','Alluri Sitharama Raju','',1,'12'),
('71','Anakapalli','',1,'12'),
('72','Anantapur','',1,'12'),
('73','Annamayya','',1,'12'),
('74','Bapatla','',1,'12'),
('75','Chittoor','',1,'12'),
('76','Dr. B.R. Ambedkar Konaseema','',1,'12'),
('77','East Godavari','',1,'12'),
('78','Eluru','',1,'12'),
('79','Guntur','',1,'12'),
('8','Erode','',1,'12'),
('80','Kakinada','',1,'12'),
('81','Krishna','',1,'12'),
('82','Kurnool','',1,'12'),
('83','Nandyal','',1,'12'),
('84','NTR','',1,'12'),
('85','Palnadu','',1,'12'),
('86','Parvathipuram Manyam','',1,'12'),
('87','Prakasam','',1,'12'),
('88','Sri Potti Sriramulu Nellore','',1,'12'),
('89','Sri Sathya Sai','',1,'12'),
('9','Kallakurichi','',1,'12'),
('90','Srikakulam','',1,'12'),
('91','Tirupati','',1,'12'),
('92','Visakhapatnam','',1,'12'),
('93','Vizianagaram','',1,'12'),
('94','West Godavari','',1,'12'),
('95','YSR Kadapa','',1,'12');
/*!40000 ALTER TABLE `District` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Driver`
--

DROP TABLE IF EXISTS `Driver`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `Driver` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `AdhaarNo` longtext NOT NULL,
  `Mobile1` varchar(50) NOT NULL,
  `Mobile2` varchar(50) NOT NULL,
  `AddressLine1` varchar(256) NOT NULL,
  `AddressLine2` varchar(256) DEFAULT NULL,
  `AccountId` int(11) NOT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 0,
  `LicenceNo` longtext NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Driver`
--

LOCK TABLES `Driver` WRITE;
/*!40000 ALTER TABLE `Driver` DISABLE KEYS */;
INSERT INTO `Driver` VALUES
(1,'Vijayan','1031991043','8078560444','7884393113','ABC1','XYZ2',2,1,'MVLK192A123'),
(2,'Kiran','AD10013421','8978565444','7834323113','ABCB','XYZ',1,0,'MVLK192A125'),
(3,'Manoj','3732 3838 3832 9983','9845673234','789856787','Ad1','Ad2',0,0,'DE23453322');
/*!40000 ALTER TABLE `Driver` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Location`
--

DROP TABLE IF EXISTS `Location`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `Location` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Code` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `DistrictId` varchar(255) NOT NULL DEFAULT '',
  `IsActive` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID`),
  KEY `IX_Location_DistrictId` (`DistrictId`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Location`
--

LOCK TABLES `Location` WRITE;
/*!40000 ALTER TABLE `Location` DISABLE KEYS */;
INSERT INTO `Location` VALUES
(1,'Trivandrum','TVM','Th','1212',1),
(2,'Kollam','KLM','Kollam','1206',1),
(3,'Mavelikkara','MLK','Mavelikkara','1201',1),
(4,'Kottayam','KYM','Kottayam','1207',1),
(5,'Malayattor','MLA','malayattoor','1202',1),
(21,'Chirayinkeezhu','CHR','C','1212',1),
(25,'Kakkanad','KKND','Infopark','1202',1);
/*!40000 ALTER TABLE `Location` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Party`
--

DROP TABLE IF EXISTS `Party`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `Party` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `AddressLine1` varchar(250) NOT NULL,
  `AddressLine2` varchar(250) DEFAULT NULL,
  `Mobile` varchar(50) NOT NULL,
  `Pincode` varchar(50) NOT NULL,
  `AccountId` int(11) NOT NULL,
  `Code` varchar(50) NOT NULL DEFAULT '',
  `ContactPerson` varchar(50) DEFAULT NULL,
  `GstNo` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 0,
  `OfficePhone` varchar(80) NOT NULL DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Party`
--

LOCK TABLES `Party` WRITE;
/*!40000 ALTER TABLE `Party` DISABLE KEYS */;
INSERT INTO `Party` VALUES
(1,'Impex','Add1','Add2','9034567823','690304',1,'','','',1,''),
(2,'Pittappally','Add2','Add2','9083838338','678345',1,'',NULL,NULL,0,''),
(4,'Nadilath G Mart','A','A','703393939','393932',0,'NGM','R','4939292',0,'388838383');
/*!40000 ALTER TABLE `Party` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `State`
--

DROP TABLE IF EXISTS `State`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `State` (
  `ID` varchar(255) NOT NULL,
  `Name` longtext NOT NULL,
  `Code` longtext NOT NULL,
  `IsActive` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `State`
--

LOCK TABLES `State` WRITE;
/*!40000 ALTER TABLE `State` DISABLE KEYS */;
INSERT INTO `State` VALUES
('1','Andhra Pradesh','',1),
('10','Jharkhand','',1),
('11','Karnataka','',1),
('12','Kerala','',1),
('13','Madhya Pradesh','',1),
('14','Maharashtra','',1),
('15','Manipur','',1),
('16','Meghalaya','',1),
('17','Mizoram','',1),
('18','Nagaland','',1),
('19','Odisha','',1),
('2','Arunachal Pradesh','',1),
('20','Punjab','',1),
('21','Rajasthan','',1),
('22','Sikkim','',1),
('23','Tamil Nadu','',1),
('24','Telangana','',1),
('25','Tripura','',1),
('26','Uttar Pradesh','',1),
('27','Uttarakhand','',1),
('28','West Bengal','',1),
('3','Assam','',1),
('4','Bihar','',1),
('5','Chhattisgarh','',1),
('6','Goa','',1),
('7','Gujarat','',1),
('8','Haryana','',1),
('9','Himachal Pradesh','',1);
/*!40000 ALTER TABLE `State` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TransportEntry`
--

DROP TABLE IF EXISTS `TransportEntry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `TransportEntry` (
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Date` datetime(6) NOT NULL,
  `VehicleId` smallint(6) NOT NULL,
  `VehicleTypeId` smallint(6) NOT NULL,
  `DriverId` smallint(6) NOT NULL,
  `Party1` smallint(6) NOT NULL,
  `From` int(11) NOT NULL,
  `To` int(11) NOT NULL,
  `StartKM` decimal(65,30) NOT NULL,
  `CloseKM` decimal(65,30) NOT NULL,
  `Total` decimal(65,30) NOT NULL,
  `Loading` decimal(65,30) NOT NULL,
  `Unloading` decimal(65,30) NOT NULL,
  `LoadingCommision` decimal(65,30) NOT NULL,
  `UnloadingCommision` decimal(65,30) NOT NULL,
  `ReturnDestinationId` int(11) NOT NULL,
  `HaltDays` smallint(6) NOT NULL,
  `Rent` decimal(65,30) NOT NULL,
  `Narration` longtext DEFAULT NULL,
  `Other` longtext DEFAULT NULL,
  `AccountId` int(11) NOT NULL,
  `Source` smallint(6) DEFAULT NULL,
  `DestinationGroupId` bigint(20) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID`),
  KEY `IX_TransportEntry_DriverId` (`DriverId`),
  KEY `IX_TransportEntry_From` (`From`),
  KEY `IX_TransportEntry_Party1` (`Party1`),
  KEY `IX_TransportEntry_ReturnDestinationId` (`ReturnDestinationId`),
  KEY `IX_TransportEntry_To` (`To`),
  KEY `IX_TransportEntry_VehicleId` (`VehicleId`),
  KEY `IX_TransportEntry_VehicleTypeId` (`VehicleTypeId`),
  CONSTRAINT `FK_TransportEntry_Driver_DriverId` FOREIGN KEY (`DriverId`) REFERENCES `Driver` (`ID`),
  CONSTRAINT `FK_TransportEntry_Location_From` FOREIGN KEY (`From`) REFERENCES `Location` (`ID`),
  CONSTRAINT `FK_TransportEntry_Location_ReturnDestinationId` FOREIGN KEY (`ReturnDestinationId`) REFERENCES `Location` (`ID`),
  CONSTRAINT `FK_TransportEntry_Location_To` FOREIGN KEY (`To`) REFERENCES `Location` (`ID`),
  CONSTRAINT `FK_TransportEntry_Party_Party1` FOREIGN KEY (`Party1`) REFERENCES `Party` (`ID`),
  CONSTRAINT `FK_TransportEntry_VehicleType_VehicleTypeId` FOREIGN KEY (`VehicleTypeId`) REFERENCES `VehicleType` (`ID`) ON DELETE CASCADE,
  CONSTRAINT `FK_TransportEntry_Vehicle_VehicleId` FOREIGN KEY (`VehicleId`) REFERENCES `Vehicle` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TransportEntry`
--

LOCK TABLES `TransportEntry` WRITE;
/*!40000 ALTER TABLE `TransportEntry` DISABLE KEYS */;
INSERT INTO `TransportEntry` VALUES
(1,'2026-02-20 00:00:00.000000',1,1,1,1,1,2,1000.000000000000000000000000000000,2000.000000000000000000000000000000,100010.000000000000000000000000000000,100.000000000000000000000000000000,100.000000000000000000000000000000,500.000000000000000000000000000000,500.000000000000000000000000000000,3,2,300.000000000000000000000000000000,NULL,NULL,1,1,1),
(2,'1993-11-19 00:00:00.000000',1,1,2,2,1,2,1000.000000000000000000000000000000,2000.000000000000000000000000000000,100043.000000000000000000000000000000,100.000000000000000000000000000000,100.000000000000000000000000000000,50.000000000000000000000000000000,50.000000000000000000000000000000,3,2,300.000000000000000000000000000000,NULL,NULL,1,NULL,1),
(3,'1993-11-19 00:00:00.000000',1,1,2,2,1,2,1000.000000000000000000000000000000,2000.000000000000000000000000000000,1000.000000000000000000000000000000,100.000000000000000000000000000000,100.000000000000000000000000000000,50.000000000000000000000000000000,50.000000000000000000000000000000,3,2,300.000000000000000000000000000000,NULL,NULL,1,NULL,1),
(5,'2026-01-18 12:15:25.459000',1,1,1,1,2,3,45210.000000000000000000000000000000,45485.000000000000000000000000000000,275.000000000000000000000000000000,1500.000000000000000000000000000000,1200.000000000000000000000000000000,300.000000000000000000000000000000,250.000000000000000000000000000000,3,1,18000.000000000000000000000000000000,'Goods transport from Kochi to Bengaluru','Night halt charges included',3,NULL,0),
(6,'1993-11-19 00:00:00.000000',1,1,1,2,1,5,1000.000000000000000000000000000000,2000.000000000000000000000000000000,1000347.000000000000000000000000000000,100.000000000000000000000000000000,100.000000000000000000000000000000,50.000000000000000000000000000000,50.000000000000000000000000000000,3,1,18000.000000000000000000000000000000,'Goods transport from Kochi to Bengaluru','Night halt charges included',3,NULL,0),
(7,'2026-01-18 12:15:25.459000',1,1,1,1,2,3,45210.000000000000000000000000000000,45485.000000000000000000000000000000,275.000000000000000000000000000000,1500.000000000000000000000000000000,1200.000000000000000000000000000000,300.000000000000000000000000000000,250.000000000000000000000000000000,3,1,18000.000000000000000000000000000000,'Goods transport from Kochi to Bengaluru','Night halt charges included',3,NULL,0),
(11,'1993-11-19 00:00:00.000000',1,1,1,1,5,2,1000.000000000000000000000000000000,2000.000000000000000000000000000000,1000.000000000000000000000000000000,100.000000000000000000000000000000,100.000000000000000000000000000000,50.000000000000000000000000000000,50.000000000000000000000000000000,1,0,0.000000000000000000000000000000,NULL,NULL,0,NULL,11),
(12,'2026-01-23 00:00:00.000000',1,1,1,2,3,5,1.000000000000000000000000000000,1.000000000000000000000000000000,1.000000000000000000000000000000,1.000000000000000000000000000000,1.000000000000000000000000000000,1.000000000000000000000000000000,1.000000000000000000000000000000,1,0,0.000000000000000000000000000000,NULL,NULL,0,NULL,12);
/*!40000 ALTER TABLE `TransportEntry` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Vehicle`
--

DROP TABLE IF EXISTS `Vehicle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `Vehicle` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Model` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Registration` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `TypeId` smallint(6) NOT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID`),
  KEY `IX_Vehicle_TypeId` (`TypeId`),
  CONSTRAINT `FK_Vehicle_VehicleType_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `VehicleType` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Vehicle`
--

LOCK TABLES `Vehicle` WRITE;
/*!40000 ALTER TABLE `Vehicle` DISABLE KEYS */;
INSERT INTO `Vehicle` VALUES
(1,'ACE','KL-31-3456',1,1);
/*!40000 ALTER TABLE `Vehicle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `VehicleType`
--

DROP TABLE IF EXISTS `VehicleType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `VehicleType` (
  `ID` smallint(6) NOT NULL AUTO_INCREMENT,
  `Desc` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `AccountId` int(11) NOT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `VehicleType`
--

LOCK TABLES `VehicleType` WRITE;
/*!40000 ALTER TABLE `VehicleType` DISABLE KEYS */;
INSERT INTO `VehicleType` VALUES
(1,'12 Feet',1,0),
(3,'45 Feet',0,0);
/*!40000 ALTER TABLE `VehicleType` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES
('20251219225329_InitialMariaDb','6.0.0'),
('20251225142140_destinationgrp','8.0.22'),
('20251229150250_destinationgrps','8.0.22'),
('20260131111323_missingfields','8.0.22'),
('20260203092549_statedistrict2','8.0.22'),
('20260205045951_partymodelmodified','8.0.22'),
('20260209050513_adhaarno-spell-issue-resolved','8.0.22'),
('20260211103143_is active addded to veh','8.0.22');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-02-17 12:15:25
