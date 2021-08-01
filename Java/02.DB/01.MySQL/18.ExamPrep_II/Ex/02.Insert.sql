INSERT INTO products_stores(product_id, store_id)
(SELECT p.id AS product_id, 1 AS store_id
FROM products AS p
LEFT JOIN products_stores AS ps
ON ps.product_id = p.id
WHERE store_id IS NULL
)