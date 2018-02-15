SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Available]
FROM Mechanics AS m
LEFT OUTER JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.Status IS NULL OR j.Status = 'Finished'
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId