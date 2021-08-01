SELECT v.name,
COUNT(DISTINCT mv.minion_id) AS minions_count
FROM villains AS v
JOIN minions_villains AS mv
ON mv.villain_id = v.id
GROUP BY v.name
HAVING minions_count > 15
ORDER BY minions_count DESC;