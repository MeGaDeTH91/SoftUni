SELECT t.`name` AS team_name,
t.established,
t.fan_base,
(SELECT COUNT(p.id)
FROM players AS p
WHERE p.team_id = t.id) AS players_count
FROM teams AS t
ORDER BY
players_count DESC,
fan_base DESC;