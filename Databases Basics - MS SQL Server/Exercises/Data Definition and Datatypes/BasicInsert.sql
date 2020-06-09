INSERT INTO Towns ([Name])
	VALUES
		('Sofia'), 
		('Plovdiv'), 
		('Varna'), 
		('Burgas')

INSERT INTO Departments([Name])
	VALUES
		('Software Development'), 
		('Marketing'), 
		('Sales'), 
		('Engineering'), 
		('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
		('Stoqn', 'Petrov', 'Georgiev', 'CEO', 2, '2007-12-09', 3000.00),
		('Angel', 'Kanov', 'Venelinov', 'Intern', 3, '2016-08-28', 599.88)