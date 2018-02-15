CREATE FUNCTION udf_GetRating(@productName NVARCHAR(25))
RETURNS VARCHAR(20)
AS
BEGIN
	DECLARE @rating DECIMAL(15, 2) = (SELECT AVG(f.Rate) 
	FROM Products AS p
	JOIN Feedbacks AS f ON f.ProductId = p.Id
	WHERE p.Name = @productName)

	DECLARE @result VARCHAR(20);

	IF(@rating < 5)
		BEGIN
		    SET @result = 'Bad';
		END
	ELSE IF(@rating BETWEEN 5 AND 8)
		BEGIN
		    SET @result = 'Average';
		END
	ELSE IF(@rating > 8)
		BEGIN
		    SET @result = 'Good';
		END
	ELSE
		BEGIN
		    SET @result = 'No rating';
		END
		RETURN @result;
END