SELECT FirtLetter
	FROM (
			SELECT LEFT(FirstName, 1) AS [FirtLetter]
				FROM WizzardDeposits
				WHERE DepositGroup = 'Troll Chest'
		 ) AS [FirtLetterQuery]
	GROUP BY FirtLetter
	ORDER BY FirtLetter ASC