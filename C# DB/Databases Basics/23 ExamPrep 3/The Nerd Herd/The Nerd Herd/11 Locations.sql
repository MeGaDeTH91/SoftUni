SELECT u.Id,
       u.Nickname,
	   u.Age
FROM Users AS u
LEFT OUTER JOIN Locations AS l ON l.Id = u.LocationId
WHERE l.Id IS NULL