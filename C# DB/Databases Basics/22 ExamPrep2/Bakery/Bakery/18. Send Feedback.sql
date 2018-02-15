CREATE PROCEDURE usp_SendFeedback(@customerId INT, @productId INT, @rate DECIMAL(15, 2), @description NVARCHAR(255))
AS
BEGIN
	DECLARE @feedCount INT = (SELECT COUNT(Id) FROM Feedbacks WHERE CustomerId = @customerId AND ProductId = @productId)
	
	BEGIN TRANSACTION
	INSERT INTO Feedbacks(CustomerId, ProductId, Rate, Description) VALUES
	(@customerId, @productId, @rate, @description)

	IF(@feedCount >= 3)
		BEGIN
			ROLLBACK
			RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
		END

	COMMIT
END