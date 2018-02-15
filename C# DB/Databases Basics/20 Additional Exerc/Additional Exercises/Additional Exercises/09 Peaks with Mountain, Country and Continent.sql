SELECT p.PeakName AS PeakName,
       m.MountainRange AS Mountain,
	   c.CountryName AS CountryName,
	   co.ContinentName AS ContinentName
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
JOIN Countries AS c ON c.CountryCode = mc.CountryCode
JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
ORDER BY PeakName, CountryName