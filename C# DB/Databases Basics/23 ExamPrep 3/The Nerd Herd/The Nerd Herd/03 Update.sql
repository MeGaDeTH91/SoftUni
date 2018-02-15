UPDATE Chats
SET StartDate = m.SentOn
FROM Chats AS ch
JOIN Messages AS m ON m.ChatId = ch.Id
WHERE m.SentOn < ch.StartDate