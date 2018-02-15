SELECT c.CountryCode,
       COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode IN('BG', 'US', 'RU')
GROUP BY c.CountryCode