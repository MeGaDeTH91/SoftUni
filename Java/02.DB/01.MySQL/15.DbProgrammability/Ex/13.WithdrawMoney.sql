DELIMITER ###

CREATE PROCEDURE usp_withdraw_money(account_id INT, money_amount DECIMAL(20,4))
BEGIN
	START TRANSACTION;
	IF(money_amount <= 0 OR 
    (SELECT a.balance
    FROM accounts AS a
    WHERE a.id = account_id) - money_amount < 0)
		THEN ROLLBACK;
	ELSE
		UPDATE accounts
		SET balance = balance - money_amount
		WHERE accounts.id = account_id;
		COMMIT;
	END IF;
END ###

DELIMITER ;

CALL usp_deposit_money(1, 10);