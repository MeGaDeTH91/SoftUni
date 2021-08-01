WITH 
`max_peak` AS(
SELECT c.country_name, MAX(p.elevation) AS highest_peak
FROM countries AS c
LEFT JOIN mountains_countries AS mc
USING(country_code)
LEFT JOIN peaks AS p
USING(mountain_id)
GROUP BY c.country_name
),
`max_river` AS(
SELECT c.country_name, MAX(r.length) AS longest_river
FROM countries AS c
LEFT JOIN countries_rivers AS cr
USING(country_code)
LEFT JOIN rivers AS r
ON r.id = cr.river_id
GROUP BY c.country_name
)
SELECT mp.country_name,
mp.highest_peak AS highest_peak_elevation,
mr.longest_river AS longest_river_length
FROM max_peak AS mp
JOIN max_river AS mr
ON mp.country_name = mr.country_name
ORDER BY
mp.highest_peak DESC,
mr.longest_river DESC,
mp.country_name ASC
LIMIT 5