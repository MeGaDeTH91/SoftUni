DELIMITER ###

CREATE PROCEDURE usp_get_employees_from_town(town_name VARCHAR(30))
BEGIN
	SELECT e.`first_name`, e.`last_name`
    FROM employees AS e
    JOIN addresses AS a
    USING(address_id)
    JOIN towns AS t
    USING(town_id)
    WHERE t.`name` = town_name
    ORDER BY
    e.first_name ASC,
    e.last_name ASC,
    e.employee_id ASC;
END ###

DELIMITER ;

CALL usp_get_employees_from_town('Sofia');