DELIMITER ###

CREATE PROCEDURE usp_get_employees_by_salary_level(salary_level VARCHAR(20))
BEGIN
	SELECT e.`first_name`, e.`last_name`
    FROM employees AS e
    WHERE 
    CASE
    WHEN salary_level = 'Low' THEN e.salary < 30000
    WHEN salary_level = 'Average' THEN e.salary >= 30000 AND e.salary <= 50000
    WHEN salary_level = 'High' THEN e.salary > 50000
    END
    ORDER BY
    e.first_name DESC,
    e.last_name DESC;
END ###

DELIMITER ;

CALL usp_get_employees_by_salary_level('High');