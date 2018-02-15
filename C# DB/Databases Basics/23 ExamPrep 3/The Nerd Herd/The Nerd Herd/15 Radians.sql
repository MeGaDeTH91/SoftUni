CREATE FUNCTION udf_GetRadians(@degree FLOAT)
RETURNS FLOAT
AS
	BEGIN
		DECLARE @result FLOAT = @degree * PI() / 180

		RETURN @result
	END