CREATE PROCEDURE usp_PlaceOrder(@jobId INT, @partSerial VARCHAR(50), @quantity INT)
AS
BEGIN
	IF(@quantity <= 0)
	   BEGIN
	      RAISERROR('Part quantity must be more than zero!', 16, 1)
		  RETURN;
	   END

	DECLARE @JobExists INT = (SELECT COUNT(j.JobId)
	FROM Jobs AS j
	WHERE j.JobId = @jobId
	GROUP BY j.JobId
	HAVING COUNT(j.JobId) = 1)

	IF(@JobExists) IS NULL
		BEGIN
		    RAISERROR('Job not found!', 16, 1);
			RETURN;
		END

    DECLARE @Jobstatus VARCHAR(11) = (SELECT j.Status FROM Jobs AS j
	WHERE j.Status <> 'Finished' AND j.JobId = @jobId)

	IF(@Jobstatus IS NULL)
		BEGIN
		     RAISERROR('This job is not active!', 16, 1);
			 RETURN;
		END

	DECLARE @partExists INT = (SELECT p.PartId
FROM Parts AS p
WHERE p.SerialNumber = @partSerial)
    
	IF(@partExists IS NULL)
	   BEGIN
			RAISERROR('Part not found!', 16, 1);
			RETURN;
	   END

	DECLARE @orderExist INT = (SELECT o.OrderId
	FROM Orders AS o
	JOIN OrderParts AS op ON op.OrderId = o.OrderId
	JOIN Parts AS p ON p.PartId = op.PartId
	WHERE o.JobId = @jobId AND p.SerialNumber = @partSerial AND 
	IssueDate IS NULL)
  
IF(@orderExist IS NOT NULL)
     BEGIN
	    DECLARE @partIsListed INT = (SELECT p.PartId
		FROM Parts AS p
		JOIN OrderParts AS op ON op.PartId = p.PartId
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN Jobs AS j ON j.JobId = o.JobId
		WHERE p.SerialNumber = @partSerial AND j.JobId = @jobId)
			IF(@partIsListed IS NOT NULL)
			   BEGIN
			       UPDATE OrderParts
				   SET Quantity += @quantity
				   WHERE OrderId = @orderExist
			   END
			ELSE 
				BEGIN
					INSERT INTO OrderParts VALUES 
					(@orderExist, @partExists, @quantity) 
				END
				RETURN;
	 END
ELSE
	 INSERT INTO Orders(JobId, IssueDate, Delivered) VALUES
	 (@jobId, NULL, 0)
	 DECLARE @needOrder INT = (SELECT TOP 1 OrderId FROM Orders
	 ORDER BY OrderId DESC)
	 INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
	 (@needOrder, @partExists, @quantity)
END

--EXEC usp_PlaceOrder 23213213, 'JobNotFound', 1
--SELECT * FROM OrderParts
--SELECT * FROM Orders