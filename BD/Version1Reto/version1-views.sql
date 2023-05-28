USE version1;

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


