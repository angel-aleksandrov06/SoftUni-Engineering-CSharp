SELECT  FirstName,
		LastName,
		Destination,
		Price
	FROM (SELECT FirstName, LastName, Destination, Price,
				ROW_NUMBER() OVER (PARTITION BY FirstName ORDER BY PRICE DESC) AS [rowColumn]

				FROM Passengers	p
				JOIN Tickets t
				ON t.PassengerId = p.Id
				JOIN Flights f
				ON f.Id = t.FlightId
			) AS k
		WHERE rowColumn = 1
		ORDER BY Price DESC, FirstName ASC, LastName ASC, Destination ASC