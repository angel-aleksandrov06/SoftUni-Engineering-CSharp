SELECT TOP(10) FirstName, LastName, FORMAT(AVG(Grade),'N2') AS [Grade]
	FROM Students s
	JOIN StudentsExams se
	ON se.StudentId = s.Id
	GROUP BY FirstName, LastName
	ORDER BY Grade DESC, FirstName, LastName