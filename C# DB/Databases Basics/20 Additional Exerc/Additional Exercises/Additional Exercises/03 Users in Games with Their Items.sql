SELECT * FROM Items
SELECT * FROM UserGameItems
SELECT * FROM UsersGames

SELECT u.Username,
       g.Name AS Game,
	   COUNT(ugt.ItemId) AS [Items Count],
	   SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN UserGameItems AS ugt ON ugt.UserGameId = ug.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN Items AS i ON i.Id = ugt.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(ugt.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username