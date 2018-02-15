SELECT CONCAT(FirstName + ' ', LastName) AS Available
FROM Mechanics AS m1
WHERE m1.MechanicId NOT IN(
SELECT m2.MechanicId
FROM Mechanics AS m2
JOIN Jobs AS j ON j.MechanicId = m2.MechanicId
WHERE j.Status <> 'Finished'
)
ORDER BY m1.MechanicId
