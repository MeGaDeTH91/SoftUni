CREATE PROCEDURE usp_GetTownsStartingWith(@StartLetter VARCHAR(10))
AS
SELECT [Name] AS Town
FROM Towns
WHERE [Name] LIKE CONCAT(@StartLetter, '%')