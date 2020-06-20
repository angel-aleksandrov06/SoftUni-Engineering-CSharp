SELECT su.[Name], AVG(ss.Grade) AS [AverageGrade]
	FROM Subjects su
	JOIN StudentsSubjects ss
	ON ss.SubjectId = su.Id
	GROUP BY su.[Name], su.Id
	ORDER BY su.Id