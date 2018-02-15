SELECT * FROM Users

SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider],
       COUNT(RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))) AS [Number Of Users]
FROM Users
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
ORDER BY [Number Of Users] DESC, [Email Provider]
