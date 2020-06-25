CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(200)
AS
BEGIN
    DECLARE @hotelBaseRate DECIMAL(18,2)
    SET @hotelBaseRate = (SELECT Hotels.BaseRate FROM Hotels WHERE Hotels.Id = @HotelId)
 
    DECLARE @roomId INT
    SET @roomId = (SELECT TOP(1) tempDB.roomId
                    FROM(
                    SELECT Rooms.Id AS roomId, Price, [Type], Beds, ArrivalDate, ReturnDate, CancelDate
                    FROM Rooms
                    JOIN Hotels ON Hotels.Id = Rooms.HotelId
                    JOIN Trips ON Trips.RoomId = Rooms.Id
                    WHERE Hotels.Id = @HotelId AND Rooms.Beds >= @People ) as tempDB
                    WHERE NOT EXISTS (SELECT tempDBTwo.roomId
                                FROM(
                                SELECT RoomsTwo.Id AS roomId, Price, [Type], Beds, ArrivalDate, ReturnDate, CancelDate
                                FROM Rooms as RoomsTwo
                                JOIN Hotels AS HotelsTwo ON HotelsTwo.Id = RoomsTwo.HotelId
                                JOIN Trips AS TripsTwo ON TripsTwo.RoomId = RoomsTwo.Id
                                WHERE HotelsTwo.Id = @HotelId AND RoomsTwo.Beds >= @People ) as tempDBTwo
                                WHERE (CancelDate IS NULL AND @Date > ArrivalDate AND @Date < ReturnDate))
                    ORDER BY tempDB.Price DESC)
 
    IF(@roomId IS NULL) RETURN 'No rooms available'
 
    DECLARE @highestPrice DECIMAL(18,2)
    SET @highestPrice = (SELECT Rooms.Price FROM Rooms WHERE Rooms.Id = @roomId)
 
    DECLARE @roomType NVARCHAR(200);
    SET @roomType = (SELECT Rooms.[Type] FROM Rooms WHERE Rooms.Id = @roomId);
 
    DECLARE @roomBeds INT
    SET @roomBeds = (SELECT Rooms.Beds FROM Rooms WHERE Rooms.Id = @roomId)
 
    DECLARE @totalPrice DECIMAL(18,2)  
    SET @totalPrice = (@hotelBaseRate + @highestPrice) * @People
    RETURN FORMATMESSAGE('Room %i: %s (%i beds) - $%s', @roomId, @roomType, @roomBeds, CONVERT(NVARCHAR(100),@totalPrice))
END