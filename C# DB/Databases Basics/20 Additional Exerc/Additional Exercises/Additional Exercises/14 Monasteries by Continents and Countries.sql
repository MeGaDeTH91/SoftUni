UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries VALUES
('Hanga Abbey', 
(
SELECT CountryCode 
FROM Countries
WHERE CountryName = 'Tanzania'))

INSERT INTO Monasteries VALUES
('Myin-Tin-Daik', 
(
SELECT CountryCode 
FROM Countries
WHERE CountryName = 'Myanmar'))

SELECT c.ContinentName AS [ContinentName],
       ctr.CountryName AS [CountryName],
	   COUNT(m.Id) AS [MonasteriesCount]
FROM Continents AS c
JOIN Countries AS ctr ON ctr.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode = ctr.CountryCode
WHERE ctr.IsDeleted = 0
GROUP BY ContinentName, CountryName
ORDER BY MonasteriesCount DESC, CountryName

SELECT *
FROM Monasteries, Countries