WITH CTE_CurrencyUsage(ContinentCode, CurrencyCode, [CurrencyUsage])
AS
( 
SELECT c.ContinentCode,
       c.CurrencyCode,
	   COUNT(c.CurrencyCode) AS [CurrencyUsage]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1
)

SELECT cte.ContinentCode, CurrencyCode, CurrencyUsage 
FROM 
(
SELECT ContinentCode, MAX(CurrencyUsage) AS CurrUsage
FROM CTE_CurrencyUsage
GROUP BY ContinentCode
) AS [MaxCount]
JOIN CTE_CurrencyUsage AS cte
ON cte.ContinentCode = MaxCount.ContinentCode AND cte.CurrencyUsage = MaxCount.CurrUsage