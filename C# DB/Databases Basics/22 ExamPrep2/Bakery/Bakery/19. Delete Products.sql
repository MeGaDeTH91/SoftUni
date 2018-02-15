CREATE TRIGGER tk_Deletion ON Products INSTEAD OF DELETE
AS
BEGIN
	DECLARE @deleteId INT = (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
	WHERE ProductId = @deleteId

	DELETE FROM Feedbacks
	WHERE ProductId = @deleteId

	DELETE FROM Products
	WHERE Id = @deleteId
END