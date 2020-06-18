CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId);

	IF (@account IS NULL)
	BEGIN
		ROLLBACK;
		THROW 51000, 'Invalid account id!', 1; 
		RETURN
	END
	
	IF (@moneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 52000, 'Negative amount', 1; 
		RETURN
	END

	UPDATE Accounts
		SET Balance += @moneyAmount
		WHERE Id = @accountId

COMMIT

SELECT *
	FROM Accounts
	WHERE Id = 1

EXEC usp_DepositMoney 1, 247.78