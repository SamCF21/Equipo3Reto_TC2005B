DROP SCHEMA IF EXISTS version1;
CREATE SCHEMA version1;
USE version1;

-- Creación de la tabla Usuario
CREATE TABLE Usuario (
  user_id INT AUTO_INCREMENT PRIMARY KEY,
  username VARCHAR(255) NOT NULL,
  password VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL
);

-- Creación de la tabla Menú
CREATE TABLE Menu (
  menu_id INT AUTO_INCREMENT PRIMARY KEY,
  volume INT NOT NULL,
  music BOOL NOT NULL,
  user_id INT,
  FOREIGN KEY (user_id) REFERENCES Usuario(user_id)
);

-- Creación de la tabla Enemy
CREATE TABLE Enemy (
  enmy_id INT AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
);

-- Creación de la tabla FinalBoss
CREATE TABLE FinalBoss (
  fb_id INT AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
);

-- Creación de la tabla Dificultad
CREATE TABLE Dificultad (
  diff_id INT AUTO_INCREMENT PRIMARY KEY,
  Valor INT NOT NULL,
  enmy_id INT,
  fb_id INT,
  FOREIGN KEY (enmy_id) REFERENCES Enemy(enmy_id),
  FOREIGN KEY (fb_id) REFERENCES FinalBoss(fb_id)
);

-- Creación de la tabla Checkpoints
CREATE TABLE Checkpoints (
  chkp_id INT AUTO_INCREMENT PRIMARY KEY,
  location INT NOT NULL,
  user_id INT,
  points INT NOT NULL,
  timestamp TIMESTAMP,
  FOREIGN KEY (user_id) REFERENCES Usuario(user_id)
);

-- Creación de la tabla Sesión
CREATE TABLE Sesion (
  sso_id INT AUTO_INCREMENT PRIMARY KEY,
  user_id INT,
  diff_id INT,
  timestamp TIMESTAMP,
  menu_id INT,
  chkp_id INT,
  FOREIGN KEY (user_id) REFERENCES Usuario(user_id),
  FOREIGN KEY (diff_id) REFERENCES Dificultad(diff_id),
  FOREIGN KEY (menu_id) REFERENCES Menu(menu_id),
  FOREIGN KEY (chkp_id) REFERENCES Checkpoints(chkp_id)
);

-- Creación de la tabla MainCharacter
CREATE TABLE MainCharacter (
  mc_id INT AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
);

-- Creación de la tabla Ally
CREATE TABLE Ally (
  ally_id INT AUTO_INCREMENT PRIMARY KEY,
  attack INT NOT NULL,
  speed INT NOT NULL,
  life INT NOT NULL
);

-- Creación de la tabla Skilltree
CREATE TABLE Skilltree (
  tree_id INT AUTO_INCREMENT PRIMARY KEY,
  mc_id INT,
  ally_id INT,
  truck INT,
  FOREIGN KEY (mc_id) REFERENCES MainCharacter(mc_id),
  FOREIGN KEY (ally_id) REFERENCES Ally(ally_id)
);

-- Creación de la tabla Person_Chef
CREATE TABLE Person_Chef (
  chef_id INT AUTO_INCREMENT PRIMARY KEY,
  color_ojos INT NOT NULL,
  color_piel INT NOT NULL,
  nacionalidad INT NOT NULL
);

-- Creación de la tabla FoodTruck
CREATE TABLE FoodTruck (
  truck_id INT AUTO_INCREMENT PRIMARY KEY,
  life INT NOT NULL,
  gen_allies INT NOT NULL
);
