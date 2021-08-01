SELECT cl.full_name,
COUNT(c.id) AS count_of_cars,
SUM(co.bill) AS total_sum
FROM clients AS cl
JOIN courses AS co
ON co.client_id = cl.id
JOIN cars AS c
ON c.id = co.car_id
WHERE cl.full_name LIKE '_a%'
GROUP BY cl.id
HAVING count_of_cars > 1
ORDER BY cl.full_name;