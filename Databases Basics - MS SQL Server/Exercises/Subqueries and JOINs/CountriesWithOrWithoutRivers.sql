SELECT TOP(5) CountryName, RiverName
	FROM Countries c
	LEFT JOIN CountriesRivers cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r
	ON r.Id = cr.RiverId
	LEFT JOIN Continents con
	ON c.ContinentCode = con.ContinentCode
	WHERE con.ContinentName = 'Africa'
	ORDER BY C.CountryName ASC