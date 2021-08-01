

WITH 
cte1 AS(
SELECT c.`name`, SUM(p.salary) AS total_sum_of_salaries
FROM countries AS c
LEFT JOIN towns AS t
ON t.country_id = c.id
LEFT JOIN stadiums AS st
ON st.town_id = t.id
LEFT JOIN teams AS te
ON te.stadium_id = st.id
LEFT JOIN players AS p
ON p.team_id = te.id
GROUP BY c.id
),
cte2 AS(
SELECT c.`name`, COUNT(p.id) AS total_count_of_players
FROM countries AS c
LEFT JOIN towns AS t
ON t.country_id = c.id
LEFT JOIN stadiums AS st
ON st.town_id = t.id
LEFT JOIN teams AS te
ON te.stadium_id = st.id
LEFT JOIN players AS p
ON p.team_id = te.id
GROUP BY c.id
)
SELECT cte1.`name`, total_count_of_players, total_sum_of_salaries
FROM cte1
JOIN cte2
ON cte1.`name` = cte2.`name`
ORDER BY total_count_of_players DESC,
cte1.`name` ASC;