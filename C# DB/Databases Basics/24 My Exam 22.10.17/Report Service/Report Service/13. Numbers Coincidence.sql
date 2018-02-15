SELECT DISTINCT u.Username
FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE u.Username LIKE LTRIM('[1-9]%') AND 
LTRIM(LEFT(u.Username, 1)) = LTRIM(CAST(c.Id AS CHAR(1))) OR
u.Username LIKE RTRIM('%[1-9]') AND RTRIM(RIGHT(u.Username, 1)) = RTRIM(CAST(c.Id AS CHAR(1)))
ORDER BY u.Username