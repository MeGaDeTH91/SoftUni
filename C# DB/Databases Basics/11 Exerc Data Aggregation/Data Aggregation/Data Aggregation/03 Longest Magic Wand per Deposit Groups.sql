SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup
GO
SELECT * FROM WizzardDeposits