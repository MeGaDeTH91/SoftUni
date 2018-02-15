CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15, 2)
AS
	BEGIN
		DECLARE @result DECIMAL(15, 2) = 0


		SET @result = (SELECT ISNULL(SUM(p.Price * op.Quantity), 0) AS [Parts Total]
FROM Parts AS p
JOIN OrderParts AS op ON op.PartId = p.PartId
JOIN Orders AS o ON o.OrderId = op.OrderId
WHERE o.JobId = @jobId)
		RETURN @result
	END