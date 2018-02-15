CREATE TABLE Deleted_Employees(
EmployeeId INT IDENTITY(1, 1),
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
JobTitle VARCHAR(50) NOT NULL,
DepartmentId INT NOT NULL,
Salary DECIMAL(15, 2) NOT NULL
CONSTRAINT PK_FiredEmps PRIMARY KEY(EmployeeId),
CONSTRAINT FK_FiredEmps FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId)
)
GO
CREATE TRIGGER tr_DeletedEmps ON Employees AFTER DELETE
AS
BEGIN
   INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary) 
   SELECT 
          d.FirstName,
	      d.LastName,
	      d.MiddleName,
	      d.JobTitle,
	      d.DepartmentID, 
		  d.Salary FROM deleted AS d
END
EXEC usp_DeleteEmployeesFromDepartment 2
SELECT * FROM Departments