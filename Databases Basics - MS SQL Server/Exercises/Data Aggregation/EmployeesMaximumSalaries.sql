SELECT *
	FROM (
			SELECT DepartmentID, MAX(Salary) AS [MaxSalary]
				FROM Employees
				GROUP BY DepartmentID
		 ) AS [GroupingQuery]
	WHERE [MaxSalary] NOT BETWEEN 30000 AND 70000