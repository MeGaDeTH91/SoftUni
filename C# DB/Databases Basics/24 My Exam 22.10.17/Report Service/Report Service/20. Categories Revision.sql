WITH CTE_WithoutMain
AS
(
SELECT c.Id AS CategoryId,
       c.Name AS CategoryName,
	   COUNT(r.Id) AS InnerReportNum
FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
WHERE r.StatusId IN(1, 2)
GROUP BY c.Id,c.Name
)



SELECT cte.CategoryName,
       cte.InnerReportNum AS [Reports Number],
	   (SELECT
	   CASE
	   WHEN 
	   FROM)
FROM CTE_WithoutMain AS cte
JOIN
(
SELECT c.Id AS CategoryId,
       c.Name AS CategoryName,
	   r.StatusId
FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
WHERE r.StatusId IN(1, 2)
GROUP BY c.Id,c.Name, r.StatusId
) AS hp ON hp.CategoryId = cte.CategoryId
JOIN Status AS s ON s.Id = hp.StatusId
GROUP BY cte.CategoryName, cte.InnerReportNum, s.Label

--SELECT * FROM Status