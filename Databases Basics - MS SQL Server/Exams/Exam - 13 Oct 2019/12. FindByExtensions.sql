CREATE PROC usp_FindByExtension(@extension NVARCHAR(MAX))
AS
BEGIN
	SELECT Id, [Name], CONCAT(Size,'KB') AS [Size]
		FROM Files
		WHERE [Name] LIKE CONCAT('%', @extension)
		ORDER BY Id ASC, [Name] ASC, Size DESC
END 