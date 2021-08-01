SELECT `name`
FROM `towns`
WHERE LENGTH(`name`) IN(5,6)
ORDER BY `name` ASC;