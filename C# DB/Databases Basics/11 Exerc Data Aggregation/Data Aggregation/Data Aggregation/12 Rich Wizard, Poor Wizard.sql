SELECT SUM([Difference]) AS [SumDifference]
FROM
(
SELECT DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
FROM WizzardDeposits
) AS Diffs