UPDATE employees AS e 
JOIN stores AS s
ON s.id = e.store_id
SET e.salary = e.salary - 500,
e.manager_id = 3
WHERE YEAR(e.hire_date) >= 2003 AND
s.`name` NOT IN('Cardguard', 'Veribet');