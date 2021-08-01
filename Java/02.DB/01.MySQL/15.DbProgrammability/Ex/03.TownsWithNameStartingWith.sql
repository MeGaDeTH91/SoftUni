DELIMITER ###

CREATE PROCEDURE usp_get_towns_starting_with(target_str VARCHAR(20))
BEGIN
	SELECT `name` AS town_name
    FROM towns
    WHERE `name` LIKE CONCAT(target_str, '%')
    ORDER BY
    town_name ASC;
END ###

DELIMITER ;

CALL usp_get_towns_starting_with('b');