SELECT MIN(av.Average)
FROM 
(
SELECT AVG(Salary) AS Average
FROM Employees
GROUP BY DepartmentID
) AS av