CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	
	-- DELETE ALL RECORD FROM EMPLOYEESPROJECTS WHERE EMPLOYEEID IS IN TE-BE-DELETED ID`S
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
						)
	
	-- SET MANAGER TO NULL WHERE MANAGER IS EMPLOYEE WHO IS GOING TO BE DELETED (FOR EMPLOYEES)

	UPDATE Employees
		SET ManagerID = NULL
		WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
						)

	-- ALTER COLUMN MANAGERID IN DEPARTMENTS TABLE AND MAKE IT NULL
	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT

	-- SET MANAGERID TO NULL WHERE MANAGER IS AN EMPLOYEE WHO IS GOING TO BE DELETED (FOR DEPARTMENTS)

	UPDATE Departments
		SET ManagerID = NULL
		WHERE ManagerID IN (
						SELECT EmployeeID FROM Employees
						WHERE DepartmentID = @departmentId
						)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) 
		FROM Employees
		WHERE DepartmentID = @departmentId
END