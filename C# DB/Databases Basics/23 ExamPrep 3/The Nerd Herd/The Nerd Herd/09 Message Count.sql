SELECT TOP 5 WITH TIES ch.Id,
       COUNT(m.Id) AS [TotalMessages]
FROM Messages AS m
LEFT OUTER JOIN Chats AS ch ON m.ChatId = ch.Id
WHERE m.Id < 90
GROUP BY ch.Id
ORDER BY TotalMessages DESC, ch.Id