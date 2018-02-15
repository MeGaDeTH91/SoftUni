WITH CTE_Help
AS
(
SELECT d.Name AS [Department Name],
       AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS [Average Duration]
FROM Departments AS d
JOIN Categories AS c ON c.DepartmentId = d.Id
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY d.Name
)
SELECT [Department Name],
       ISNULL(CAST([Average Duration] AS VARCHAR(10)), 'no info') AS [Average Duration]
FROM CTE_Help
ORDER BY [Department Name]