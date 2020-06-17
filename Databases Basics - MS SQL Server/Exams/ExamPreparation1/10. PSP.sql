SELECT  pl.[Name],
		pl.Seats,
		COUNT(t.PassengerId) AS [Passengers Count]
	FROM Planes pl
	LEFT JOIN Flights f
	ON pl.Id = f.PlaneId
	LEFT JOIN Tickets t
	ON f.Id = t.FlightId
	GROUP BY pl.[Name], pl.Seats
	ORDER BY [Passengers Count] DESC, pl.Name, pl.Seats