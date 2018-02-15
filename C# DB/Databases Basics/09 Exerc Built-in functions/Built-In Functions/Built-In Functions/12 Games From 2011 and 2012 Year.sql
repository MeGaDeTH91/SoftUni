SELECT TOP 50 [Name], FORMAT(DATEADD(SECOND, 1 , [Start]), 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE [Start] BETWEEN '2011' AND '2013'
ORDER BY [Start], [Name]
GO
SELECT * FROM Games
GO -- Second Solution
SELECT TOP(50) Name,FORMAT(Start,'yyyy-MM-dd')AS Start FROM Games
WHERE YEAR(Start) BETWEEN 2011 AND 2012
ORDER BY Start, Name
