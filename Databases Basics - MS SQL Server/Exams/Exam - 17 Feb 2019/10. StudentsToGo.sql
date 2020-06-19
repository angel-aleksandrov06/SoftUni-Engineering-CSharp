SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Students s
	LEFT JOIN StudentsExams se
	ON s.Id = se.StudentId
	WHERE se.ExamId is null
	ORDER BY [Full Name] ASC