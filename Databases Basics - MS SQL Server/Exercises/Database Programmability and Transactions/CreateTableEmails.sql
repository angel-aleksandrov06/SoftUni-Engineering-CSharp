CREATE TABLE NotificationEmails (
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts (Id),
	[Subject] VARCHAR(50),
	Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS

DECLARE @accountId VARCHAR(30) = CAST((SELECT TOP(1) AccountId FROM inserted) AS VARCHAR(30))
DECLARE @oldSum VARCHAR(30) = CAST((SELECT TOP(1) OldSum FROM inserted) AS VARCHAR(30))
DECLARE @newSum VARCHAR(30) = CAST((SELECT TOP(1) NewSum FROM inserted) AS VARCHAR(30))

INSERT INTO NotificationEmails (Recipient, [Subject], Body)
VALUES
(
@accountId,
'Balance change for account: ' + @accountId,
'On ' + CONVERT(VARCHAR(30),GETDATE(),103) + ' your balance was changed from ' + @oldSum + ' to ' + @newSum
)
