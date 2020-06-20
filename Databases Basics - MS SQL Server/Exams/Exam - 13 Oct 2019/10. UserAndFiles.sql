SELECT Username, AVG(Size) AS [Size]
	FROM Users u
	JOIN Commits c
	ON c.ContributorId = u.Id
	JOIN Files f
	ON f.CommitId = c.Id
	GROUP BY Username
	ORDER BY Size DESC, Username ASC