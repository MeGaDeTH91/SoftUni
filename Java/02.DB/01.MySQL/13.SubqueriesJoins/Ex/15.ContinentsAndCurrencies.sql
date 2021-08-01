WITH 
`cte1` AS(
SELECT c.continent_code, ctr.currency_code, COUNT(ctr.currency_code) AS curr_usage
FROM continents AS c
JOIN countries AS ctr
USING(continent_code)
GROUP BY c.continent_code, ctr.currency_code
HAVING curr_usage > 1
),
`cte2` AS(
SELECT c.continent_code, MAX(c.curr_usage) AS max_usage
FROM cte1 AS c
GROUP BY c.continent_code
)
SELECT cte1.continent_code, cte1.currency_code, cte2.max_usage AS currency_usage
FROM cte1
JOIN cte2
ON cte1.continent_code = cte2.continent_code AND cte1.curr_usage = cte2.max_usage