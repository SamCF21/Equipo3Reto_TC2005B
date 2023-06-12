DROP SCHEMA IF EXISTS vg_db;
CREATE DATABASE  IF NOT EXISTS vg_db DEFAULT CHARACTER SET utf8mb4;
USE vg_db;

-- Creación de la tabla Usuario
CREATE TABLE Usuario (
  user_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(20) NOT NULL,
  password VARCHAR(20) NOT NULL,
  email VARCHAR(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Insertar datos en la tabla Usuario obtenidos desde web (los únicos datos obtenidos son los del usuario debido al log in/sign up)
--
LOCK TABLES `Usuario` WRITE;
INSERT INTO `Usuario` VALUES (1,'Sam88799','Sam123@88799', 'sam88799@outlook.com'),(2,'Cristgad','Venezuela123', 'CrisyVenezuela4eva@gmail.com'),(3,'X-mob14','z12w91y41', 'xmob@hotmail.com'),(4,'Fer_vie','3ot1im8ah', 'solecito@yahoo.com'),(5,'tumalxn','mautum123', 'mautum@mail.com');
UNLOCK TABLES;

-- Creación de la tabla Menú
CREATE TABLE Menu (
  menu_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  volume INT NOT NULL,
  music BOOL NOT NULL,
  user_id SMALLINT UNSIGNED NOT NULL,
  FOREIGN KEY (user_id) REFERENCES Usuario(user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Enemy
CREATE TABLE Enemy (
  enmy_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla FinalBoss
CREATE TABLE FinalBoss (
  fb_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Dificultad
CREATE TABLE Dificultad (
  diff_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  Valor INT NOT NULL,
  enmy_id SMALLINT UNSIGNED NOT NULL,
  fb_id SMALLINT UNSIGNED NOT NULL,
  FOREIGN KEY (enmy_id) REFERENCES Enemy(enmy_id),
  FOREIGN KEY (fb_id) REFERENCES FinalBoss(fb_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Checkpoints
CREATE TABLE Checkpoints (
  chkp_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  location INT NOT NULL,
  user_id SMALLINT UNSIGNED NOT NULL,
  points INT NOT NULL,
  timestamp TIMESTAMP,
  FOREIGN KEY (user_id) REFERENCES Usuario(user_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Sesión
CREATE TABLE Sesion (
  sso_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  user_id SMALLINT UNSIGNED NOT NULL,
  diff_id SMALLINT UNSIGNED NOT NULL,
  timestamp TIMESTAMP,
  menu_id SMALLINT UNSIGNED NOT NULL,
  chkp_id SMALLINT UNSIGNED NOT NULL,
  FOREIGN KEY (user_id) REFERENCES Usuario(user_id),
  FOREIGN KEY (diff_id) REFERENCES Dificultad(diff_id),
  FOREIGN KEY (menu_id) REFERENCES Menu(menu_id),
  FOREIGN KEY (chkp_id) REFERENCES Checkpoints(chkp_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla MainCharacter
CREATE TABLE MainCharacter (
  mc_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Ally
CREATE TABLE Ally (
  ally_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Skilltree
CREATE TABLE Skilltree (
  tree_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  mc_id SMALLINT UNSIGNED NOT NULL,
  ally_id SMALLINT UNSIGNED NOT NULL,
  truck SMALLINT UNSIGNED NOT NULL,
  FOREIGN KEY (mc_id) REFERENCES MainCharacter(mc_id),
  FOREIGN KEY (ally_id) REFERENCES Ally(ally_id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla Person_Chef
CREATE TABLE Person_Chef (
  chef_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  color_ojos INT NOT NULL,
  color_piel INT NOT NULL,
  nacionalidad INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Creación de la tabla FoodTruck
CREATE TABLE FoodTruck (
  truck_id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
  life INT NOT NULL,
  gen_allies INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Consultar a los usuarios con mejor rank
CREATE VIEW TopRankedUsers AS
SELECT
    u.username,
    SUM(c.points) AS total_points
FROM
    Usuario u
    INNER JOIN Sesion s ON u.user_id = s.user_id
    INNER JOIN Checkpoints c ON s.chkp_id = c.chkp_id
GROUP BY
    u.user_id
ORDER BY
    total_points DESC;

-- Consultar el progreso por sesión de usuario
CREATE VIEW UserSessionProgress AS
SELECT
    u.username,
    s.timestamp AS session_timestamp,
    c.location AS checkpoint_location
FROM
    Usuario u
    INNER JOIN Sesion s ON u.user_id = s.user_id
    INNER JOIN Checkpoints c ON s.chkp_id = c.chkp_id;

-- Consultar las estadísticas del chef en una sesión en específico
CREATE VIEW MainCharacterDetails AS
SELECT
    u.username,
    mc.attack AS main_character_attack,
    mc.speed AS main_character_speed,
    mc.life AS main_character_life
FROM
    Usuario u
    INNER JOIN Sesion s ON u.user_id = s.user_id
    INNER JOIN MainCharacter mc ON s.user_id = mc.mc_id;

-- Consultar la personalización del chef para una sesión en específico
CREATE VIEW SessionChefPreferences AS
SELECT
    u.username,
    s.timestamp AS session_timestamp,
    pc.color_ojos AS chef_eye_color,
    pc.color_piel AS chef_skin_color,
    pc.nacionalidad AS chef_nationality
FROM
    Usuario u
    INNER JOIN Sesion s ON u.user_id = s.user_id
    INNER JOIN Checkpoints c ON s.chkp_id = c.chkp_id
    INNER JOIN Person_Chef pc ON c.user_id = pc.chef_id;
