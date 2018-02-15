SELECT TOP 5 CountryName,
       MAX(HighestPeakElevation) AS HighestPeakElevation,
	   MAX([LongestRiverLength]) AS LongestRiverLength
FROM
(
SELECT c.CountryName,
       p.Elevation AS HighestPeakElevation,
	   r.[Length] AS LongestRiverLength
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT OUTER JOIN Peaks AS p ON p.MountainId = m.Id
LEFT OUTER JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers AS r ON r.Id = cr.RiverId
) AS [Data]
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName