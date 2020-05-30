SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name] FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

--SELECT CONCAT(FirstName, ' ', (MiddleName + ' '), LastName) AS [Full Name] FROM Employees
--WHERE Salary IN (25000, 14000, 12500, 23600) --'MiddleName' is NULL second space gone!