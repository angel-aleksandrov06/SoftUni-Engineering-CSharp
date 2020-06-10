SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS [DepartmentName]
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'sales'
	ORDER BY e.EmployeeID ASC