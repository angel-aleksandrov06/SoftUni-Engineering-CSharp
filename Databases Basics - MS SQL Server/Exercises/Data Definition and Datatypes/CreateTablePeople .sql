CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) UNIQUE NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2000 * 1024),
	Height NUMERIC(7,2),
	[Weight] NUMERIC(7,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People( [Name], Height, [Weight], Gender, Birthdate)
	VALUES
	('Pesho Peshov', '170.77','60', 'm', '05.19.2020'),
	('Pesho Ivanov', '147.77','50.32', 'm', '05.19.2010'),
	('Petia Peshova', '150.77','45', 'f', '05.19.2000'),
	('Ivan Ivanov', '200.35','80', 'm', '05.19.1995'),
	('Dragan Peshov', '180.77','60.60', 'm', '05.19.2019')