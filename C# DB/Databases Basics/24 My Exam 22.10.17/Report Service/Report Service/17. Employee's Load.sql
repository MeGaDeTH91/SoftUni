CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
	BEGIN
		DECLARE @result INT;
		SET @result = 
		(
		SELECT COUNT(r.Id)
		FROM Reports AS r
		WHERE r.EmployeeId = @employeeId AND r.StatusId = @statusId)
		RETURN @result;
	END