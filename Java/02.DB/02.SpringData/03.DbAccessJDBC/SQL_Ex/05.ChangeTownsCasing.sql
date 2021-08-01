UPDATE towns
SET `name` = UPPER(`name`)
WHERE country = 'Bulgaria';

SELECT `name`
FROM towns
WHERE country = 'Bulgaria';