WITH CTE_Prods
AS
(
SELECT p.Id, 
       p.Name AS [ProductName],
       AVG(f.Rate) AS [ProductAverageRate],
	   d.Name AS [DistributorName],
	   c.Name AS [DistributorCountry]
FROM Products AS p
JOIN Feedbacks AS f ON f.ProductId = p.Id
JOIN ProductsIngredients AS pri ON pri.ProductId = p.Id
JOIN Ingredients AS i ON i.Id = pri.IngredientId
JOIN Distributors AS d ON d.Id = i.DistributorId
JOIN Countries AS c ON c.Id = d.CountryId
GROUP BY p.Id,p.Name, d.Name, c.Name
)

SELECT c.ProductName,
       ProductAverageRate,
	   DistributorName,
	   DistributorCountry 
FROM CTE_Prods AS c
JOIN
(
SELECT ProductName, COUNT(DistributorName) AS DistributorCount
FROM CTE_Prods AS cte
GROUP BY ProductName
) AS DistributorCount ON DistributorCount.ProductName = c.ProductName
WHERE DistributorCount = 1
ORDER BY c.Id