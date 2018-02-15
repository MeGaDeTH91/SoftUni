CREATE PROCEDURE usp_EmployeesBySalaryLevel(@inputsalary VARCHAR(10))
AS
SELECT e.FirstName, e.LastName
FROM Employees AS e
WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @inputsalary

EXEC usp_EmployeesBySalaryLevel Low