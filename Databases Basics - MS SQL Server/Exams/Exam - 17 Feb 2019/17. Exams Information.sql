SELECT [Quarter], SubjectName, COUNT([QuartersQuery].StudentId) AS [StudentsCount]
	FROM (
			SELECT s.[Name] AS SubjectName,
					 se.StudentId,
					 CASE
					 WHEN DATEPART(MONTH, Date) BETWEEN 1 AND 3 THEN 'Q1'
					 WHEN DATEPART(MONTH, Date) BETWEEN 4 AND 6 THEN 'Q2'
					 WHEN DATEPART(MONTH, Date) BETWEEN 7 AND 9 THEN 'Q3'
					 WHEN DATEPART(MONTH, Date) BETWEEN 10 AND 12 THEN 'Q4'
					 WHEN Date IS NULL THEN 'TBA'
					 END AS [Quarter]
				FROM Exams e
				JOIN Subjects s
				ON s.Id = e.SubjectId
				JOIN StudentsExams se
				ON se.ExamId = e.Id
				WHERE se.Grade >= 4.00
		  ) AS [QuartersQuery]
		GROUP BY [Quarter], SubjectName
		ORDER BY [Quarter] ASC