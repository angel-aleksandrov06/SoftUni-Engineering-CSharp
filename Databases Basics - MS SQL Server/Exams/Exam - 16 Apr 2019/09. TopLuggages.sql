SELECT lt.[Type], COUNT(p.Id) AS [MostUsedLuggage]
	FROM LuggageTypes lt
	JOIN Luggages l
	ON l.LuggageTypeId = lt.Id
	JOIN Passengers p
	ON p.Id = l.PassengerId
	GROUP BY lt.[Type]
	ORDER BY [MostUsedLuggage] DESC, [Type] ASC