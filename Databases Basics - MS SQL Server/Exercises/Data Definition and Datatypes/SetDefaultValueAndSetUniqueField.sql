ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO USERS(Username,[Password],IsDeleted)
	VALUES
	('PeshoNoTime', '1234566', 0)

ALTER TABLE Users
DROP CONSTRAINT	PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT	PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength
CHECK(LEN(Username) >= 3)