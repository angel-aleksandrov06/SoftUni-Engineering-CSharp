SELECT  FirstName AS [First Name],
		LastName AS [Last Name],
		Age
	FROM Passengers p
	LEFT JOIN Tickets t
	ON p.Id = t.PassengerId
	WHERE t.Id IS NULL
	ORDER BY p.Age DESC, FirstName, LastName