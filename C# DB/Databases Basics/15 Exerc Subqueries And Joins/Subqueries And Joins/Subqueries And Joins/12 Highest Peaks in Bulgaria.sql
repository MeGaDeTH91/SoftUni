SELECT * FROM Peaks
SELECT * FROM Countries

SELECT cs.CountryCode,
       m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM Countries AS cs
JOIN MountainsCountries AS mc ON mc.CountryCode = cs.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = mc.MountainId
WHERE cs.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC