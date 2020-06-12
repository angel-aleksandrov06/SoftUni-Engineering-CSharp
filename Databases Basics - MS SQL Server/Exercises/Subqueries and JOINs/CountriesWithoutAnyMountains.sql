SELECT COUNT(c.CountryCode) AS [Count]
	FROM Countries c
	LEFT JOIN MountainsCountries mc
	on mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL