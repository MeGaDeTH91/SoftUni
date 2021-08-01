SELECT MIN(`salaries`) AS `min_average_salary`
FROM
(
SELECT AVG(`salary`) AS `salaries`
FROM `employees`
GROUP BY `department_id`
) AS `dep_salaries`;