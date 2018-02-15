SELECT TOP 5 c.CountryName,
             r.RiverName
FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT OUTER JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE ContinentCode = 'AF'
ORDER BY c.CountryName