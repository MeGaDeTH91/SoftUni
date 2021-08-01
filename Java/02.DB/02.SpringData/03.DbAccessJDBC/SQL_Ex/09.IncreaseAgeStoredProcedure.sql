DELIMITER ###

CREATE PROCEDURE usp_get_older(minion_id INT)
BEGIN
	UPDATE minions
	SET age = age + 1
	WHERE id = minion_id;
END ###

DELIMITER ;

SELECT `name`,
age
FROM minions
WHERE id = 1;

CALL usp_get_older(1);