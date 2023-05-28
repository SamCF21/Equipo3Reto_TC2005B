Use version1;

-- Insert random data into Usuario table
INSERT INTO Usuario (username, password, email)
SELECT
    CONCAT('user', user_id) AS username,
    CONCAT('pass', user_id) AS password,
    CONCAT('user', user_id, '@example.com') AS email
FROM
    (SELECT @user_id := @user_id + 1 AS user_id FROM Usuario, (SELECT @user_id := 0) AS u LIMIT 15) AS users;

-- Insert random data into Menu table
INSERT INTO Menu (volume, music, user_id)
SELECT
    ROUND(RAND() * 10) AS volume,
    ROUND(RAND()) AS music,
    user_id
FROM
    Usuario
LIMIT 15;

-- Insert random data into Enemy table
INSERT INTO Enemy (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @enmy_id := @enmy_id + 1 AS enmy_id FROM Enemy, (SELECT @enmy_id := 0) AS e LIMIT 15) AS enemies;

-- Insert random data into FinalBoss table
INSERT INTO FinalBoss (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @fb_id := @fb_id + 1 AS fb_id FROM FinalBoss, (SELECT @fb_id := 0) AS f LIMIT 15) AS bosses;

-- Insert random data into Dificultad table
INSERT INTO Dificultad (Valor, enmy_id, fb_id)
SELECT
    ROUND(RAND() * 10) AS Valor,
    enmy_id,
    fb_id
FROM
    Enemy, FinalBoss
LIMIT 15;

-- Insert random data into Checkpoints table
INSERT INTO Checkpoints (location, user_id, points, timestamp)
SELECT
    ROUND(RAND() * 100) AS location,
    user_id,
    ROUND(RAND() * 1000) AS points,
    NOW() - INTERVAL ROUND(RAND() * 30) DAY
FROM
    Usuario
LIMIT 15;

-- Insert random data into Sesion table
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

-- Insert random data into MainCharacter table
INSERT INTO MainCharacter (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @mc_id := @mc_id + 1 AS mc_id FROM MainCharacter, (SELECT @mc_id := 0) AS mc LIMIT 15) AS main_characters;

-- Insert random data into Ally table
INSERT INTO Ally (attack, speed, life)
SELECT
    ROUND(RAND() * 100) AS attack,
    ROUND(RAND() * 100) AS speed,
    ROUND(RAND() * 100) AS life
FROM
    (SELECT @ally_id := @ally_id + 1 AS ally_id FROM Ally, (SELECT @ally_id := 0) AS a LIMIT 15) AS allies;

-- Insert random data into Skilltree table
INSERT INTO Skilltree (mc_id, ally_id, truck)
SELECT
    mc_id,
    ally_id,
    ROUND(RAND() * 10) AS truck
FROM
    MainCharacter, Ally
LIMIT 15;

-- Insert random data into Person_Chef table
INSERT INTO Person_Chef (color_ojos, color_piel, nacionalidad)
SELECT
    ROUND(RAND() * 10) AS color_ojos,
    ROUND(RAND() * 10) AS color_piel,
    ROUND(RAND() * 10) AS nacionalidad
FROM
    (SELECT @chef_id := @chef_id + 1 AS chef_id FROM Person_Chef, (SELECT @chef_id := 0) AS pc LIMIT 15) AS chefs;

-- Insert random data into FoodTruck table
INSERT INTO FoodTruck (life, gen_allies)
SELECT
    ROUND(RAND() * 100) AS life,
    ROUND(RAND() * 10) AS gen_allies
FROM
    (SELECT @truck_id := @truck_id + 1 AS truck_id FROM FoodTruck, (SELECT @truck_id := 0) AS ft LIMIT 15) AS trucks;
