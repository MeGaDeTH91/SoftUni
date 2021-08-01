DELIMITER ###

CREATE FUNCTION udf_stadium_players_count(stadium_name VARCHAR(30))
RETURNS INT
DETERMINISTIC
BEGIN    
	RETURN
		(SELECT COUNT(4)
        FROM stadiums AS s
        JOIN teams AS t
        ON t.stadium_id = s.id
        JOIN players AS p
        ON p.team_id = t.id
        WHERE s.`name` = stadium_name);
END ###

DELIMITER ;

SELECT udf_stadium_players_count ('Linklinks') as `count`;