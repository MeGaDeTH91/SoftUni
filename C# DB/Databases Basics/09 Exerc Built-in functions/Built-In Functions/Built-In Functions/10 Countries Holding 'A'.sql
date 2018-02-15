SELECT CountryName AS [Country Name], IsoCode
FROM Countries
WHERE len(CountryName) - len(replace(CountryName,'a','')) >= 3
ORDER BY IsoCode
GO --Second Way
SELECT CountryName AS [Country Name], IsoCode  
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode