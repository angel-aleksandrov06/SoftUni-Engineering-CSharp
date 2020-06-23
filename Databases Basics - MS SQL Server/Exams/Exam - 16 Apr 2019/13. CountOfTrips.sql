SELECT FirstName, LastName, COUNT(FlightId) AS [Total Trips]
	FROM Passengers p
	LEFT JOIN Tickets t
	ON t.PassengerId = p.Id
	GROUP BY FirstName, LastName
	ORDER BY [Total Trips] DESC, FirstName ASC, LastName ASC