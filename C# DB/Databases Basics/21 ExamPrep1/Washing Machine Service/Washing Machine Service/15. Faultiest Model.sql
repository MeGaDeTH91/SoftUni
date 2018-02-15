SELECT TOP 1 m.Name AS Model,
       COUNT(j.JobId) AS [Times Serviced],
	   (SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
FROM Jobs AS j
JOIN Orders AS o ON o.JobId = j.JobId
JOIN OrderParts AS op ON op.OrderId = o.OrderId
JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.ModelId = m.ModelId) AS Total
FROM Models AS m
JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.Name, m.ModelId
ORDER BY [Times Serviced] DESC

