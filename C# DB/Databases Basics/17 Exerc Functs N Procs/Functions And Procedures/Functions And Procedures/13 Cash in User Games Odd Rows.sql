CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS TABLE
AS
RETURN (
WITH CTE_Cash(Cash, RowNumber) AS 
(
SELECT ug.Cash, ROW_NUMBER() OVER(ORDER BY ug.Cash DESC)
FROM UsersGames AS ug
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.Name = @gameName
)
SELECT SUM(Cash) AS SumCash
FROM CTE_Cash
WHERE RowNumber % 2 = 1
)