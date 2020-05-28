CREATE TABLE Employees(
 Id INT PRIMARY KEY IDENTITY(1, 1), 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 Title NVARCHAR(50) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Customers(
 AccountNumber  INT PRIMARY KEY NOT NULL, 
 FirstName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 PhoneNumber INT NOT NULL, 
 EmergencyName NVARCHAR(50) NOT NULL, 
 EmergencyNumber INT NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RoomStatus(
 RoomStatus VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE RoomTypes(
 RoomType VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE BedTypes(
 BedType VARCHAR(30) PRIMARY KEY NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Rooms(
 RoomNumber INT PRIMARY KEY NOT NULL, 
 RoomType VARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL, 
 BedType VARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL, 
 Rate DECIMAL(5, 2) NOT NULL, 
 RoomStatus VARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL, 
 Notes NVARCHAR(MAX)
 )

 CREATE TABLE Payments(
  Id INT PRIMARY KEY IDENTITY(1, 1), 
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
  PaymentDate DATE NOT NULL, 
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
  FirstDateOccupied DATE NOT NULL, 
  LastDateOccupied DATE NOT NULL, 
  TotalDays INT NOT NULL, 
  AmountCharged DECIMAL(10,2) NOT NULL, 
  TaxRate DECIMAL(10,2) NOT NULL, 
  TaxAmount DECIMAL(10,2) NOT NULL, 
  PaymentTotal DECIMAL(10,2) NOT NULL, 
  Notes NVARCHAR(MAX)
  )

  CREATE TABLE Occupancies(
  Id INT PRIMARY KEY IDENTITY(1, 1), 
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
  DateOccupied DATE NOT NULL, 
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber), 
  RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
  RateApplied DECIMAL(8,2) NOT NULL, 
  PhoneCharge DECIMAL(8,2), 
  Notes NVARCHAR(MAX)
  )

  INSERT INTO Employees (FirstName, LastName, Title, Notes)
	 VALUES
	 ('Ivan', 'Ivanov', 'Boss', null),
	 ('Angel', 'Angelov', 'Slave', null),
	 ('Kiril', 'Blagoev', 'Slave', null)

	 INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
	 VALUES
	 (11, 'Maria', 'Marinova', 12345, 'Toto', 911, null),
	 (22, 'Pesho', 'Ganchev', 12345, 'Toto', 911, null),
	 (33, 'Dimitar', 'Rozev', 12345, 'Toto', 911, null)

	 INSERT INTO RoomStatus(RoomStatus, Notes)
	 VALUES
	  ('C', null),
	  ('O', null),
	  ('CO', null)

	 INSERT INTO RoomTypes (RoomType, Notes)
	 VALUES
	  ('Big', null),
	  ('Medium', null),
	  ('Small', null)

	 INSERT INTO BedTypes (BedType, Notes)
	 VALUES
	 ('Big', null),
	 ('Medium', null),
	 ('Small', null)

	 INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
	 VALUES
	 (1, 'Big', 'Small', 25, 'C', null),
	 (2, 'Small', 'Big', 35, 'O', null),
	 (3, 'Small', 'Small', 5, 'CO', null)

	 INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
	 VALUES
	 (1, '2020-01-23', 11, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null),
	 (2, '2020-01-23', 22, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null),
	 (3, '2020-01-23', 33, '2020-01-23', '2020-01-28', 5, 23, 12, 3, 43, null)

	 INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
	 VALUES
	 (1, '2020-01-23', 11, 1, 23, 43, null),
	 (2, '2020-01-23', 22, 2, 23, 43, null),
	 (3, '2020-01-23', 33, 3, 23, 43, null)