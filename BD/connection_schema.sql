DROP SCHEMA IF EXISTS `vg_db`;
CREATE DATABASE  IF NOT EXISTS `vg_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `vg_db`;

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
-- Table structure for table `user_data`
--

DROP TABLE IF EXISTS `Usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Usuario` (
  `identifier` int NOT NULL AUTO_INCREMENT,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (`identifier`),
  UNIQUE KEY `identifier_UNIQUE` (`identifier`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_Data`
--

LOCK TABLES `Usuario` WRITE;
/*!40000 ALTER TABLE `Usuario` DISABLE KEYS */;
INSERT INTO `Usuario` VALUES (1,'Sam88799','Sam123@88799', 'sam88799@outlook.com'),(2,'Cristgad','Venezuela123', 'CrisyVenezuela4eva@gmail.com'),(3,'X-mob14','z12w91y41', 'xmob@hotmail.com'),(4,'Fer_vie','3ot1im8ah', 'solecito@yahoo.com'),(5,'tumalxn','mautum123', 'mautum@mail.com');
/*!40000 ALTER TABLE `Usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PersonChef`
--

DROP TABLE IF EXISTS `PersonChef`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PersonChef` (
  `chef_id` int NOT NULL AUTO_INCREMENT,
  `color_ojos` int NOT NULL,
  `color_piel` int NOT NULL,
  `nacionalidad` int NOT NULL,
  PRIMARY KEY (`chef_id`),
  UNIQUE KEY `chef_id_UNIQUE` (`chef_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PersonChef`
--

LOCK TABLES `PersonChef` WRITE;
/*!40000 ALTER TABLE `PersonChef` DISABLE KEYS */;
INSERT INTO `PersonChef` VALUES (1,7,5,1),(2,2,8,2),(3,7,1,2),(4,4,7,3),(5,8,5,3);
/*!40000 ALTER TABLE `PersonChef` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table strcuture for table `Menu`
--
DROP TABLE IF EXISTS `Menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Menu` (
  `menu_id` int AUTO_INCREMENT,
  `volume` int NOT NULL,
  `music` bool NOT NULL,
  `user_id` int,
  PRIMARY KEY (`menu_id`),
  UNIQUE KEY `menu_id_UNIQUE`(`menu_id`),
  FOREIGN KEY (`user_id`) REFERENCES Usuario(`identifier`)
)ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Menu`
--

LOCK TABLES `Menu` WRITE;
/*!40000 ALTER TABLE `Menu` DISABLE KEYS */;
INSERT INTO `Menu` VALUES (1,10,TRUE,1),(2,5,FALSE,2),(3,12,FALSE,3),(4,10,TRUE,4),(5,8,TRUE,5);
/*!40000 ALTER TABLE `Menu` ENABLE KEYS */;
UNLOCK TABLES;


-- *************************************************************************
-- To be determined...
-- Dumping data for table `levels`
--

LOCK TABLES `levels` WRITE;
/*!40000 ALTER TABLE `levels` DISABLE KEYS */;
INSERT INTO `levels` VALUES (1,'cactus','speed run','IS1UqGqEWLH82KkezFNw','2022-04-17 21:16:53',0.25),(2,'overwrought','standard','UTPBVJwTal6UhAPE3UkH','2022-04-17 21:16:53',0.00),(3,'marked','standard','7EtWpjEsgwciT9GHTjgq','2022-04-17 21:16:53',1.00),(4,'develop','versus','VzfnBzGbQ1MaK1aTUSPK','2022-04-17 21:16:53',0.67),(5,'knowing','standard','Y9geWGvzD51ruXVIfJ5n','2022-04-17 21:16:53',0.00),(6,'bump','versus','cruf6PIGeu2CEz8cLTRa','2022-04-17 21:16:53',0.33),(7,'ragged','standard','xiZhB51ig7f8UHCqIQHh','2022-04-17 21:16:53',0.75),(8,'babies','versus','ykVeb4iZZ8t2tHmDJSdA','2022-04-17 21:16:53',0.50),(9,'hall','standard','H8KVwFqgjXsaaTc9gAPT','2022-04-17 21:16:53',1.00),(10,'arrange','speed run','AYsD5sjOY4bj1iRjRYf3','2022-04-17 21:16:53',0.00);
/*!40000 ALTER TABLE `levels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_level`
--

DROP TABLE IF EXISTS `user_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_level` (
  `id_user_level` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `id_level` int NOT NULL,
  `attempt_date` datetime NOT NULL,
  `completed` tinyint(1) NOT NULL,
  PRIMARY KEY (`id_user_level`),
  UNIQUE KEY `id_user_level_UNIQUE` (`id_user_level`),
  KEY `fk_user_idx` (`id_user`),
  KEY `fk_level_idx` (`id_level`),
  CONSTRAINT `fk_level` FOREIGN KEY (`id_level`) REFERENCES `levels` (`id_levels`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_user` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_users`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Update the average completion of levels after a new attempt is made';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_level`
--

LOCK TABLES `user_level` WRITE;
/*!40000 ALTER TABLE `user_level` DISABLE KEYS */;
INSERT INTO `user_level` VALUES (1,4,1,'2022-04-17 21:16:53',0),(2,19,1,'2022-04-17 21:16:53',0),(3,18,6,'2022-04-17 21:16:53',0),(4,6,4,'2022-04-17 21:16:53',0),(5,17,9,'2022-04-17 21:16:53',1),(6,1,9,'2022-04-17 21:16:53',1),(7,6,7,'2022-04-17 21:16:53',1),(8,14,7,'2022-04-17 21:16:53',1),(9,11,4,'2022-04-17 21:16:53',1),(10,18,10,'2022-04-17 21:16:53',0),(11,6,1,'2022-04-17 21:16:53',0),(12,12,6,'2022-04-17 21:16:53',1),(13,4,7,'2022-04-17 21:16:53',0),(14,15,7,'2022-04-17 21:16:53',1),(15,14,8,'2022-04-17 21:16:53',0),(16,2,8,'2022-04-17 21:16:53',1),(17,18,4,'2022-04-17 21:16:53',1),(18,10,3,'2022-04-17 21:16:53',1),(19,6,6,'2022-04-17 21:16:53',0),(20,10,1,'2022-04-17 21:16:53',1);
/*!40000 ALTER TABLE `user_level` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `user_level_AFTER_INSERT` AFTER INSERT ON `user_level` FOR EACH ROW BEGIN
	update levels l 
	join (select id_level, avg(completed) as rate from api_game_db.user_level group by id_level) r 
	on l.id_levels = r.id_level
	set l.completion_rate = r.rate;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_users` int NOT NULL AUTO_INCREMENT,
  `name` varchar(20) NOT NULL,
  `surname` varchar(45) NOT NULL,
  PRIMARY KEY (`id_users`),
  UNIQUE KEY `id_users_UNIQUE` (`id_users`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Amara','Mayo'),(2,'Edgar','Dalton'),(3,'Jordan','Holland'),(4,'Jayda','Montoya'),(5,'Myles','Harmon'),(6,'Kelvin','Kidd'),(7,'Gabriela','Lang'),(8,'Tori','Wood'),(9,'Triston','Mercado'),(10,'Lilianna','Sutton'),(11,'Quincy','Horne'),(12,'Autumn','Obrien'),(13,'Journey','Morse'),(14,'Samir','Velez'),(15,'Malik','Lowe'),(16,'Reina','Sexton'),(17,'Sienna','Strickland'),(18,'Arjun','Lester'),(19,'Marvin','Rollins'),(22,'a','a');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

SELECT * FROM vg_db.PersonChef;
