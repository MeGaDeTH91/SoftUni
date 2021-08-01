CREATE TABLE `emp_new` 
SELECT *
FROM `employees`
WHERE `salary`> 30000;

DELETE FROM `emp_new`
WHERE `manager_id` = 42;

UPDATE `emp_new`
SET `salary` = `salary` + 5000
WHERE `department_id` = 1;

SELECT `department_id`, AVG(`salary`) AS `avg_salary`
FROM `emp_new`
GROUP BY `department_id`
ORDER BY `department_id` ASC;