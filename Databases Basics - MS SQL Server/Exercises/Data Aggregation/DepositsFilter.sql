SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

-------------------------------

SELECT *
	FROM (
		SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
			FROM WizzardDeposits
			WHERE MagicWandCreator = 'Ollivander family'
			GROUP BY DepositGroup
	) AS [TotalSumQuery]
	WHERE TotalSum < 150000
	ORDER BY TotalSum DESC