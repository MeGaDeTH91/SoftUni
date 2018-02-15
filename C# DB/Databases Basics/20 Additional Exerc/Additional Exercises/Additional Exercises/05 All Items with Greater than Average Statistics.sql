SELECT * FROM Items
SELECT * FROM [Statistics]

DECLARE @avgMind INT = (SELECT AVG(Mind) FROM [Statistics])
DECLARE @avgLuck INT = (SELECT AVG(Luck) FROM [Statistics])
DECLARE @avgSpeed INT = (SELECT AVG(Speed) FROM [Statistics])

SELECT i.Name AS [Name],
       i.Price,
	   i.MinLevel,
	   s.Strength,
	   s.Defence,
	   s.Speed,
	   s.Luck,
	   s.Mind
FROM [Statistics] AS s
JOIN Items AS i ON i.StatisticId = s.Id
WHERE Mind > @avgMind AND Luck > @avgLuck AND Speed > @avgSpeed
ORDER BY [Name]
