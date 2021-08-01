SELECT p.`name` AS product_name,
p.price,
p.best_before,
CONCAT(SUBSTRING(p.`description`, 1, 10), '...') AS short_description,
pc.url
FROM products AS p
JOIN pictures AS pc
ON pc.id = p.picture_id
WHERE LENGTH(p.`description`) > 100 AND
YEAR(pc.added_on) < 2019 AND
p.price > 20
ORDER BY p.price DESC;
