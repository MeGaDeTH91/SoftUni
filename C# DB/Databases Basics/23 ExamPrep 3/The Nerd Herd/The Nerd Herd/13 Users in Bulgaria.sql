SELECT u.Nickname,
       ch.Title,
	   l.Latitude,
	   l.Longitude
FROM Users AS u
JOIN Locations AS l ON l.Id = u.LocationId
JOIN UsersChats AS uch ON uch.UserId = u.Id
JOIN Chats AS ch ON ch.Id = uch.ChatId
WHERE l.Latitude BETWEEN 41.139999 AND 44.12999 AND l.Longitude BETWEEN 22.20999 AND 28.35999
ORDER BY Title