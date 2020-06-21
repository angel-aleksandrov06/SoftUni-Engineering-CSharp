SELECT 
	u.Username,
	g.[Name] AS [Game],
	COUNT(ugi.ItemId) AS [Items Count],
	SUM(I.Price) AS [Items Price]
	FROM [dbo].Games g
	JOIN [dbo].UsersGames ug
	ON ug.GameId = g.Id
	JOIN [dbo].Users u
	ON u.Id = ug.UserId
	JOIN [dbo].UserGameItems ugi
	ON ugi.UserGameId = ug.Id
	JOIN [dbo].Items i
	ON i.Id = ugi.ItemId
	GROUP BY g.[Name], u.Username
	HAVING COUNT(ugi.ItemId) >= 10
	ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC