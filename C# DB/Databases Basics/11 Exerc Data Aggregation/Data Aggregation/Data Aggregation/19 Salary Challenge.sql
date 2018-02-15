SELECT TOP 10 FirstName, LastName, DepartmentID
FROM Employees AS Em1
WHERE Salary > (SELECT AVG(Salary) FROM Employees AS Em2
WHERE Em1.DepartmentID = Em2.DepartmentID
GROUP BY DepartmentID)
ORDER BY DepartmentID