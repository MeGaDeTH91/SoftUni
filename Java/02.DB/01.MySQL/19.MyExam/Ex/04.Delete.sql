DELETE c
FROM clients AS c
LEFT JOIN 
(
     SELECT co.client_id, COUNT(co.id) AS course_count
     FROM courses AS co
     GROUP BY co.client_id
) og ON og.client_id = c.id
WHERE LENGTH(c.full_name) > 3
AND og.course_count IS NULL;