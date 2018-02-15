CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
   BEGIN TRANSACTION
   DECLARE @currentCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @emloyeeId)
      INSERT INTO EmployeesProjects VALUES(@emloyeeId, @projectID)
	  IF(@currentCount >= 3)
	     BEGIN
		    ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN;
		 END
   COMMIT
END

EXEC usp_AssignProject 2, 7
SELECT * FROM EmployeesProjects