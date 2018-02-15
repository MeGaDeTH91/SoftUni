SELECT j.JobId,
       (SELECT ISNULL(SUM(p.Price * op.Quantity), 0)
        FROM Parts AS p
        JOIN OrderParts AS op ON op.PartId = p.PartId
        JOIN Orders AS o ON o.OrderId = op.OrderId
        JOIN Jobs AS j2 ON j2.JobId = o.JobId
		WHERE j2.JobId = j.JobId
) AS [Parts Total]
FROM Jobs AS j
WHERE j.Status = 'Finished'
ORDER BY [Parts Total] DESC, j.JobId