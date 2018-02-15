DECLARE @cashToTake DECIMAL(15, 2) = 
(SELECT SUM(Price) 
FROM Items
WHERE [Name] IN('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))

DECLARE @heroId INT = (SELECT Id FROM Users WHERE Username = 'Alex')
DECLARE @gameId INT = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
DECLARE @userGameID INT = (SELECT Id FROM UsersGames WHERE UserId = @heroId AND GameId = @gameId)
BEGIN TRANSACTION
   UPDATE UsersGames
   SET Cash -= @cashToTake
   WHERE UserId = @heroId AND GameId = @gameId

   DECLARE @remaininCash DECIMAL(15, 2) = (SELECT Cash 
   FROM UsersGames
   WHERE UserId = @heroId AND GameId = @gameId)
   IF(@remaininCash < 0)
      BEGIN
	     ROLLBACK
		 RETURN
	  END

	  INSERT INTO UserGameItems VALUES (51, @userGameID),
	  (71, @userGameID), (157, @userGameID),
	  (184, @userGameID), (197, @userGameID), (223, @userGameID)
COMMIT


SELECT u.Username AS [Username],
       g.Name AS [Name],
	   ug.Cash AS [Cash],
	   i.Name AS [Item Name]
FROM UsersGames AS ug
JOIN Users AS u ON u.Id = ug.UserId
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugt ON ugt.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugt.ItemId
WHERE g.Name = 'Edinburgh'