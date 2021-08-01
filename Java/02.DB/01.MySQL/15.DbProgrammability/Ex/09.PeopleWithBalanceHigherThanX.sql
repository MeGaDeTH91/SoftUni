DELIMITER ###

CREATE PROCEDURE usp_get_holders_with_balance_higher_than(target_balance INT)
BEGIN
	SELECT ah.`first_name`, ah.`last_name`
    FROM account_holders AS ah
    JOIN accounts AS a ON a.account_holder_id = ah.id
    GROUP BY ah.id
    HAVING SUM(a.balance) > target_balance
    ORDER BY ah.id ASC;
END ###

DELIMITER ;

CALL usp_get_holders_full_name();