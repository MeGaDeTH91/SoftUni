SELECT TOP 1 WITH TIES ch.Title,
             m.Content
FROM Chats AS ch
LEFT OUTER JOIN Messages AS m ON m.ChatId = ch.Id
ORDER BY ch.StartDate DESC