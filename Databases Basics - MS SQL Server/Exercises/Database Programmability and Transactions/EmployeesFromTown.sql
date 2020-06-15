CREATE PROC usp_GetEmployeesFromTown(@TownName varchar(50))
AS
BEGIN
	SELECT FirstName, LastName
		FROM Employees e
		JOIN Addresses a
		ON e.AddressID = A.AddressID
		JOIN Towns t
		ON t.TownID = a.TownID
		WHERE  t.[Name] = @TownName
END
