WITH CTE_ThreeOrMore
AS
(
	SELECT COUNT(f.Id) AS [Feeds],
	       f.CustomerId AS Customer
	FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
	GROUP BY f.CustomerId
	HAVING COUNT(f.Id) >= 3 
)

SELECT f.ProductId,
       CONCAT(c.FirstName + ' ', c.LastName) AS [CustomerName],
	   ISNULL(f.Description, '') AS [FeedbackDescription]
FROM Feedbacks AS f
JOIN Customers AS c ON c.Id = f.CustomerId
JOIN CTE_ThreeOrMore AS cte ON cte.Customer = c.Id
ORDER BY ProductId, CustomerName, f.Id
