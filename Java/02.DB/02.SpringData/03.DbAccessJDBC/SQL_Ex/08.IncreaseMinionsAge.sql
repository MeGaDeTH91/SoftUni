UPDATE minions
SET `name` = LOWER(`name`), age = age + 1
WHERE id IN(2,1,4);

SELECT `name`,
age
FROM minions;