CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL (18,4), @yir FLOAT, @yearsCount INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @furtureValue DECIMAL(18,4);

	SET @furtureValue = @sum * (POWER((1 + @yir), @yearsCount));

	RETURN @furtureValue
END