CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15, 4))
AS
BEGIN
	   EXEC usp_WithdrawMoney @senderId, @amount
	   EXEC usp_DepositMoney @receiverId, @amount
END