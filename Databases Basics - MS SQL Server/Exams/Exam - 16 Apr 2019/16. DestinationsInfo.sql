SELECT Destination, COUNT(FlightId) AS [FliesCount]
	FROM Flights f
	LEFT JOIN Tickets t
	ON t.FlightId = F.Id
	GROUP BY Destination
	ORDER BY [FliesCount] DESC, Destination ASC