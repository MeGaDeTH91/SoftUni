SELECT * FROM UsersGames

SELECT g.Name AS Game,
       gt.Name AS [Game Type],
	   u.Username AS Username,
	   ug.Level AS Level,
	   ug.Cash AS Cash,
	   ch.Name AS Character
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Characters AS ch ON ch.Id = ug.CharacterId
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
ORDER BY Level DESC, Username, Game