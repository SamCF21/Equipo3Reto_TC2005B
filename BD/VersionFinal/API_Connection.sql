DROP SCHEMA IF EXISTS vg_db2;
CREATE DATABASE IF NOT EXISTS vg_db2 DEFAULT CHARACTER SET utf8mb4;
USE vg_db2;

DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `email` varchar(65) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_identifier_UNIQUE` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `User` WRITE;
INSERT INTO `User` VALUES (1,'Sam88799','Sam123@88799', 'sam88799@outlook.com'),(2,'Cristgad','Venezuela123', 'CrisyVenezuela4eva@gmail.com'),(3,'X-mob14','z12w91y41', 'xmob@hotmail.com'),(4,'Fer_vie','3ot1im8ah', 'solecito@yahoo.com'),(5,'tumalxn','mautum123', 'mautum@mail.com');
UNLOCK TABLES;

DROP TABLE IF EXISTS `Personalization`;
CREATE TABLE `Personalization` (
  `person_id` int NOT NULL AUTO_INCREMENT,
  `difficulty` int NOT NULL,
  `eyecolor` int NOT NULL,
  `skincolor` int NOT NULL,
  `nationality`int NOT NULL,
  PRIMARY KEY (`person_id`),
  UNIQUE KEY `person_identifier_UNIQUE` (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Personalization` WRITE;
INSERT INTO `Personalization` VALUES (1, 1, 2, 7, 2), (2, 2, 2, 3, 2), (3, 1, 2, 8, 3), (4, 3, 2, 6, 1), (5, 3, 6, 7, 1);
UNLOCK TABLES;

DROP TABLE IF EXISTS `Skilltree`;
CREATE TABLE `Skilltree` (
  `path` int NOT NULL,
  `attack` int NOT NULL,
  `speed` int NOT NULL,
  `life` int NOT NULL,
  PRIMARY KEY (`path`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Skilltree` WRITE;
INSERT INTO `Skilltree` VALUES (1, 1, 2, 7), (2, 2, 2, 3), (3, 1, 2, 8);
UNLOCK TABLES;


DROP TABLE IF EXISTS `Session`;
CREATE TABLE `Session` (
  `sso_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `timestamp` TIMESTAMP NOT NULL,
  `lastcheck` int NOT NULL,
  `skillpoints`int NOT NULL,
  `person_id`int NOT NULL,
  `path`int NOT NULL,
  PRIMARY KEY (`sso_id`),
  UNIQUE KEY `sso_identifier_UNIQUE` (`sso_id`),
  FOREIGN KEY (`user_id`) REFERENCES `User`(`user_id`),
  FOREIGN KEY (`person_id`) REFERENCES `Personalization`(`person_id`),
  FOREIGN KEY (`path`) REFERENCES `Skilltree`(`path`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `Session` WRITE;
INSERT INTO `Session` VALUES (1, 1, '2022-07-15 14:30:00', 1, 100, 1, 1), (2, 2, '2022-07-15 14:35:00', 2, 200, 2, 1), (3, 3, '2022-07-15 14:40:00', 3, 300, 3, 2), (4, 4, '2022-07-15 14:45:00', 3, 300, 4, 3), (5, 5, '2022-07-15 14:50:00', 2, 200, 5, 3);
UNLOCK TABLES;

SELECT * FROM vg_db2.Personalization;
SELECT * FROM vg_db2.Session;
SELECT * FROM vg_db2.Skilltree;
SELECT * FROM vg_db2.User;
