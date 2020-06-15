SELECT TOP(10)  FirstName,
		LastName,
		DepartmentID
	FROM Employees AS e1
	WHERE e1.Salary > (
						SELECT AVG(Salary) AS [AverageSalary]
						FROM Employees AS eAvgSalary
						WHERE eAvgSalary.DepartmentID = e1.DepartmentID
						GROUP BY DepartmentID
					  )
ORDER BY DepartmentID ASC
