SELECT REVERSE(s.`name`) AS reversed_name,
CONCAT(UPPER(t.`name`), '-', a.`name`) AS full_address,
COUNT(e.id) AS employees_count
FROM stores AS s
JOIN addresses AS a
ON a.id = s.address_id
JOIN towns AS t
ON t.id = a.town_id
JOIN employees AS e
ON e.store_id = s.id
GROUP BY s.id
ORDER BY full_address ASC;