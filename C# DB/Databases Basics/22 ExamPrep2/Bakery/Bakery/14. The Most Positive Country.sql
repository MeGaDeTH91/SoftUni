WITH CTE_TopAVG
AS
(
   SELECT TOP 1 WITH TIES 
                c.Name AS [CountryName],
                AVG(f.Rate) AS [FeedbackRate]
FROM Countries AS c
JOIN Customers AS cs ON cs.CountryId = c.Id
JOIN Feedbacks AS f ON f.CustomerId = cs.Id
GROUP BY c.Name
ORDER BY FeedbackRate DESC
)

SELECT TOP 1 c.Name,
             
FROM Countries AS c
JOIN Customers AS cs ON cs.CountryId = c.Id
JOIN Feedbacks AS f ON f.CustomerId = cs.Id