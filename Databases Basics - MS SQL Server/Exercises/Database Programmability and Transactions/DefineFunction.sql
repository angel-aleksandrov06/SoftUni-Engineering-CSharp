CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;

		WHILE(@i <= LEN(@word))
		BEGIN
			DECLARE @currChar CHAR = SUBSTRING(@word, @i, 1);
			DECLARE @charIndex INT = CHARINDEX(@currChar, @setOfLetters);

			IF(@charIndex = 0)
			BEGIN
				RETURN 0;
			END

			SET @i += 1;
		END

		RETURN 1;
END