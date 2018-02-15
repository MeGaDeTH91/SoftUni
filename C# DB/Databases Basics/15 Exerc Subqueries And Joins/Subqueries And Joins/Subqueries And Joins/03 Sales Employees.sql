SELECT * FROM Employees
SELECT * FROM Departments
SELECT * FROM Projects
SELECT * FROM EmployeesProjects

SELECT e.EmployeeID, 
       e.FirstName,
	   e.LastName,
	   d.Name AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID
