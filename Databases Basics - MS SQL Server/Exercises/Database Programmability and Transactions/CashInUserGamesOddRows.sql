CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
SELECT SUM(Cash) AS [SumCash]
	FROM (
			SELECT g.[Name], 
				   ug.Cash, 
				   ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [RowNumber]
			  FROM Games g
			  JOIN UsersGames ug
			  ON g.Id = ug.GameId
			  WHERE g.[Name] = @gameName) AS [RowNumQuery]
	WHERE [RowNumber] % 2 <> 0