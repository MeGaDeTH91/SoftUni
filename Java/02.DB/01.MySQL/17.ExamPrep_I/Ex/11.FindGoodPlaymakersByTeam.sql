DELIMITER ###

CREATE PROCEDURE udp_find_playmaker(min_dribble_points INT(11), team_name VARCHAR(45))
BEGIN
	SELECT CONCAT(p.first_name, ' ', p.last_name) AS full_name,
	p.age,
	p.salary,
	sk.dribbling,
	sk.speed,
	t.`name` AS team_name
	FROM players AS p
	JOIN skills_data AS sk
	ON sk.id = p.skills_data_id
	JOIN teams AS t
	ON t.id = p.team_id
	WHERE sk.dribbling > min_dribble_points AND
	t.`name` = team_name AND
	sk.speed > (
		SELECT AVG(sk.speed) AS avg_speed
		FROM players AS p
		JOIN skills_data AS sk
		ON sk.id = p.skills_data_id)
	ORDER BY sk.speed DESC
	LIMIT 1;
END ###

DELIMITER ;

CALL udp_find_playmaker(20, 'Skyble');