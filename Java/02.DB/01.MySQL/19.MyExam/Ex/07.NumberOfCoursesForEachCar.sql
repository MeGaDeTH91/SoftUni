SELECT cr.id AS car_id,
cr.make,
cr.mileage,
COUNT(co.id) AS count_of_courses,
FORMAT(AVG(co.bill), 2) AS avg_bill
FROM cars AS cr
LEFT JOIN courses AS co
ON cr.id = co.car_id
GROUP BY cr.id
HAVING count_of_courses <> 2
ORDER BY count_of_courses DESC,
cr.id ASC;
