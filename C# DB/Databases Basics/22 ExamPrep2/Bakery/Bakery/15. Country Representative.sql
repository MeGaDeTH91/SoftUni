WITH CTE_Ingredients
AS
(
SELECT CountryName,
       DistributorName,
       DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY IngredientCount DESC) AS [Rank]
FROM
(
SELECT c.Name AS [CountryName],
       d.Name AS [DistributorName],
       COUNT(i.Id) AS IngredientCount
FROM Distributors AS d
LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
LEFT JOIN Countries AS c ON c.Id = d.CountryId
GROUP BY c.Name, d.Name
)AS HelpTable
)

SELECT CountryName,
       DistributorName
FROM CTE_Ingredients AS c
WHERE Rank = 1
ORDER BY CountryName, DistributorName