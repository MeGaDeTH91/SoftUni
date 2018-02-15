SELECT CONCAT(FirstName, ' ', LastName) AS [Mechanic],
       AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId ,FirstName, LastName
ORDER BY m.MechanicId