WITH CTE_ReportCount
AS
(
SELECT d.Id,
       d.Name AS [Department Name],
       c.Name AS [Category Name],
	   COUNT(r.Id) AS ReportCount
FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Id, d.Name, c.Name
)

SELECT [Department Name],
       cte.[Category Name],
	   CAST(ROUND(CAST(cte.ReportCount AS DECIMAL(4, 2)) / CAST(tt.ReportCount AS DECIMAL(4, 2)) * 100, 0) AS INT) AS Percentage
FROM CTE_ReportCount AS cte
JOIN
(
SELECT d.Id,
       d.Name,
       COUNT(r.Id) AS ReportCount
FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Id, d.Name
) AS tt ON tt.Id = cte.Id
ORDER BY [Department Name]