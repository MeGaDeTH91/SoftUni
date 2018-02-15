SELECT TownId, Name
FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]