DELIMITER ###

CREATE PROCEDURE udp_courses_by_address(address_name VARCHAR(100))
BEGIN
	SELECT a.`name`,
	cl.full_name,
	CASE
		WHEN co.bill <= 20 THEN 'Low'
		WHEN co.bill <= 30 THEN 'Medium'
		ELSE 'High'
	END AS level_of_bill,
	cr.make,
	cr.`condition`,
	ct.`name` AS cat_name
	FROM addresses AS a
	JOIN courses AS co
	ON co.from_address_id = a.id
	JOIN clients AS cl
	ON cl.id = co.client_id
	JOIN cars AS cr
	ON cr.id = co.car_id
	JOIN categories AS ct
	ON ct.id = cr.category_id
	WHERE a.`name` = address_name
	ORDER BY cr.make ASC,
	cl.full_name ASC;
END ###

DELIMITER ;

CALL udp_courses_by_address('700 Monterey Avenue');