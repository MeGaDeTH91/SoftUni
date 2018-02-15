SELECT COUNT(*) AS CountryCode
FROM
(
SELECT
mc.MountainId
FROM Countries AS c
FULL OUTER JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL
) AS CountriesWithoutMountain