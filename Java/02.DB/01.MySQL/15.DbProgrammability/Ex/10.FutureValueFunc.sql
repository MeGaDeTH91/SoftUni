DELIMITER ###

CREATE FUNCTION ufn_calculate_future_value(sum DECIMAL(10,4), yearly_interest_rate DOUBLE, number_of_years INT)
RETURNS DECIMAL(10,4)
DETERMINISTIC
BEGIN
    DECLARE result DECIMAL(10,4);
    #SET result := 1000 * (POW(1 + 0.5, 5));
    SET result := sum * (POW(1 + yearly_interest_rate, number_of_years));
    
    RETURN result;
END ###

DELIMITER ;

SELECT ufn_calculate_future_value(1000, 0.5, 5);