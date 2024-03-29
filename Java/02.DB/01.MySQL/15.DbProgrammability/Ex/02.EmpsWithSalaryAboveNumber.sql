DELIMITER //
CREATE PROCEDURE usp_get_employees_salary_above(target_salary DECIMAL(10,4))
BEGIN
	SELECT first_name, last_name
    FROM employees
    WHERE salary >= target_salary
    ORDER BY
    first_name ASC,
    last_name ASC,
    employee_id ASC;
END //

DELIMITER ;
