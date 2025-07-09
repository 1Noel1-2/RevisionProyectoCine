-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: localhost    Database: SarmiMovieDB
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asientos`
--

DROP TABLE IF EXISTS `asientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asientos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `sala_id` int DEFAULT NULL,
  `fila` varchar(5) DEFAULT NULL,
  `numero` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `sala_id` (`sala_id`),
  CONSTRAINT `asientos_ibfk_1` FOREIGN KEY (`sala_id`) REFERENCES `salas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asientos`
--

LOCK TABLES `asientos` WRITE;
/*!40000 ALTER TABLE `asientos` DISABLE KEYS */;
INSERT INTO `asientos` VALUES (1,1,'A',1),(2,1,'A',2),(3,1,'A',3),(4,1,'A',4),(5,1,'A',5),(6,1,'B',1),(7,1,'B',2),(8,1,'B',3),(9,1,'B',4),(10,1,'B',5),(11,1,'C',1),(12,1,'C',2),(13,1,'C',3),(14,1,'C',4),(15,1,'C',5),(16,1,'D',1),(17,1,'D',2),(18,1,'D',3),(19,1,'D',4),(20,1,'D',5),(21,2,'A',1),(22,2,'A',2),(23,2,'A',3),(24,2,'A',4),(25,2,'A',5),(26,2,'B',1),(27,2,'B',2),(28,2,'B',3),(29,2,'B',4),(30,2,'B',5),(31,2,'C',1),(32,2,'C',2),(33,2,'C',3),(34,2,'C',4),(35,2,'C',5),(36,2,'D',1),(37,2,'D',2),(38,2,'D',3),(39,2,'D',4),(40,2,'D',5),(41,3,'A',1),(42,3,'A',2),(43,3,'A',3),(44,3,'A',4),(45,3,'A',5),(46,3,'B',1),(47,3,'B',2),(48,3,'B',3),(49,3,'B',4),(50,3,'B',5),(51,3,'C',1),(52,3,'C',2),(53,3,'C',3),(54,3,'C',4),(55,3,'C',5),(56,3,'D',1),(57,3,'D',2),(58,3,'D',3),(59,3,'D',4),(60,3,'D',5),(61,4,'A',1),(62,4,'A',2),(63,4,'A',3),(64,4,'A',4),(65,4,'A',5),(66,4,'B',1),(67,4,'B',2),(68,4,'B',3),(69,4,'B',4),(70,4,'B',5),(71,4,'C',1),(72,4,'C',2),(73,4,'C',3),(74,4,'C',4),(75,4,'C',5),(76,4,'D',1),(77,4,'D',2),(78,4,'D',3),(79,4,'D',4),(80,4,'D',5),(81,5,'A',1),(82,5,'A',2),(83,5,'A',3),(84,5,'A',4),(85,5,'A',5),(86,5,'B',1),(87,5,'B',2),(88,5,'B',3),(89,5,'B',4),(90,5,'B',5),(91,5,'C',1),(92,5,'C',2),(93,5,'C',3),(94,5,'C',4),(95,5,'C',5),(96,5,'D',1),(97,5,'D',2),(98,5,'D',3),(99,5,'D',4),(100,5,'D',5);
/*!40000 ALTER TABLE `asientos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `asientos_funcion`
--

DROP TABLE IF EXISTS `asientos_funcion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asientos_funcion` (
  `funcion_id` int NOT NULL,
  `disponible` tinyint(1) DEFAULT '1',
  `asiento_id` int NOT NULL,
  PRIMARY KEY (`funcion_id`,`asiento_id`),
  KEY `af_fk_asiento` (`asiento_id`),
  CONSTRAINT `af_fk_asiento` FOREIGN KEY (`asiento_id`) REFERENCES `asientos` (`id`),
  CONSTRAINT `af_fk_funcion` FOREIGN KEY (`funcion_id`) REFERENCES `funciones` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asientos_funcion`
--

LOCK TABLES `asientos_funcion` WRITE;
/*!40000 ALTER TABLE `asientos_funcion` DISABLE KEYS */;
INSERT INTO `asientos_funcion` VALUES (1,1,1),(1,1,2),(1,1,3),(1,1,4),(1,1,5),(1,1,6),(1,1,7),(1,1,8),(1,1,9),(1,1,10),(2,1,21),(2,1,22),(2,1,23),(2,1,24),(2,1,25),(2,1,26),(2,1,27),(2,1,28),(2,1,29),(2,1,30),(3,1,41),(3,1,42),(3,1,43),(3,1,44),(3,1,45),(3,1,46),(3,1,47),(3,1,48),(3,1,49),(3,1,50),(4,1,61),(4,1,62),(4,1,63),(4,1,64),(4,1,65),(4,1,66),(4,1,67),(4,1,68),(4,1,69),(4,1,70),(5,1,81),(5,1,82),(5,1,83),(5,1,84),(5,1,85),(5,1,86),(5,1,87),(5,1,88),(5,1,89),(5,1,90);
/*!40000 ALTER TABLE `asientos_funcion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entradas`
--

DROP TABLE IF EXISTS `entradas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entradas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `reserva_id` int DEFAULT NULL,
  `tipo_boleto_id` int DEFAULT NULL,
  `asiento` varchar(10) DEFAULT NULL,
  `precio_unitario` decimal(6,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `reserva_id` (`reserva_id`),
  KEY `tipo_boleto_id` (`tipo_boleto_id`),
  CONSTRAINT `entradas_ibfk_1` FOREIGN KEY (`reserva_id`) REFERENCES `reservas` (`id`),
  CONSTRAINT `entradas_ibfk_2` FOREIGN KEY (`tipo_boleto_id`) REFERENCES `tipos_boleto` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entradas`
--

LOCK TABLES `entradas` WRITE;
/*!40000 ALTER TABLE `entradas` DISABLE KEYS */;
/*!40000 ALTER TABLE `entradas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funciones`
--

DROP TABLE IF EXISTS `funciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `funciones` (
  `id` int NOT NULL AUTO_INCREMENT,
  `pelicula_id` int DEFAULT NULL,
  `sala_id` int DEFAULT NULL,
  `sucursal_id` int DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `hora_inicio` time DEFAULT NULL,
  `hora_fin` time DEFAULT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `idioma` varchar(50) DEFAULT NULL,
  `formato` varchar(20) DEFAULT NULL,
  `estado` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `pelicula_id` (`pelicula_id`),
  KEY `sala_id` (`sala_id`),
  KEY `sucursal_id` (`sucursal_id`),
  CONSTRAINT `funciones_ibfk_1` FOREIGN KEY (`pelicula_id`) REFERENCES `peliculas` (`id`),
  CONSTRAINT `funciones_ibfk_2` FOREIGN KEY (`sala_id`) REFERENCES `salas` (`id`),
  CONSTRAINT `funciones_ibfk_3` FOREIGN KEY (`sucursal_id`) REFERENCES `sucursales` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funciones`
--

LOCK TABLES `funciones` WRITE;
/*!40000 ALTER TABLE `funciones` DISABLE KEYS */;
INSERT INTO `funciones` VALUES (1,1,1,NULL,'2025-06-16','18:00:00','20:00:00',20.00,'Español','2D','Activa'),(2,2,2,2,'2025-06-16','18:00:00','20:00:00',20.00,'Español','2D','Activa'),(3,3,3,3,'2025-06-16','18:00:00','20:00:00',20.00,'Español','2D','Activa'),(4,4,4,4,'2025-06-16','18:00:00','20:00:00',20.00,'Español','2D','Activa'),(5,5,5,5,'2025-06-16','18:00:00','20:00:00',20.00,'Español','2D','Activa'),(6,13,1,1,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(7,13,2,2,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(8,13,3,3,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(9,13,4,4,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(10,13,5,5,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(11,6,6,4,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(15,10,10,2,'2025-06-19','18:00:00','20:00:00',NULL,'Español','2D','Activa'),(16,11,1,1,'2025-06-19','20:30:00','22:30:00',NULL,'Español','2D','Activa'),(20,15,10,NULL,'2025-07-18','14:32:00','17:00:00',NULL,'Español','2D','Activa');
/*!40000 ALTER TABLE `funciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mensajes_contacto`
--

DROP TABLE IF EXISTS `mensajes_contacto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mensajes_contacto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `correo` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `mensaje` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `fecha` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mensajes_contacto`
--

LOCK TABLES `mensajes_contacto` WRITE;
/*!40000 ALTER TABLE `mensajes_contacto` DISABLE KEYS */;
/*!40000 ALTER TABLE `mensajes_contacto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `metodos_pago`
--

DROP TABLE IF EXISTS `metodos_pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `metodos_pago` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `metodos_pago`
--

LOCK TABLES `metodos_pago` WRITE;
/*!40000 ALTER TABLE `metodos_pago` DISABLE KEYS */;
INSERT INTO `metodos_pago` VALUES (1,'Tarjeta'),(2,'Efectivo'),(3,'Yape'),(4,'Plin'),(5,'Transferencia');
/*!40000 ALTER TABLE `metodos_pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagos`
--

DROP TABLE IF EXISTS `pagos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pagos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `reserva_id` int DEFAULT NULL,
  `metodo_pago_id` int DEFAULT NULL,
  `detalle` varchar(150) DEFAULT NULL,
  `fecha` datetime DEFAULT CURRENT_TIMESTAMP,
  `monto` decimal(10,2) DEFAULT NULL,
  `referencia` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `reserva_id` (`reserva_id`),
  KEY `metodo_pago_id` (`metodo_pago_id`),
  CONSTRAINT `pagos_ibfk_1` FOREIGN KEY (`reserva_id`) REFERENCES `reservas` (`id`),
  CONSTRAINT `pagos_ibfk_2` FOREIGN KEY (`metodo_pago_id`) REFERENCES `metodos_pago` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagos`
--

LOCK TABLES `pagos` WRITE;
/*!40000 ALTER TABLE `pagos` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `peliculas`
--

DROP TABLE IF EXISTS `peliculas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `peliculas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `titulo` varchar(200) DEFAULT NULL,
  `descripcion` text,
  `genero` varchar(100) DEFAULT NULL,
  `duracion` int DEFAULT NULL,
  `clasificacion` varchar(10) DEFAULT NULL,
  `idioma` varchar(50) DEFAULT NULL,
  `sinopsis` text,
  `imagen` varchar(255) DEFAULT NULL,
  `activa` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `peliculas`
--

LOCK TABLES `peliculas` WRITE;
/*!40000 ALTER TABLE `peliculas` DISABLE KEYS */;
INSERT INTO `peliculas` VALUES (1,'El Viaje Intergaláctico','Una aventura espacial...','Ciencia Ficción',120,'PG-13','Español','Un astronauta perdido...','/images/peliculas/bb75f45c5f3da500becc1679c11a05287225db9855dd59e31ffde7f97f44a4eb.jpg',1),(2,'Amor en los Tiempos Modernos','Una comedia romántica...','Romance',105,'PG','Español','El amor florece...','/images/peliculas/MV5BOGZjY2Y3ZTgtYjg5OC00YjhiLTk5YjctOTY4NTBhYjEyNzhhXkEyXkFqcGc@._V1_.jpg',1),(3,'La venganza de la casa del lago','Terror sobrenatural...','Terror',95,'R','Español','Una leyenda renace...','/images/peliculas/La_aultima_casa_a_la_izquierda-680305428-large.jpg',1),(4,'Código Mortal','Acción y suspenso...','Acción',110,'PG-13','Español','Un hacker peligroso...','/images/peliculas/images.jpg',1),(5,'El Chef','Competencia culinaria...','Comedia',100,'PG','Español','Recetas y risas...','/images/peliculas/el-chef-4.jpeg',1),(6,'El sorprendente hombre-araña','Peter Parker...','Acción',120,'B','Español','Spiderman salva el día','/images/peliculas/e2a3ed146ef0b01ebaad5426d12e15c02065c555808fe6cb76682bc13f42bc6c.jpg',1),(10,'Jurassic Park','Dinosaurios...','Aventura',127,'B','Español','Parque temático fallido','/images/peliculas/jurassic-park.jpg',1),(11,'The New Avengers','Nuevo equipo...','Acción',130,'B','Español','Nuevos héroes se levantan','/images/peliculas/new-avengers.jpg',1),(12,'El sorprendente hombre-araña 2','Peter Parker...','Acción',120,'B','Español','Spiderman salva el día','/images/peliculas/image.jpg',1),(13,'Los vengadores','Héroes unidos...','Acción',140,'B','Español','Luchan contra Loki','/images/peliculas/avengers.jpg',1),(14,'Volver al futuro','Viaje en el tiempo...','Ciencia Ficción',116,NULL,'Español','Marty McFly viaja al pasado','/images/peliculas/volver-al-futuro.jpg',1),(15,'Avatar','Pandora y la guerra...','Ciencia Ficción',162,'B','Español','Jake Sully se une a los Na?vi','/images/peliculas/avatar.jpg',1),(16,'Jurassic Park - El mundo perdido','Dinosaurios...','Aventura',127,'B','Español','Parque temático fallido','/images/peliculas/91LfCUQaRHL._UF894,1000_QL80_.jpg',1);
/*!40000 ALTER TABLE `peliculas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `precios_funcion`
--

DROP TABLE IF EXISTS `precios_funcion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `precios_funcion` (
  `funcion_id` int NOT NULL,
  `tipo_boleto_id` int NOT NULL,
  `precio` decimal(6,2) DEFAULT NULL,
  PRIMARY KEY (`funcion_id`,`tipo_boleto_id`),
  KEY `tipo_boleto_id` (`tipo_boleto_id`),
  CONSTRAINT `precios_funcion_ibfk_1` FOREIGN KEY (`funcion_id`) REFERENCES `funciones` (`id`),
  CONSTRAINT `precios_funcion_ibfk_2` FOREIGN KEY (`tipo_boleto_id`) REFERENCES `tipos_boleto` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `precios_funcion`
--

LOCK TABLES `precios_funcion` WRITE;
/*!40000 ALTER TABLE `precios_funcion` DISABLE KEYS */;
INSERT INTO `precios_funcion` VALUES (1,1,18.00),(1,2,16.00),(1,3,14.00),(2,1,18.00),(2,2,16.00),(2,3,14.00),(3,1,18.00),(3,2,16.00),(3,3,14.00),(4,1,18.00),(4,2,16.00),(4,3,14.00),(5,1,18.00),(5,2,16.00),(5,3,14.00),(6,1,80.00),(6,2,60.00),(6,3,50.00),(7,1,80.00),(7,2,60.00),(7,3,50.00),(8,1,80.00),(8,2,60.00),(8,3,50.00),(9,1,80.00),(9,2,60.00),(9,3,50.00),(10,1,80.00),(10,2,60.00),(10,3,50.00),(11,1,80.00),(11,2,60.00),(11,3,50.00),(15,1,80.00),(15,2,60.00),(15,3,50.00),(16,1,80.00),(16,2,60.00),(16,3,50.00);
/*!40000 ALTER TABLE `precios_funcion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refresh_tokens`
--

DROP TABLE IF EXISTS `refresh_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refresh_tokens` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_usuario` int DEFAULT NULL,
  `token` text,
  `fecha_creacion` datetime DEFAULT CURRENT_TIMESTAMP,
  `fecha_expiracion` datetime DEFAULT NULL,
  `valido` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `refresh_tokens_ibfk_1` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refresh_tokens`
--

LOCK TABLES `refresh_tokens` WRITE;
/*!40000 ALTER TABLE `refresh_tokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `refresh_tokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `reservas`
--

DROP TABLE IF EXISTS `reservas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `usuario_id` int DEFAULT NULL,
  `funcion_id` int DEFAULT NULL,
  `nombre_cliente` varchar(100) DEFAULT NULL,
  `apellido_cliente` varchar(100) DEFAULT NULL,
  `correo_cliente` varchar(150) DEFAULT NULL,
  `fecha_reserva` datetime DEFAULT CURRENT_TIMESTAMP,
  `total` decimal(6,2) DEFAULT NULL,
  `estado` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `usuario_id` (`usuario_id`),
  KEY `funcion_id` (`funcion_id`),
  CONSTRAINT `reservas_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`),
  CONSTRAINT `reservas_ibfk_2` FOREIGN KEY (`funcion_id`) REFERENCES `funciones` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservas`
--

LOCK TABLES `reservas` WRITE;
/*!40000 ALTER TABLE `reservas` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salas`
--

DROP TABLE IF EXISTS `salas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `salas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  `capacidad` int DEFAULT NULL,
  `id_sucursal` int DEFAULT NULL,
  `Estado` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_sucursal` (`id_sucursal`),
  CONSTRAINT `salas_ibfk_1` FOREIGN KEY (`id_sucursal`) REFERENCES `sucursales` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salas`
--

LOCK TABLES `salas` WRITE;
/*!40000 ALTER TABLE `salas` DISABLE KEYS */;
INSERT INTO `salas` VALUES (1,'Sala 1','IMAX',20,1,'Activa'),(2,'Sala 2','2D',20,2,'Activa'),(3,'Sala 3','3D',20,3,'Activa'),(4,'Sala 4','2D',20,4,'Activa'),(5,'Sala 5','3D',20,5,'Activa'),(6,'Sala 1','3D',20,4,'Inactiva'),(7,'Sala 1','IMAX',20,3,'Activa'),(8,'Sala 1','IMAX',20,5,'Activa'),(9,'Sala N','3D',10,5,'Activa'),(10,'Sala 5','3D',20,2,'Activa'),(11,'Sala 1','IMAX',20,1,'Inactiva'),(12,'Sala 1','IMAX',200,1,'Inactiva'),(13,'Sala 1','IMAX',2000,1,'Inactiva'),(14,'patito','3D',2000,5,'Inactiva'),(15,'Sala Samiento','3D',200,2,'Inactiva');
/*!40000 ALTER TABLE `salas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sucursales` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `ubicacion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursales`
--

LOCK TABLES `sucursales` WRITE;
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
INSERT INTO `sucursales` VALUES (1,'Sucursal Norte','Av. Las Flores 123, Lima'),(2,'Sucursal Sur','Av. Los Pinos 456, Arequipa'),(3,'Sucursal Este','Av. El Sol 789, Cusco'),(4,'Sucursal Oeste','Av. La Luna 321, Trujillo'),(5,'Sucursal Central','Av. Principal 987, Lima');
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos_boleto`
--

DROP TABLE IF EXISTS `tipos_boleto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipos_boleto` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos_boleto`
--

LOCK TABLES `tipos_boleto` WRITE;
/*!40000 ALTER TABLE `tipos_boleto` DISABLE KEYS */;
INSERT INTO `tipos_boleto` VALUES (1,'Adulto'),(2,'Niño'),(3,'Senior'),(4,'Adulto'),(5,'Niño'),(6,'Tercera Edad');
/*!40000 ALTER TABLE `tipos_boleto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) DEFAULT NULL,
  `apellido` varchar(100) DEFAULT NULL,
  `email` varchar(150) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `contrasena_hash` text,
  `rol` enum('Cliente','Admin') NOT NULL,
  `activo` tinyint(1) DEFAULT '1',
  `fecha_creacion` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `telefono` (`telefono`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Admin','Sarmiento','admin@sarmimovie.com','0000000000','Bhbbu8g3cG21oJTTBgP0RAmRURnvTBu/5PaTP8Kr68U=','Admin',1,'2025-06-16 21:08:59'),(4,'Admin','Cine','admin@cine.com',NULL,'JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=','Admin',1,'2025-06-18 04:11:45'),(5,'Christian Gael','Murrieta Luna','chris@cine.com',NULL,'QGEuEDLFLkP8ikQDz+K+OYbTeMuh8EhkLhJnWCJibV4=','Cliente',1,'2025-06-18 22:00:00'),(6,'Paco','P','paquito@correo.com',NULL,'WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=','Cliente',1,'2025-07-07 08:27:53');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-07-08 16:54:30



-- ========================================
-- Tablas añadidas para módulo de proveedores y compras
-- ========================================

-- Tabla de proveedores
CREATE TABLE IF NOT EXISTS proveedores (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nombre NVARCHAR(100),
    razon_social NVARCHAR(150),
    rfc NVARCHAR(13),
    domicilio NVARCHAR(200),
    telefono NVARCHAR(20)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Tabla de productos
CREATE TABLE IF NOT EXISTS productos (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nombre NVARCHAR(100),
    marca NVARCHAR(100),
    precio DECIMAL(10,2),
    existencia INT,
    categoria NVARCHAR(50)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Tabla de compras
CREATE TABLE IF NOT EXISTS compras (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    proveedor_id INT,
    producto_id INT,
    cantidad INT,
    fecha_compra DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (proveedor_id) REFERENCES proveedores(id),
    FOREIGN KEY (producto_id) REFERENCES productos(id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
