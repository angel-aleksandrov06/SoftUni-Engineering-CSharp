CREATE PROC usp_GetHoldersWithBalanceHigherThan(@minBalance DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName, LastName
		FROM Accounts a
	JOIN AccountHolders ah
	ON a.AccountHolderId = ah.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @minBalance
	ORDER BY FirstName, LastName
END
