SELECT ch.Id,
       ch.Title,
	   m.Id
FROM Chats AS ch
JOIN Messages AS m ON m.ChatId = ch.Id
WHERE m.SentOn < '03.26.2012' AND Title LIKE '%x'
ORDER BY ch.Id, m.Id