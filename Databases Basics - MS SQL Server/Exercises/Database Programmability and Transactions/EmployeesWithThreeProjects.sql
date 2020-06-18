CREATE PROCEDURE usp_AssignProject(@employeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	INSERT INTO EmployeesProjects
	VALUES (@employeeId, @projectID)

	IF (SELECT COUNT(ProjectID)
		FROM EmployeesProjects
		WHERE EmployeeID = @employeeId) > 3
	BEGIN
		ROLLBACK;
		THROW 50001, 'The employee has too many projects!', 1
		RETURN
	END
COMMIT