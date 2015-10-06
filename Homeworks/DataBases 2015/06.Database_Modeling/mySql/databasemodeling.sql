CREATE DATABASE  IF NOT EXISTS `databasemodeling` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `databasemodeling`;
-- MySQL dump 10.13  Distrib 5.6.24, for Win32 (x86)
--
-- Host: localhost    Database: databasemodeling
-- ------------------------------------------------------
-- Server version	5.6.27-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `courses`
--

DROP TABLE IF EXISTS `courses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `courses` (
  `idCourse` int(11) NOT NULL AUTO_INCREMENT,
  `CourseName` varchar(35) NOT NULL,
  `idProfessor` int(11) NOT NULL,
  PRIMARY KEY (`idCourse`),
  UNIQUE KEY `idCourse_UNIQUE` (`idCourse`),
  KEY `idProffesor_idx` (`idProfessor`),
  CONSTRAINT `idProffesor` FOREIGN KEY (`idProfessor`) REFERENCES `professors` (`idProfessor`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES (14,'Java',1),(15,'JavaScript',2),(16,'Java UI & DOM ',3),(17,'Java Applications',4),(18,'HTML & CSS',5),(19,'C++',6),(20,'C#',7),(21,'C# OOP',8),(22,'Python',2),(23,'Network Routing',9),(24,'Administration networks',9),(25,'Global economy',1),(26,'Football',2),(27,'Drinking',3);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `departments`
--

DROP TABLE IF EXISTS `departments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `departments` (
  `idDepartment` int(11) NOT NULL AUTO_INCREMENT,
  `DepartmentName` varchar(45) NOT NULL,
  `idFaculty` int(11) NOT NULL,
  PRIMARY KEY (`idDepartment`),
  UNIQUE KEY `idDepartment_UNIQUE` (`idDepartment`),
  KEY `idFaculty_idx` (`idFaculty`),
  CONSTRAINT `idFaculty` FOREIGN KEY (`idFaculty`) REFERENCES `faculties` (`idFaculty`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `departments`
--

LOCK TABLES `departments` WRITE;
/*!40000 ALTER TABLE `departments` DISABLE KEYS */;
INSERT INTO `departments` VALUES (34,'Electronics',1),(35,'Networks',1),(36,'Statistics',1),(37,'Software',1),(38,'National security',5),(39,'Gurad security',5),(40,'Budgets',4),(41,'Software',1),(42,'Book knowledge',3),(43,'Library management',3),(44,'Human rights',6);
/*!40000 ALTER TABLE `departments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faculties`
--

DROP TABLE IF EXISTS `faculties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faculties` (
  `idFaculty` int(11) NOT NULL AUTO_INCREMENT,
  `FacultyName` varchar(45) NOT NULL,
  `idUniversities` int(11) NOT NULL,
  PRIMARY KEY (`idFaculty`),
  UNIQUE KEY `idFaculties_UNIQUE` (`idFaculty`),
  KEY `idUniversities_idx` (`idUniversities`),
  CONSTRAINT `idUniversities` FOREIGN KEY (`idUniversities`) REFERENCES `universities` (`idUniversities`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faculties`
--

LOCK TABLES `faculties` WRITE;
/*!40000 ALTER TABLE `faculties` DISABLE KEYS */;
INSERT INTO `faculties` VALUES (1,'Information',1),(2,'Library Knowledge',2),(3,'Economy',5),(4,'Air Force',3),(5,'Law',4),(6,'Software Engineering',3);
/*!40000 ALTER TABLE `faculties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professors`
--

DROP TABLE IF EXISTS `professors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professors` (
  `idProfessor` int(11) NOT NULL AUTO_INCREMENT,
  `Professor FirstName` varchar(45) NOT NULL,
  `Professor LastName` varchar(45) NOT NULL,
  `idDepartment` int(11) NOT NULL,
  PRIMARY KEY (`idProfessor`),
  UNIQUE KEY `idProfessor_UNIQUE` (`idProfessor`),
  KEY `idDepartmnet_idx` (`idDepartment`),
  CONSTRAINT `idDepartmnet` FOREIGN KEY (`idDepartment`) REFERENCES `departments` (`idDepartment`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professors`
--

LOCK TABLES `professors` WRITE;
/*!40000 ALTER TABLE `professors` DISABLE KEYS */;
INSERT INTO `professors` VALUES (1,'Hristo','Ivanova',34),(2,'Omruznami','DaPopulvamDanni',39),(3,'Aneta','Hristova',40),(4,'Ivo','Petrov',40),(5,'Maria','Ivanova',38),(6,'Penka','Dobromirova',41),(7,'Atanas','Popkaraivanov',36),(8,'Georgi','Evrimov',34),(9,'Aneta','Georgieva',44);
/*!40000 ALTER TABLE `professors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professorswithtitles`
--

DROP TABLE IF EXISTS `professorswithtitles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professorswithtitles` (
  `idProfessor` int(11) NOT NULL,
  `idTitle` int(11) NOT NULL,
  PRIMARY KEY (`idProfessor`,`idTitle`),
  KEY `idTitle_idx` (`idTitle`),
  CONSTRAINT `idProfessors` FOREIGN KEY (`idProfessor`) REFERENCES `professors` (`idProfessor`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idTitle` FOREIGN KEY (`idTitle`) REFERENCES `titles` (`idTitle`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professorswithtitles`
--

LOCK TABLES `professorswithtitles` WRITE;
/*!40000 ALTER TABLE `professorswithtitles` DISABLE KEYS */;
INSERT INTO `professorswithtitles` VALUES (2,1),(3,1),(4,1),(5,1),(9,1),(1,2),(5,2),(1,3),(3,3),(6,3),(7,3),(8,3),(9,3),(8,4),(2,5),(3,5),(6,5),(7,5);
/*!40000 ALTER TABLE `professorswithtitles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `idStudent` int(11) NOT NULL AUTO_INCREMENT,
  `Student FirstName` varchar(25) NOT NULL,
  `Student LastName` varchar(25) NOT NULL,
  `idCourse` int(11) NOT NULL,
  PRIMARY KEY (`idStudent`),
  UNIQUE KEY `idStudent_UNIQUE` (`idStudent`),
  KEY `idCourse_idx` (`idCourse`),
  CONSTRAINT `idCourse` FOREIGN KEY (`idCourse`) REFERENCES `courses` (`idCourse`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES (1,'Pesho','Petrov',14),(2,'Ivan','Ivanov',15),(3,'Peso','Pomiarov',23),(4,'Karamfil','Iotov',20),(5,'Megan','Fox',15),(6,'Miracle','Oracle',23),(7,'Orelaian','Joikim',20),(8,'Panaiot','Hristov',20),(9,'Biser','Brannekov',25),(10,'Poparata','Kamarata',27),(11,'Iordan','Lechkov',20),(12,'Hristo','Stoichkov',26),(13,'John','Mechedziev',21),(14,'Petar','Hranev',22),(15,'Kaloqn','Kostov',23),(16,'Deimra','Jekova',24),(17,'Clen','Vox',25),(18,'Mc','Donalds',26),(19,'Yordan','Sokolov',19);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `titles`
--

DROP TABLE IF EXISTS `titles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `titles` (
  `idTitle` int(11) NOT NULL AUTO_INCREMENT,
  `TitleName` varchar(30) NOT NULL,
  PRIMARY KEY (`idTitle`),
  UNIQUE KEY `idTitle_UNIQUE` (`idTitle`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `titles`
--

LOCK TABLES `titles` WRITE;
/*!40000 ALTER TABLE `titles` DISABLE KEYS */;
INSERT INTO `titles` VALUES (1,'Professor'),(2,'Doctor'),(3,'Chief Assistant'),(4,'Assoc. Proffesor'),(5,'PhD.');
/*!40000 ALTER TABLE `titles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `universities`
--

DROP TABLE IF EXISTS `universities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `universities` (
  `idUniversities` int(11) NOT NULL AUTO_INCREMENT,
  `UniversityName` varchar(75) NOT NULL,
  PRIMARY KEY (`idUniversities`),
  UNIQUE KEY `idUniversities_UNIQUE` (`idUniversities`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `universities`
--

LOCK TABLES `universities` WRITE;
/*!40000 ALTER TABLE `universities` DISABLE KEYS */;
INSERT INTO `universities` VALUES (1,'Sofia University'),(2,'University of Library Studies and Information Technologies'),(3,'Technical University of Sofia'),(4,'New Bulgarian University'),(5,'University of national and world economy');
/*!40000 ALTER TABLE `universities` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-10-06 15:31:29
