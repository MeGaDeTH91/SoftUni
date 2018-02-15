
SELECT ContinentName,
       SUM(c.AreaInSqKm) AS CountriesArea,
	   SUM(CAST (c.Population AS BIGINT)) AS CountriesPopulation
FROM Continents AS co
JOIN Countries AS c ON c.ContinentCode = co.ContinentCode
GROUP BY co.ContinentName
ORDER BY CountriesPopulation DESC