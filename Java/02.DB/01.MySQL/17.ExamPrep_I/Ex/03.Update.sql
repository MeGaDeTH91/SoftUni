UPDATE coaches AS c 
JOIN 
(
     SELECT pc.coach_id , COUNT(pc.player_id) AS train_count
     FROM players_coaches AS pc
     GROUP BY pc.coach_id
) og ON og.coach_id = c.id
SET c.coach_level = c.coach_level + 1
WHERE c.first_name LIKE 'A%' AND og.train_count >= 1;

# Option 2
UPDATE coaches AS c 
JOIN players_coaches AS pc
ON pc.coach_id = c.id 
SET c.coach_level = c.coach_level + 1
WHERE c.first_name LIKE 'A%'