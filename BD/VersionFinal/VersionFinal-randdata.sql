USE vg_db;

--
-- Datos aleatorios (temporales) para las entidades que no reciben datos de la web
--

-- Insertar datos aleatorios para Menú
INSERT INTO Menu (volume, music, user_id)
SELECT
    ROUND(RAND() * 10) AS volume,
    ROUND(RAND()) AS music,
    user_id
FROM
    Usuario
LIMIT 15;

-- Insertar datos aleatorios para Enemy
INSERT INTO Enemy (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @enmy_id := @enmy_id + 1 AS enmy_id FROM Enemy, (SELECT @enmy_id := 0) AS e LIMIT 15) AS enemies;

-- Insertar datos aleatorios para FinalBoss
INSERT INTO FinalBoss (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @fb_id := @fb_id + 1 AS fb_id FROM FinalBoss, (SELECT @fb_id := 0) AS f LIMIT 15) AS bosses;

-- Insertar datos aleatorios para Dificultad
INSERT INTO Dificultad (Valor, enmy_id, fb_id)
SELECT
    ROUND(RAND() * 10) AS Valor,
    enmy_id,
    fb_id
FROM
    Enemy, FinalBoss
LIMIT 15;

-- Insertar datos aleatorios para Checkpoints
INSERT INTO Checkpoints (location, user_id, points, timestamp)
SELECT
    ROUND(RAND() * 100) AS location,
    user_id,
    ROUND(RAND() * 1000) AS points,
    NOW() - INTERVAL ROUND(RAND() * 30) DAY
FROM
    Usuario
LIMIT 15;

-- Insertar datos aleatorios para Sesion
INSERT INTO Sesion (user_id, diff_id, timestamp, menu_id, chkp_id)
SELECT
    u.user_id,
    d.diff_id,
    NOW() - INTERVAL ROUND(RAND() * 30) DAY,
    m.menu_id,
    c.chkp_id
FROM
    Usuario u, Dificultad d, Menu m, Checkpoints c
LIMIT 15;

-- Insertar datos aleatorios para MainCharacter
INSERT INTO MainCharacter (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @mc_id := @mc_id + 1 AS mc_id FROM MainCharacter, (SELECT @mc_id := 0) AS mc LIMIT 15) AS main_characters;

-- Insertar datos aleatorios para Ally
INSERT INTO Ally (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @ally_id := @ally_id + 1 AS ally_id FROM Ally, (SELECT @ally_id := 0) AS a LIMIT 15) AS allies;

-- Insertar datos aleatorios para Skilltree
INSERT INTO Skilltree (mc_id, ally_id, truck)
SELECT
    mc_id,
    ally_id,
    ROUND(RAND() * 10) AS truck
FROM
    MainCharacter, Ally
LIMIT 15;

-- Insertar datos aleatorios para Person_Chef
INSERT INTO Person_Chef (color_ojos, color_piel, nacionalidad)
SELECT
    ROUND(RAND() * 10) AS color_ojos,
    ROUND(RAND() * 10) AS color_piel,
    ROUND(RAND() * 10) AS nacionalidad
FROM
    (SELECT @chef_id := @chef_id + 1 AS chef_id FROM Person_Chef, (SELECT @chef_id := 0) AS pc LIMIT 15) AS chefs;

-- Insertar datos aleatorios para FoodTruck
INSERT INTO FoodTruck (life, gen_allies)
SELECT
    ROUND(RAND() * 100) AS life,
    ROUND(RAND() * 10) AS gen_allies
FROM
    (SELECT @truck_id := @truck_id + 1 AS truck_id FROM FoodTruck, (SELECT @truck_id := 0) AS ft LIMIT 15) AS trucks;
