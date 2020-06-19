SELECT 
		FirstName + ' ' + LastName AS [FullName],
		CONCAT(sb.[Name], '-', sb.Lessons) AS Subjects,
		COUNT(st.StudentId) AS Students
	FROM Teachers AS t
	JOIN Subjects AS sb
	ON sb.Id = t.SubjectId
	JOIN StudentsTeachers AS st
	ON st.TeacherId = t.Id
	GROUP BY t.FirstName, t.LastName, sb.Name, sb.Lessons
	ORDER BY COUNT(st.StudentId) DESC, FullName ASC, Subjects ASC