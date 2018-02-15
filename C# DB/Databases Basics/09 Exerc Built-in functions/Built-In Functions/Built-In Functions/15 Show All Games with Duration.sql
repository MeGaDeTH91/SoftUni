SELECT * FROM Games
SELECT [Name] AS Game,
CASE 
WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11.59  THEN 'Morning'
WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17.59  THEN 'Afternoon'
WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23.59  THEN 'Evening'
END AS [Part of the Day], 
CASE 
WHEN Duration <= 3  THEN 'Extra Short'
WHEN Duration >= 4 AND Duration <= 6  THEN 'Short'
WHEN Duration >6  THEN 'Long'
WHEN Duration IS NULL THEN 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Name], Duration, [Part of the Day]