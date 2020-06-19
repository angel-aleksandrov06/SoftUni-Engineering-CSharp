UPDATE StudentsSubjects
	SET Grade = 6.00
	WHERE Id IN (
					SELECT Id
					FROM StudentsSubjects
					WHERE Grade >= 5.50 AND SubjectId IN (1, 2)
				)