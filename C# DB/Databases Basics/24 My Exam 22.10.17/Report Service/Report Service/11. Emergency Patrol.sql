SELECT r.OpenDate,
       r.Description,
	   u.Email AS [Reporter Email]
FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE CloseDate IS NULL AND 
LEN(r.Description) > 20 AND 
r.Description LIKE '%str%' AND
c.DepartmentId IN(1, 4, 5)
ORDER BY r.OpenDate, u.Email, r.Id