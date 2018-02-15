SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
       CAST(COUNT(r.CloseDate) AS VARCHAR(20)) + '/' + CAST(COUNT(r.OpenDate) AS VARCHAR(20))
FROM Employees AS e
JOIN Reports AS r ON r.EmployeeId = e.Id
WHERE YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016
GROUP BY e.FirstName, e.LastName, e.Id
ORDER BY Name, e.Id