DELIMITER ###

CREATE PROCEDURE usp_transfer_money(from_account_id INT, to_account_id INT, amount DECIMAL(20,4))
BEGIN
	START TRANSACTION;
	IF(amount <= 0 OR
    from_account_id <= 0 OR
    to_account_id <= 0 OR
    (SELECT a.balance
    FROM accounts AS a
    WHERE a.id = from_account_id) - amount < 0)
		THEN ROLLBACK;
	ELSE
		UPDATE accounts
		SET balance = balance - amount
		WHERE accounts.id = from_account_id;
        
        UPDATE accounts
		SET balance = balance + amount
		WHERE accounts.id = to_account_id;
		COMMIT;
	END IF;
END ###

DELIMITER ;

CALL usp_transfer_money(1, 2, 10);