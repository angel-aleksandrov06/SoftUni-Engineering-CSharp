SELECT TOP(5)
	CountryName,
	MAX(p.Elevation) AS [Highest Peak Elevation],
	MAX(r.[Length]) AS [Longest River Length]
	FROM Countries c
	LEFT JOIN CountriesRivers cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r
	ON r.Id = cr.RiverId
	LEFT JOIN MountainsCountries mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m
	ON m.Id = MC.MountainId
	LEFT JOIN Peaks p
	ON p.MountainId = m.Id
	GROUP BY c.CountryName
	ORDER BY [Highest Peak Elevation] DESC, [Longest River Length] DESC, CountryName ASC