SELECT Id,
 FullName,
 MAX([TripDays]) AS [LongestTrip],
 MIN([TripDays]) as [ShortestTrip]
	FROM (
		SELECT a.Id,
				(a.FirstName + LastName) AS [FullName],
				DATEDIFF(DAY,T.ArrivalDate, T.ReturnDate) AS [TripDays]
			FROM Trips t
			 RIGHT JOIN AccountsTrips act
			ON act.TripId = t.Id
			 JOIN Accounts a
			ON a.Id = act.AccountId
			WHERE a.MiddleName IS  NULL AND t.CancelDate IS NULL
	) as [k]
	GROUP BY Id, FullName
	ORDER BY LongestTrip DESC, ShortestTrip ASC