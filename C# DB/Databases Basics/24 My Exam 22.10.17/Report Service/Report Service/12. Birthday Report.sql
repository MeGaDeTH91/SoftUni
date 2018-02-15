SELECT c.Name AS [Category Name]
FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
JOIN Users AS u ON u.Id = r.UserId
WHERE FORMAT(u.BirthDate, 'MM-dd') = FORMAT(r.OpenDate, 'MM-dd')
GROUP BY c.Name
ORDER BY c.Name