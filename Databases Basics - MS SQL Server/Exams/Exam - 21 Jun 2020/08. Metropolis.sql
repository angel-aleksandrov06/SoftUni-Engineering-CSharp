SELECT TOP(10) c.Id AS [Id],
		c.[Name] AS [City] ,
		c.CountryCode AS Country,
		COUNT(a.Id) AS [Accounts]
	FROM Accounts a
	JOIN Cities c
	ON a.CityId = c.Id
	GROUP BY c.Id, C.[Name], c.CountryCode
	ORDER BY [Accounts] desc
