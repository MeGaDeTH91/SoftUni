SELECT p.PeakName AS [PeakName],
       m.MountainRange AS [Mountain],
	   p.Elevation AS Elevation
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
ORDER BY Elevation DESC, PeakName