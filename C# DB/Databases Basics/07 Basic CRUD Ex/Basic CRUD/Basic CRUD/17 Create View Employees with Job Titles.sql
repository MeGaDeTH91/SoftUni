CREATE VIEW V_EmployeeNameJobTitle AS
SELECT (FirstName + ' ' + MiddleName + ' ' + LastName) AS [Full Name],
       JobTitle AS [Job Title]
	   FROM Employees
GO
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName + ' ', MiddleName, ' ' + LastName) AS [Full Name],
       JobTitle AS [Job Title]
	   FROM Employees
GO
UPDATE Employees
SET MiddleName = ''
WHERE MiddleName IS NULL

SELECT * FROM V_EmployeeNameJobTitle

SELECT CONCAT(FirstName + ' ', MiddleName, ' ' + LastName) AS [Full Name],
       JobTitle AS [Job Title]
	   FROM Employees