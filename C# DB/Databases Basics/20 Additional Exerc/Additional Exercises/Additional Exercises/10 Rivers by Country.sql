SELECT c.CountryName AS [CountryName],
       con.ContinentName AS [ContinentName],
	   COUNT(r.Id) AS RiversCount,
	   ISNULL(SUM(r.Length), 0) AS [TotalLength]
FROM Countries AS c
LEFT JOIN Continents AS con ON con.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY CountryName, ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, CountryName