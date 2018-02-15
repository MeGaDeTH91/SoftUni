SELECT TOP 50 e.EmployeeID,
       e.FirstName + ' ' + e.LastName AS [EmployeeName],
	   m.FirstName + ' ' + m.LastName AS [ManagerName],
	   d.Name
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID