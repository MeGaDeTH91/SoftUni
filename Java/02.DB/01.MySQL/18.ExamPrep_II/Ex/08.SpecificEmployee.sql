SELECT CONCAT_WS(' ', e.first_name, e.last_name) AS Full_name,
s.`name` AS Store_name,
a.`name` AS address,
e.salary
FROM employees AS e
JOIN stores AS s
ON s.id = e.store_id
JOIN addresses AS a
ON a.id = s.address_id
WHERE e.salary < 4000 AND
a.`name` LIKE '%5%' AND
LENGTH(s.`name`) > 8 AND
e.last_name LIKE '%n';