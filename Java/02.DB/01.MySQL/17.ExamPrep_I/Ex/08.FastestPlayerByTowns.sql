SELECT MAX(sk.speed) AS max_speed, t.`name` AS town_name
FROM towns AS t
LEFT JOIN stadiums AS st
ON st.town_id = t.id
LEFT JOIN teams AS te
ON te.stadium_id = st.id
LEFT JOIN players AS p
ON p.team_id = te.id
LEFT JOIN skills_data AS sk
ON sk.id = p.skills_data_id
WHERE te.`name` <> 'Devify'
GROUP BY t.id
ORDER BY max_speed DESC,
town_name ASC;