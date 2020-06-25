CREATE PROCEDURE usp_SwitchRoom (@TripId INT, @TargetRoomId INT)
AS
BEGIN
    IF( (SELECT TOP(1) h.Id FROM Trips t
        JOIN Rooms r ON r.Id = t.RoomId
        JOIN HOTELS h ON h.Id = r.HotelId
        WHERE t.Id = @TripId) !=
        (SELECT HotelId FROM Rooms WHERE @TargetRoomId = Id))
			
				THROW 50000,'Target room is in another hotel!', 1;
				
 
    IF( (SELECT Beds FROM Rooms WHERE @TargetRoomId = Id) <
        (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId))
				THROW 50001,'Not enough beds in target room!', 1;
 
	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
END