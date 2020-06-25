SELECT a.Id, Email, c.[Name], COUNT(ac.AccountId) as [Trips]
	FROM Accounts a
	JOIN AccountsTrips ac
	ON ac.AccountId = a.Id
	JOIN Trips t
	ON t.Id = ac.TripId
	JOIN Rooms r
	ON r.Id = t.RoomId
	JOIN Hotels h
	ON h.Id = r.HotelId
	JOIN Cities c
	ON c.Id = h.CityId
	WHERE a.CityId = h.CityId
	GROUP BY a.Id, Email, c.[Name]
	ORDER BY [Trips] DESC, a.Id