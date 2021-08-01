SELECT v.name,
m.`name` AS `minion_name`,
m.age
FROM villains AS v
JOIN minions_villains AS mv
ON mv.villain_id = v.id
JOIN minions AS m
ON m.id = mv.minion_id
WHERE v.id = 1;