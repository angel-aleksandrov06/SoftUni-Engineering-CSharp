SELECT t.Id,
		CONCAT(FirstName, ' ', (MiddleName + ' '), LastName) AS [Full Name],
		ca.[Name] AS [From],
		ch.[Name] AS [To],
		CAST(CASE 
			WHEN CancelDate IS NOT NULL THEN  'Canceled'
			ELSE CAST((DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS NVARCHAR(MAX)) + ' days'
		END AS NVARCHAR(MAX))
		AS [Duration]
	FROM Trips t
	JOIN AccountsTrips act
	ON act.TripId = t.Id
	JOIN Accounts a
	ON a.Id = act.AccountId
	JOIN Cities ca
	ON ca.Id = a.CityId
	JOIN Rooms r
	ON r.Id = t.RoomId
	JOIN Hotels h
	ON h.Id = r.HotelId
	JOIN Cities ch
	ON ch.Id = h.CityId
	ORDER BY [Full Name], t.Id