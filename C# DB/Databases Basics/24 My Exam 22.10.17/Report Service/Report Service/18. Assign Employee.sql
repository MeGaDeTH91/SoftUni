CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
	DECLARE @empDepartId INT = 
	(
	SELECT e.DepartmentId
	FROM Employees AS e
	WHERE e.Id = @employeeId)

	DECLARE @repDepartId INT = (
	SELECT c.DepartmentId
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE r.Id = @reportId)

	IF(@empDepartId <> @repDepartId)
		BEGIN
			RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
			RETURN
		END
	UPDATE Reports
	SET EmployeeId = @employeeId
END