CREATE TRIGGER tr_deletePlanes ON Planes
AFTER DELETE
AS
BEGIN
	INSERT INTO DeletedPlanes (Id, [Name], Seats, [Range])
	(SELECT Id, [Name], Seats, [Range] FROM deleted)
END