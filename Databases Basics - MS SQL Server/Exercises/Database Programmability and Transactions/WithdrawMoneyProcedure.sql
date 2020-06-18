CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId);
	DECLARE @accountBalace DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id = @accountId);

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

	IF (@accountBalace - @moneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 52000, 'Insufficient funds!', 1; 
		RETURN
	END

	UPDATE Accounts
		SET Balance -= @moneyAmount
		WHERE Id = @accountId

COMMIT
