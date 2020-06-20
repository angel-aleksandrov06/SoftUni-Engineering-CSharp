CREATE TABLE ExcludedStudents(
	StudentId INT NOT NULL,
	StudentName NVARCHAR(40) NOT NULL,
)

CREATE TRIGGER tr_ExludedStudents ON Students
INSTEAD OF DELETE
AS
INSERT INTO ExcludedStudents (StudentId, StudentName)
	(SELECT Id, FirstName + ' ' + LastName FROM deleted)