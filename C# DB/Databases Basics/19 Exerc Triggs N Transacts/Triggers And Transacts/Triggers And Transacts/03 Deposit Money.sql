CREATE PROCEDURE usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15, 4))
AS
BEGIN
     BEGIN TRANSACTION
	 UPDATE Accounts
	 SET Balance += @moneyAmount
	 WHERE Id = @accountId
	 IF (@@ROWCOUNT <> 1)
	    BEGIN
		     ROLLBACK
			 RAISERROR('Invalid Account', 16, 1)
			 RETURN;
		END
	 COMMIT;
END
EXEC usp_DepositMoney 1, 10
SELECT * FROM Accounts