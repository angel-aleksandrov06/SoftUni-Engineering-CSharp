SELECT MIN([Average Salary]) AS [MinAverageSalary]
	FROM
	(
		SELECT DepartmentID, AVG(Salary) AS [Average Salary]
		FROM Employees
		GROUP BY DepartmentID
	) AS[AverageSalaryQuery]