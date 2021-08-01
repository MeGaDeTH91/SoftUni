DELIMITER ###

CREATE PROCEDURE usp_deposit_money(account_id INT, money_amount DECIMAL(10,4))
BEGIN
	START TRANSACTION;
	IF(money_amount <= 0)
		THEN ROLLBACK;
	ELSE
		UPDATE accounts
		SET balance = balance + money_amount
		WHERE accounts.id = account_id;
		COMMIT;
	END IF;
END ###

DELIMITER ;

CALL usp_deposit_money(1, 10);