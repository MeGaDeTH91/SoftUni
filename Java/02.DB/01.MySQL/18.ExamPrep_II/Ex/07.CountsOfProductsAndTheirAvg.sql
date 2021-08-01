SELECT s.`name`,
COUNT(p.id) AS product_count,
FORMAT(AVG(p.price), 2) AS `avg`
FROM stores AS s
LEFT JOIN products_stores AS ps
ON ps.store_id = s.id
LEFT JOIN products AS p
ON p.id = ps.product_id
GROUP BY s.id
ORDER BY product_count DESC,
`avg` DESC,
s.id ASC;