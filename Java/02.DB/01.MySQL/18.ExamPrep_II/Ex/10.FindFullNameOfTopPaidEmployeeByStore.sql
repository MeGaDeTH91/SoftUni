DELIMITER ###

CREATE FUNCTION udf_top_paid_employee_by_store(store_name VARCHAR(50))
RETURNS VARCHAR(80)
DETERMINISTIC
BEGIN
    RETURN (
		SELECT CONCAT(e.first_name, ' ', e.middle_name, '. ', e.last_name,
        ' works in store for ',
        YEAR(DATE('2020-10-18')) - YEAR(e.hire_date), ' years')
        FROM stores AS s
        JOIN employees AS e
        ON e.store_id = s.id
        WHERE s.`name` = store_name
        ORDER BY e.salary DESC
        LIMIT 1
    );
END ###

DELIMITER ;

SELECT udf_top_paid_employee_by_store('Stronghold') AS 'full_info';