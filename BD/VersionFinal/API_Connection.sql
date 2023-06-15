DROP SCHEMA IF EXISTS vg_db;
CREATE DATABASE IF NOT EXISTS vg_db DEFAULT CHARACTER SET utf8mb4;
USE vg_db;


-- Create table User 
DROP TABLE IF EXISTS `User`;
CREATE TABLE `User` (
  `user_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(25) NOT NULL,
  `password` VARCHAR(25) NOT NULL,
  `email` VARCHAR(65) NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_identifier_UNIQUE` (`user_id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into User table
LOCK TABLES `User` WRITE;
INSERT INTO `User` VALUES (1,'Sam88799','Sam123@88799', 'sam88799@outlook.com'),(2,'Cristgad','Venezuela123', 'CrisyVenezuela4eva@gmail.com'),(3,'X-mob14','z12w91y41', 'xmob@hotmail.com'),(4,'Fer_vie','3ot1im8ah', 'solecito@yahoo.com'),(5,'tumalxn','mautum123', 'mautum@mail.com');
UNLOCK TABLES;


-- Create table Personalization
DROP TABLE IF EXISTS `Personalization`;
CREATE TABLE `Personalization` (
  `person_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `difficulty` TINYINT UNSIGNED NOT NULL,
  `eyecolor` TINYINT UNSIGNED NOT NULL,
  `skincolor` TINYINT UNSIGNED NOT NULL,
  `nationality`TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`person_id`),
  UNIQUE KEY `person_identifier_UNIQUE` (`person_id`),
  CHECK (`difficulty` BETWEEN 1 AND 3),
  CHECK (`eyecolor` BETWEEN 1 AND 8),
  CHECK (`skincolor` BETWEEN 1 AND 8),
  CHECK (`nationality` BETWEEN 1 AND 3)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into Personalization table
LOCK TABLES `Personalization` WRITE;
INSERT INTO `Personalization` VALUES (1, 1, 2, 7, 2), (2, 2, 2, 3, 2), (3, 1, 2, 8, 3), (4, 3, 2, 6, 1), (5, 3, 6, 7, 1);
UNLOCK TABLES;


-- Create table Skilltree
DROP TABLE IF EXISTS `Skilltree`;
CREATE TABLE `Skilltree` (
  `tree_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `path` TINYINT UNSIGNED NOT NULL,
  `attack` TINYINT UNSIGNED NOT NULL,
  `speed` TINYINT UNSIGNED NOT NULL,
  `life` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`tree_id`),
  UNIQUE KEY `tree_identifier_UNIQUE` (`tree_id`),
  CHECK (`path` BETWEEN 0 AND 3),
  CHECK (`attack` BETWEEN 0 AND 2),
  CHECK (`speed` BETWEEN 0 AND 2),
  CHECK (`life` BETWEEN 0 AND 2)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into Skilltree table
LOCK TABLES `Skilltree` WRITE;
INSERT INTO `Skilltree` VALUES (1, 1, 0, 0, 0), (2, 2, 1, 1, 1), (3, 3, 2, 2, 2), (4, 2, 1, 1, 1), (5, 1, 0, 0, 0);
UNLOCK TABLES;


-- Create table Ally
DROP TABLE IF EXISTS `Ally`;
CREATE TABLE `Ally` (
  `ally_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `attack` TINYINT UNSIGNED NOT NULL,
  `speed` TINYINT UNSIGNED NOT NULL,
  `life` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`ally_id`),
  UNIQUE KEY `ally_identifier_UNIQUE` (`ally_id`),
  CHECK (`attack` BETWEEN 0 AND 2),
  CHECK (`speed` BETWEEN 0 AND 2),
  CHECK (`life` BETWEEN 0 AND 2)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into Ally table
LOCK TABLES `Ally` WRITE;
INSERT INTO `Ally` VALUES (1, 0, 0, 0), (2, 1, 1, 1), (3, 2, 2, 2), (4, 1, 1, 1), (5, 0, 0, 0);
UNLOCK TABLES;


-- Create table Foodtruck
DROP TABLE IF EXISTS `Foodtruck`;
CREATE TABLE `Foodtruck` (
  `truck_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `life` TINYINT NOT NULL,
  PRIMARY KEY (`truck_id`),
  UNIQUE KEY `truck_identifier_UNIQUE` (`truck_id`),
  CHECK (`life` BETWEEN 0 AND 3)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into Foodtruck table
LOCK TABLES `Foodtruck` WRITE;
INSERT INTO `Foodtruck` VALUES (1, 1), (2, 2), (3, 3), (4, 2), (5, 1);
UNLOCK TABLES;


-- Create table LevelScore
DROP TABLE IF EXISTS `LevelScore`;
CREATE TABLE `LevelScore` (
  `score_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `level1` SMALLINT UNSIGNED NOT NULL,
  `level2` SMALLINT UNSIGNED NOT NULL,
  `level3` SMALLINT UNSIGNED NOT NULL,
  PRIMARY KEY (`score_id`),
  UNIQUE KEY `score_identifier_UNIQUE` (`score_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into LevelScore table
LOCK TABLES `LevelScore` WRITE;
INSERT INTO `LevelScore` VALUES (1, 10, 10, 10), (2, 20, 20, 20), (3, 30, 30, 30), (4, 40, 40, 40), (5, 50, 50, 50);
UNLOCK TABLES;


-- Create table Session
DROP TABLE IF EXISTS `Session`;
CREATE TABLE `Session` (
  `sso_id` SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `user_id` SMALLINT UNSIGNED NOT NULL,
  -- `timestamp` TIMESTAMP NOT NULL,
  `lastcheck` TINYINT UNSIGNED NOT NULL,
  `skillpoints`TINYINT UNSIGNED NOT NULL,
  `points`SMALLINT UNSIGNED NOT NULL,
  `person_id`SMALLINT UNSIGNED NOT NULL,
  `tree_id`SMALLINT UNSIGNED NOT NULL,
  `ally_id` SMALLINT UNSIGNED NOT NULL,
  `truck_id`SMALLINT UNSIGNED NOT NULL,
  `score_id`SMALLINT UNSIGNED NOT NULL,
  PRIMARY KEY (`sso_id`),
  UNIQUE KEY `sso_identifier_UNIQUE` (`sso_id`),
  FOREIGN KEY (`user_id`) REFERENCES `User`(`user_id`),
  FOREIGN KEY (`person_id`) REFERENCES `Personalization`(`person_id`),
  FOREIGN KEY (`tree_id`) REFERENCES `Skilltree`(`tree_id`),
  FOREIGN KEY (`ally_id`) REFERENCES `Ally`(`ally_id`),
  FOREIGN KEY (`truck_id`) REFERENCES `Foodtruck`(`truck_id`),
  FOREIGN KEY (`score_id`) REFERENCES `LevelScore`(`score_id`),
  CHECK (`lastcheck` BETWEEN 0 AND 3),
  CHECK (`skillpoints` BETWEEN 0 AND 16)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Insert data into Session table
LOCK TABLES `Session` WRITE;
INSERT INTO `Session` VALUES (1, 1, 1, 5, 100, 1, 1, 1, 1, 1), (2, 2, 2, 3, 200, 2, 2, 2, 2, 2), (3, 3, 3, 10, 300, 3, 3, 3, 3, 3), (4, 4, 3, 12, 200, 4, 4, 4, 4, 4), (5, 5, 2, 7, 100, 5, 5, 5, 5, 5);
-- INSERT INTO `Session` VALUES (1, 1, '2022-07-15 14:30:00', 1, 100, 1, 1), (2, 2, '2022-07-15 14:35:00', 2, 200, 2, 1), (3, 3, '2022-07-15 14:40:00', 3, 300, 3, 2), (4, 4, '2022-07-15 14:45:00', 3, 300, 4, 3), (5, 5, '2022-07-15 14:50:00', 2, 200, 5, 3);
UNLOCK TABLES;

SELECT * FROM vg_db2.User;
SELECT * FROM vg_db2.Session;
SELECT * FROM vg_db2.Personalization;
SELECT * FROM vg_db2.Skilltree;
SELECT * FROM vg_db2.Ally;
SELECT * FROM vg_db2.Foodtruck;
SELECT * FROM vg_db2.LevelScore;


-- ------------ Views -----------------
DROP VIEW IF EXISTS TopUsersByPoints;
CREATE VIEW TopUsersByPoints AS
SELECT u.username, s.points
FROM `User` u
JOIN `Session` s ON u.user_id = s.user_id
ORDER BY s.points DESC
LIMIT 5;

DROP VIEW IF EXISTS MostChosenNationalities;
CREATE VIEW MostChosenNationalities AS
SELECT
  CASE p.nationality
    WHEN 1 THEN 'Venezuelan'
    WHEN 2 THEN 'Mexican'
    WHEN 3 THEN 'American'
    ELSE 'Unknown'
  END AS nationality,
  COUNT(*) AS count
FROM `Personalization` p
JOIN `Session` s ON p.person_id = s.person_id
GROUP BY p.nationality
ORDER BY COUNT(*) DESC;

DROP VIEW IF EXISTS MostChosenEyeColors;
CREATE VIEW MostChosenEyeColors AS
SELECT
  CASE p.eyecolor
    WHEN 1 THEN 'Red'
    WHEN 2 THEN 'Orange'
    WHEN 3 THEN 'Yellow'
    WHEN 4 THEN 'Green'
    WHEN 5 THEN 'Blue'
    WHEN 6 THEN 'Purple'
    WHEN 7 THEN 'Black'
    WHEN 8 THEN 'White'
    ELSE 'Special'
  END AS eye_color,
  COUNT(*) AS count
FROM `Personalization` p
JOIN `Session` s ON p.person_id = s.person_id
GROUP BY p.eyecolor
ORDER BY count DESC;

DROP VIEW IF EXISTS MostChosenSkinColors;
CREATE VIEW MostChosenSkinColors AS
SELECT
  CASE p.skincolor
    WHEN 1 THEN 'Red'
    WHEN 2 THEN 'Orange'
    WHEN 3 THEN 'Yellow'
    WHEN 4 THEN 'Green'
    WHEN 5 THEN 'Blue'
    WHEN 6 THEN 'Purple'
    WHEN 7 THEN 'Black'
    WHEN 8 THEN 'White'
    ELSE 'Special'
  END AS skin_color,
  COUNT(*) AS count
FROM `Personalization` p
JOIN `Session` s ON p.person_id = s.person_id
GROUP BY p.skincolor
ORDER BY count DESC;


DROP VIEW IF EXISTS MostChosenSkillTreeUpgrades;
CREATE VIEW MostChosenSkillTreeUpgrades AS
SELECT
    CASE path
        WHEN 0 THEN 'Undecided'
        WHEN 1 THEN 'Cow'
        WHEN 2 THEN 'Chicken'
        WHEN 3 THEN 'Pig'
        ELSE 'Unknown'
    END AS upgrade,
    COUNT(*) AS count
FROM `Skilltree`
GROUP BY path
ORDER BY count DESC;

SELECT * FROM TopUsersByPoints;
SELECT * FROM MostChosenNationalities;
SELECT * FROM MostChosenEyeColors;
SELECT * FROM MostChosenSkinColors;
SELECT * FROM MostChosenSkillTreeUpgrades;