SELECT rt.FirstName, rt.LastName, rt.Grade
	FROM (
			SELECT FirstName, LastName, Grade,
				ROW_NUMBER() OVER (PARTITION BY FirstName, LastName ORDER BY Grade DESC) AS RowNumber
				FROM Students s
				JOIN StudentsSubjects ss
				ON ss.StudentId = s.Id
		) AS [rt]
	WHERE rt.RowNumber = 2
	ORDER BY FirstName, LastName