-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: judo
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `role` int DEFAULT NULL COMMENT '0 - участник\\\\n1 - тренер \\\\n2 - судья',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=128 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login` VALUES (1,'admin','admin123',2),(2,'trener','trener',1),(3,'edison@gmail.com','edison1102',0),(4,'pparisian@gmail.com','cveOYGr8R7',0),(5,'emilyjones@gmail.com','VWdg62xAwE',0),(6,'alexanderbrown@gmail.com','nn7KbnDd16',0),(7,'sarahmiller@gmail.com','4hHuRHhpi3',0),(8,'jenniferdavis@gmail.com','7m4skXv1YM',0),(9,'davidwilson@gmail.com','hvkrNwcixX',0),(10,'lisawhite@gmail.com','F9q318r3xX',0),(11,'michaeltaylor@gmail.com','CJoe0wuGNr',0),(12,'laurajohnson@gmail.com','EO17gIFyJN',0),(13,'jasonthompson@gmail.com','hoknQuwnge',0),(14,'amandajackson@gmail.com','hHAoAcwh3R',0),(15,'brianroberts@gmail.com','Wg1sxlghV9',0),(16,'kellymartinez@gmail.com','ihYKV94fst',0),(17,'patrickanderson@gmail.com','uMXp7pnr4k',0),(18,'jessicaharris@gmail.com','rmsATITjmv',0),(19,'ryanscott@gmail.com','MMUJ9w4CKZ',0),(20,'melissawalker@gmail.com','UknCvVlIiS',0),(21,'christopherlewis@gmail.com','PNsp42ptKo',0),(22,'kimberlyyoung@gmail.com','Iu0ZWreKgE',0),(23,'matthewturner@gmail.com','tUUBg9fYiZ',0),(24,'ashleyrodriguez@gmail.com','b73mGBRofv',0),(25,'ericadams@gmail.com','XGRO1sBaGj',0),(26,'richardstewart@gmail.com','KeXky8uiJ1',0),(27,'laurenwood@gmail.com','5OB3XPHTGn',0),(28,'brandonhill@gmail.com','srmoVF5czs',0),(29,'danielcarter@gmail.com','BBeMt008It',0),(30,'stephanieross@gmail.com','xvEFZrkaBm',0),(31,'kevinrogers@gmail.com','H5blDhAjbX',0),(32,'mariathompson@gmail.com','cmCCP4UxKC',0),(33,'timothycooper@gmail.com','DZJJ2qqb4B',0),(34,'christinaward@gmail.com','0I3aopHr2d',0),(35,'jeremymurphy@gmail.com','RtgOREL4GA',0),(36,'john.doe@gmail.com','9K3dJf7g2H',2),(37,'emily.smith@gmail.com','5R9kF8a3M',2),(38,'david.johnson@gmail.com','4X6bN2c9L',2),(39,'sarah.wilson@gmail.com','7Y6sN4b2T9',1),(40,'michael.brown@gmail.com','2H9fS5k8R3',1),(41,'jennifer.nguyen@gmail.com','6L8jK3f9D7',1),(42,'john.doe1','6n8cQ1s9tR',0),(43,'alex.smith2','3b7G9m0a2i',0),(44,'mike.johnson3','5r2D1s7gP6',0),(45,'jason.wilson4','9k3U7h6s1M',0),(46,'david.brown5','4t6Y8b1n9L',0),(47,'mark.taylor6','7e1A3w5q9S',0),(48,'andrew.clark7','2j4K6l8z0X',0),(49,'steve.miller8','8u0J5v3c2B',0),(50,'samuel.jones9','1o9P2i8u4N',0),(51,'alex.baker10','0y2T4r6e8W',0),(52,'robert.lee11','4f6B8v2c1Z',0),(53,'patrick.clark12','9i1O7u3Y5T',0),(54,'william.king13','3s7W9q0R2E',0),(55,'daniel.green14','5g2D1f7S9H',0),(56,'richard.ward15','7j3K6t1L9N',0),(57,'matthew.hill16','2e4A6w8S0D',0),(58,'jacob.scott17','8u0H5j3N2T',0),(59,'jordan.price18','1o9P2r8I4C',0),(60,'justin.ross19','0y2T4i6P8O',0),(61,'benjamin.cook20','4f6B8e2N1J',0),(62,'andrew.howard21','9i1O5r3W7Q',0),(63,'ethan.young22','3s7W9t1E5G',0),(64,'jackson.morris23','5g2D1e7F9B',0),(65,'dylan.bell24','7j3K6l1M9X',0),(66,'gabriel.ward25','2e4A6a8R0T',0),(67,'ethan.wood26','8u0H5o3D2F',0),(68,'liam.stewart27','1o9P2w8R4Y',0),(69,'oliver.ross28','0y2T4o6S8V',0),(70,'lucas.carter29','4f6B8n2J1M',0),(71,'jayden.bell30','9i1O7b3H5K',0),(72,'mateo.bailey31','3s7W9m1V5L',0),(73,'jack.miller32','5g2D1l7N9C',0),(74,'logan.moore33','7j3K6y1P9O',0),(75,'david.campbell34','2e4A6m8R0G',0),(76,'joseph.rogers35','8u0H5k3I2B',0),(77,'anthony.hall36','1o9P2h8L4T',0),(78,'max.martin37','0y2T4o6R8F',0),(79,'isaac.walker38','4f6B8a2K1N',0),(80,'samuel.parker39','9i1O7n3M5J',0),(81,'benjamin.wright40','3s7W9i1B5H',0),(82,'christopher.king41','5g2D1c7K9M',0),(83,'wyatt.gonzalez42','7j3K6l1P9O',0),(84,'andrew.brown43','2e4A6w8S0D',0),(85,'gabriel.lewis44','8u0H5z3X2F',0),(86,'joseph.harris45','1o9P2r8I4C',0),(87,'lucas.clark46','0y2T4i6O8V',0),(88,'oliver.morgan47','4f6B8e2N1J',0),(89,'logan.allen48','9i1O5r3W7Q',0),(90,'daniel.howard49','3s7W9t1E5G',0),(91,'matthew.cook50','5g2D1f7S9H',0),(92,'gabriel.hill51','7j3K6u1N9L',0),(93,'dylan.moore52','2e4A6w8D0S',0),(94,'liam.rodriguez53','8u0H5j3N2T',0),(95,'jackson.stewart54','1o9P2r8I4C',0),(96,'noah.parker55','0y2T4i6P8O',0),(97,'samuel.gonzalez56','4f6B8e2N1J',0),(98,'david.lewis57','9i1O5r3W7Q',0),(99,'joseph.walker58','3s7W9t1E5G',0),(100,'gabriel.robinson59','5g2D1f7S9H',0),(101,'benjamin.lopez60','7j3K6u1N9L',0),(102,'lucas.howard61','2e4A6w8D0S',0),(103,'oliver.rodriguez62','8u0H5j3N2T',0),(104,'logan.stewart63','1o9P2g8W4R',0),(105,'wyatt.carter64','0y2T4k6S8V',0),(106,'andrew.baker65','4f6B8n2J1M',0),(107,'gabriel.cooper66','9i1O7a3H5K',0),(108,'joseph.rogers67','3s7W9m1V5L',0),(109,'lucas.ross68','5g2D1l7N9C',0),(110,'oliver.bailey69','7j3K6y1P9O',0),(111,'logan.harris70','2e4A6m8R0G',0),(112,'jack.lewis71','8u0H5o3D2F',0),(113,'jayden.young72','1o9P2w8R4Y',0),(114,'benjamin.stewart73','0y2T4e6W8I',0),(115,'daniel.thomas74','4f6B8k2A1S',0),(116,'joseph.jones75','9i1O7u3R5Q',0),(117,'gabriel.james76','3s7W9m1Y5H',0),(118,'dylan.davis77','5g2D1l7U9O',0),(119,'oliver.miller78','7j3K6y1P9O',0),(120,'logan.moore79','2e4A6m8R0G',0),(121,'william.morgan80','8u0H5o3D2F',0),(122,'james.thompson81','1o9P2w8R4Y',0),(123,'benjamin.davis82','0y2T4e6W8I',0),(124,'samuel.rodriguez83','4f6B8k2A1S',0),(125,'gabriel.carter84','9i1O7u3R5Q',0),(126,'trener@gamil.com','trener123456',1),(127,'Test@12345678','Test@12345678',0);
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-28 12:25:02
