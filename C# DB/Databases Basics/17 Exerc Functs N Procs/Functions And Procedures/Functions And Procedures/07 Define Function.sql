CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
DECLARE @currentLetter CHAR;
DECLARE @counter INT = 1;
 WHILE (LEN(@word) >= @counter)
 BEGIN
 SET @currentLetter = SUBSTRING(@word, @counter, 1)
 DECLARE @match INT = CHARINDEX(@currentLetter, @setOfLetters)
 IF (@match = 0)
     BEGIN
	     RETURN 0;
	 END
	SET @counter += 1;
 END
 RETURN 1;
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves')