SELECT 
	g.[Name] AS [Game],
	gt.[Name] AS [Game Type],
	u.Username AS [Username], 
	ug.[Level] AS [Level],
	ug.Cash AS [Cash],
	c.[Name] AS [Character]
		FROM Games g
		JOIN UsersGames ug
		ON ug.GameId = g.Id
		JOIN Users u
		ON u.Id = ug.UserId
		JOIN GameTypes gt
		ON gt.Id = g.GameTypeId
		JOIN Characters c
		ON c.Id = ug.CharacterId
		ORDER BY [Level] DESC, [Username] ASC, [Game] ASC