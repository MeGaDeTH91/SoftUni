DELIMITER ###

CREATE FUNCTION ufn_is_word_comprised(set_of_letters varchar(50), word varchar(50))
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE is_comprised INT;
    DECLARE regular_expression VARCHAR(50);
    SET regular_expression := CONCAT('^[', set_of_letters, ']+$');
    SET is_comprised := CASE
    WHEN word REGEXP regular_expression THEN 1
    ELSE 0
    END;
    
    RETURN is_comprised;
END ###

DELIMITER ;

SELECT ufn_is_word_comprised('oistmiahf', 'Sofia');