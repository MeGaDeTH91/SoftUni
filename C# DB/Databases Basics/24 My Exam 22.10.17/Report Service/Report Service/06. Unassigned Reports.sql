SELECT Description,
       OpenDate
FROM Reports AS r
WHERE r.EmployeeId IS NULL
ORDER BY OpenDate, Description