CREATE TABLE USERS (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT INTO USERS( Username, [Password], LastLoginTime, IsDeleted)
	VALUES
	('Pesho0', '123456', '05.19.2020', 0),
	('Pesho1', '123456', '05.19.2020', 1),
	('Pesho2', '123456', '05.19.2020', 0),
	('Pesho3', '123456', '05.19.2020', 0),
	('Pesho4', '123456', '05.19.2020', 1)