WITH CTE_Betw5And8
AS
(
   SELECT p.Id AS PrId,
          p.Name AS [cteName],
		  AVG(f.Rate) AS [Average]
   FROM Products AS p
   JOIN Feedbacks AS f ON f.ProductId = p.Id
   GROUP BY p.Id, p.Name
   HAVING AVG(f.Rate) BETWEEN 5 AND 8
)

SELECT d.Name AS [DistributorName],
       i.Name AS [IngredientName],
	   p.Name AS [ProductName],
	   cte.Average AS [AverageRate]
FROM Distributors AS d
JOIN Ingredients AS i ON i.DistributorId = d.Id
JOIN ProductsIngredients AS pri ON pri.IngredientId = i.Id
JOIN Products AS p ON p.Id = pri.ProductId
JOIN CTE_Betw5And8 AS cte ON cte.PrId = p.Id
ORDER BY DistributorName, IngredientName, ProductName