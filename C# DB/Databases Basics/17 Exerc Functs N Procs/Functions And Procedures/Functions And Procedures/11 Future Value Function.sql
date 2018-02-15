CREATE FUNCTION ufn_CalculateFutureValue(@sum MONEY, @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS MONEY
AS
BEGIN
DECLARE @fv MONEY;
SET @fv = @sum * (POWER(1 + @yearlyInterestRate, @numberOfYears))
RETURN @fv
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)