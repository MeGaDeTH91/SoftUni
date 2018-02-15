CREATE VIEW v_UserWithCountries
AS
(
	SELECT CONCAT(cs.FirstName, ' ', cs.LastName) AS CustomerName,
	       cs.Age,
		   cs.Gender,
		   c.Name AS [CountryName]
	FROM
	Customers AS cs
	JOIN Countries AS c ON c.Id = cs.CountryId
)