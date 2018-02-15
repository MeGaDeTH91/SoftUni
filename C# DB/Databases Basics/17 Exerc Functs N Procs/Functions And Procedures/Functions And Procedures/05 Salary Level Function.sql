CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
RETURNS VARCHAR(10)
AS 
BEGIN
DECLARE @level VARCHAR(10)
IF @salary < 30000 
BEGIN
  SET @level = 'Low'
END
ELSE IF @salary BETWEEN 30000 AND 50000
BEGIN
  SET @level = 'Average'
END
ELSE IF @salary > 50000 
BEGIN
  SET @level = 'High'
END
RETURN @level
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees