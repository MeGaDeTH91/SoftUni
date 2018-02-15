SELECT cs.CurrencyCode,
       cs.Description AS Currency,
	   COUNT(c.CountryCode) AS [NumberOfCountries]
FROM Currencies AS cs
LEFT JOIN Countries AS c ON c.CurrencyCode = cs.CurrencyCode
GROUP BY cs.CurrencyCode, cs.Description
ORDER BY NumberOfCountries DESC, Currency