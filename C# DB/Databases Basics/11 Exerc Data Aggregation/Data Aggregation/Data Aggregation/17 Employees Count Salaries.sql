SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL
SELECT * FROM Employees