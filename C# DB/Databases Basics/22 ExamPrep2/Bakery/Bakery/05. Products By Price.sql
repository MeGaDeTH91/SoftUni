SELECT p.Name AS [Name],
       p.Price AS [Price],
	   p.Description
FROM Products AS p
ORDER BY Price DESC, Name