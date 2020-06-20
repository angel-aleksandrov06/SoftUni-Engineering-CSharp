CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @studentExist INT = (SELECT TOP(1) Id FROM Students WHERE Id = @StudentId);

	IF(@studentExist IS NULL)
		THROW 50000, 'This school has no student with the provided id!', 1;

	DELETE FROM StudentsExams
		WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId

	DELETE FROM Students
		WHERE Id = @StudentId
END