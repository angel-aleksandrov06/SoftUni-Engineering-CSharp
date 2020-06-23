SELECT PassportId, [Address]
	FROM Passengers p
	LEFT JOIN Luggages l
	ON l.PassengerId = p.Id
	WHERE LuggageTypeId IS NULL
	ORDER BY PassportId ASC, Address ASC