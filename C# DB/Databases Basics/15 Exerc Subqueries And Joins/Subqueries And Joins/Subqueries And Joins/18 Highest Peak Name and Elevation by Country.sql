WITH CTE_MountainsNPeaks(Country, PeakName, Elevation, MountainRange)
AS
(
SELECT c.CountryName AS Country,
       PeakName = 
	   CASE
       WHEN p.PeakName IS NULL THEN '(no highest peak)'
       ELSE p.PeakName
	   END,
	   Elevation = 
	   CASE
       WHEN p.Elevation IS NULL THEN 0
       ELSE p.Elevation
       END,
	   MountainRange = 
	   CASE
	   WHEN m.MountainRange IS NULL THEN '(no mountain)'
	   ELSE m.MountainRange
	   END
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT OUTER JOIN Peaks AS p ON p.MountainId = mc.MountainId
LEFT OUTER JOIN Mountains AS m ON m.Id = mc.MountainId
), CTE_TopPeak(Country, Elevation)
AS
(
SELECT TOP 5 Country, MAX(c.Elevation)
FROM CTE_MountainsNPeaks AS c
GROUP BY Country
)

SELECT mnp.Country,
       mnp.PeakName,
	   mnp.Elevation,
	   mnp.MountainRange
FROM 
CTE_TopPeak AS ctp
LEFT JOIN CTE_MountainsNPeaks AS mnp ON mnp.Country = ctp.Country AND mnp.Elevation = ctp.Elevation
ORDER BY Country, PeakName