SELECT CONCAT(m.FirstName + ' ', LastName) AS Mechanic,
       COUNT(j.JobId) AS Jobs
FROM Mechanics AS m
JOIN Jobs AS j ON j.MechanicId = m.MechanicId
WHERE j.Status <> 'Finished'
GROUP BY m.FirstName, m.LastName, m.MechanicId
HAVING COUNT(m.FirstName) > 1
ORDER BY Jobs DESC, m.MechanicId