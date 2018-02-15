USE Geography

SELECT * FROM Peaks
SELECT * FROM Mountains

SELECT MountainRange, p.PeakName, p.Elevation FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC