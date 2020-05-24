CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(40) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(40) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(40) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(60) NOT NULL,
	DirectorId INT 
	FOREIGN KEY REFERENCES Directors(Id)
	NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating decimal(3,1),
	Notes NVARCHAR(MAX)
	)

INSERT INTO Directors(DirectorName,Notes)
    VALUES
	    ('Pesho', NULL),
		('Tosho', Null),
		('Angel', NULL),
		('Ivo',Null),
		('Maistora', NULL)

INSERT INTO Genres(GenreName,Notes)
    VALUES 
	    ('POP', NULL),
		('HOUSE',NULL),
		('TECHNO', NULL),
		('HIP-HOP', NULL),
		('DANCE', NULL)


INSERT INTO Categories(CategoryName,Notes)
	VALUES 
		('Comedy', NULL),
		('Documentary',NULL),
		('War', NULL),
		('Animations', NULL),
		('Fantasy', NULL)

INSERT INTO Movies(Title, DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
	VALUES 
		('Title1',1,'2019-05-20','02:22:11',2,4,'3.9',NULL),
		('Title1',5,'2020-05-22','02:40:08',5,3,'5.0',NULL),
		('Title1',3,'2020-05-20','02:33:00',2,3,'3.9',NULL),
		('Title1',2,'2010-06-20','03:33:08',1,3,'2.0',NULL),
		('Title1',4,'2014-10-11','02:55:10',2,3,'1.4',NULL)