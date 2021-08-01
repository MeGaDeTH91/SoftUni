DELIMITER ###

CREATE FUNCTION ufn_get_salary_level(target_salary DECIMAL(10,2))
RETURNS VARCHAR(25)
DETERMINISTIC
BEGIN
    RETURN CASE
    WHEN target_salary < 30000 THEN 'Low'
    WHEN target_salary >= 30000 AND target_salary <= 50000 THEN 'Average'
    WHEN target_salary > 50000 THEN 'High'
    END;
    
    RETURN salary_level;
END ###

DELIMITER ;

SELECT ufn_get_salary_level(20000);