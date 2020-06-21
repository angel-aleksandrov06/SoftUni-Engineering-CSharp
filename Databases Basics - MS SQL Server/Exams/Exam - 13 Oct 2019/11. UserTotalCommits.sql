CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @userdId INT = (SELECT TOP(1) Id FROM Users WHERE Username = @username);

	DECLARE @count INT = (
		SELECT COUNT(*) FROM Commits
WHERE ContributorId = @userdId
	)
	RETURN CAST(@count AS NVARCHAR(30))
END