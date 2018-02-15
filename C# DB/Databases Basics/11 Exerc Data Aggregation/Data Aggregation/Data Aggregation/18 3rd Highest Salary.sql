SELECT DepartmentID,
       Salary
FROM
(
	SELECT DepartmentId, 
	       Salary,
	       DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
	FROM Employees
	GROUP BY DepartmentID,
	         Salary
) AS thirdHighestSalary
WHERE Rank = 3