SELECT SUM(Difference) AS [SumDifference]
	FROM (SELECT 
			FirstName AS [Host Wizard],
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizad],
			LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizad Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
				FROM WizzardDeposits
		 ) AS [LeadQuery]
	WHERE [Guest Wizad] IS NOT NULL