SELECT t.FlightId, SUM(t.Price) AS [Price]
	FROM Flights f
	JOIN Tickets t
	ON f.Id = t.FlightId
	GROUP BY T.FlightId
	ORDER BY Price DESC, t.FlightId