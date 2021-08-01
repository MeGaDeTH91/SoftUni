SELECT `first_name`, `last_name`, `department_id`
FROM `employees` AS `emp_1`
WHERE `salary` >
(
SELECT AVG(`salary`) FROM `employees` AS `emp_2`
WHERE `emp_1`.`department_id` = `emp_2`.`department_id`
GROUP BY `department_id`
)
ORDER BY 
`department_id` ASC,
`employee_id` ASC
LIMIT 10;