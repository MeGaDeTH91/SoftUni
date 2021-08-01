SELECT `department_id`, 
(
SELECT DISTINCT `salary` FROM `employees` AS `emp_2`
WHERE `emp_1`.`department_id` = `emp_2`.`department_id`
ORDER BY `salary` DESC
LIMIT 2, 1
) AS `third_highest_salary`
FROM `employees` AS `emp_1`
GROUP BY `department_id`
HAVING `third_highest_salary` IS NOT NULL
ORDER BY `department_id` ASC;