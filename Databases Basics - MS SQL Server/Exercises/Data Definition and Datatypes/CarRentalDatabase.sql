CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(5,2) NOT NULL,
	WeeklyRate DECIMAL(5,2) NOT NULL,
	MonthlyRate DECIMAL(5,2) NOT NULL,
	WeekendRate DECIMAL(5,2) NOT NULL,
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber INT NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available BIT
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(150)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(30) NOT NULL,
	[Address] NVARCHAR(150) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes NVARCHAR(150)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT NOT NULL,
	KilometrageStart DECIMAL(15,3) NOT NULL,
	KilometrageEnd DECIMAL(15,3) NOT NULL,
	TotalKilometrage DECIMAL(15,3) NOT NULL,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(15,3),
	TaxRate DECIMAL(15,3),
	OrderStatus NVARCHAR(30),
	Notes NVARCHAR(150)
)

INSERT INTO Categories(
	CategoryName,
	DailyRate,
	WeeklyRate,
	MonthlyRate,
	WeekendRate
)
VALUES
	('Bus',3.0,6.6,5.6,1.4),
	('Van',3.0,6.6,5.6,1.4),
	('Car',3.2,3.6,5.6,3.4)

INSERT INTO Cars(
	PlateNumber,
	Manufacturer,
	Model,
	CarYear,
	CategoryId,
	Doors,
	Picture,
	Condition,
	Available
)
VALUES
	(2342,'Alfa','Gulia',2020,3,4,NULL,NULL,NULL),
	(4455,'Alfa','156',1997,3,4,NULL,NULL,NULL),
	(1423,'Lancia','Kapa',1995,3,4,NULL,NULL,NULL)

INSERT INTO Employees(FirstName, LastName, Title, Notes)
      VALUES 
	        ('Ivan', 'Apostolov', NULL,NULL),
			('Aleksander', 'Ivanov', NULL,NULL),
			('Bash', 'Maistora', NULL,NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZipCode, Notes)
       VALUES 
	        (123, 'Ivan Ivanov', 'Slivnitsa 123', 'Sofia', 1000, NULL),
			(321, 'Ivan Peshov', 'Slivnitsa 123', 'Sofia', 1000, NULL),
			(68444459, 'Ivan Kirilov', 'Slivnitsa 123', 'Sofia', 1000, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart,
                        KilometrageEnd, TotalKilometrage, 
                        StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
       VALUES 
	        (1,2,1,12,19999, 21000, 1001,'2020-05-09','2020-05-21', 12, NULL,NULL,NULL,NULL),
			 (1,2,2,80,20000, 21000, 1000,'2020-05-09','2020-05-21', 12, NULL,NULL,NULL,NULL),
			  (1,2,3,50,12500, 13000, 500,'2020-05-09','2020-05-21', 12, NULL,NULL,NULL,NULL)