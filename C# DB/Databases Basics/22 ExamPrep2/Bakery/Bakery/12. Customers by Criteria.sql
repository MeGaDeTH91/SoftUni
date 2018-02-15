SELECT FirstName,
       Age,
	   PhoneNumber
FROM Customers
WHERE CountryId <> (SELECT Id FROM Countries AS c WHERE c.Name = 'Greece') AND Age >= 21 AND FirstName LIKE '%an%' OR PhoneNumber LIKE '%38'
ORDER BY FirstName, Age DESC