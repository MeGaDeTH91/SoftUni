CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@number MONEY)
AS
BEGIN
WITH CTE_HigherBalance(EmployeeID) AS(
SELECT AccountHolderId AS HolderID
FROM Accounts 
GROUP BY AccountHolderId
HAVING SUM(Balance) > @number
)

SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name]
FROM CTE_HigherBalance AS cte
JOIN AccountHolders AS ah ON ah.Id = cte.EmployeeID
ORDER BY ah.LastName, ah.FirstName 
END
EXEC usp_GetHoldersWithBalanceHigherThan 50
SELECT * FROM Accounts