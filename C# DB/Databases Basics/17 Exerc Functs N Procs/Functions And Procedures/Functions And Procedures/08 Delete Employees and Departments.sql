CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN 
(
SELECT EmployeeID 
FROM Employees
WHERE DepartmentID = @departmentId
)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN
(
SELECT EmployeeID
FROM Employees
WHERE DepartmentID = @departmentId
)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN
(
SELECT EmployeeID
FROM Employees
WHERE DepartmentID = @departmentId
)

DELETE FROM Employees
WHERE EmployeeID IN 
(
SELECT EmployeeID 
FROM Employees
WHERE DepartmentID = @departmentId
)

DELETE FROM Departments
WHERE DepartmentID = @departmentId

SELECT COUNT(*) FROM Departments AS d
JOIN Employees AS e ON e.EmployeeID = d.ManagerID
WHERE d.DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 3
SELECT * FROM Departments
--WHERE EmployeeID = 1

SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId