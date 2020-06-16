CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT, @yir FLOAT)
AS
BEGIN
	SELECT  a.Id AS [Account Id],
			ah.FirstName AS [First Name],
			ah.LastName AS [Last Name],
			a.Balance AS [Current Balance],
			dbo.ufn_CalculateFutureValue (a.Balance, @yir, 5) AS [Balance in 5 years]
		FROM AccountHolders ah
		JOIN Accounts a 
		ON a.Id = ah.Id
		WHERE a.Id = @AccountId
END