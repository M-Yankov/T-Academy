USE TransactSQL
GO

/*---------    Withdraw  ----------*/

CREATE PROC usp_Withdraw(@id int, @money money)
AS
	DECLARE @personMoney money = (SELECT Balance FROM Accounts
							WHERE PersonID = @id)
	BEGIN TRANSACTION

	IF @personMoney <= @money
	BEGIN
		ROLLBACK
		RAISERROR('Not enough money!', 16, 1);
		RETURN
	END

	UPDATE Accounts
		SET Balance = Balance - @money
		WHERE PersonID = @id
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK
		RAISERROR('Invalid ID', 16, 1);
		RETURN
	END
	COMMIT
GO

/*---------    Deposit  ----------*/

CREATE PROC usp_Deposit(@id int, @money money)
AS
	DECLARE @personMoney money = (SELECT Balance FROM Accounts
							WHERE PersonID = @id)
	BEGIN TRANSACTION

	UPDATE Accounts
		SET Balance = Balance + @money
		WHERE PersonID = @id
	IF @@ROWCOUNT <> 1
	BEGIN
		ROLLBACK
		RAISERROR('Invalid ID', 16, 1);
		RETURN
	END
	COMMIT
GO

/*---------    Expamples Just Change the name of the procedure usp_Deposit/usp_Withdraw  ----------*/

BEGIN 
	DECLARE @id int = 2
	SELECT p.[First Name], + p.[Last Name], + a.Balance AS [Before] 
	FROM [Persons] p
	JOIN [Accounts] a ON p.ID = a.PersonID
	WHERE a.PersonID = @id

	EXEC usp_Deposit @id, 2
	
	SELECT p.[First Name], + p.[Last Name], + a.Balance AS [After] 
	FROM [Persons] p
	JOIN [Accounts] a ON p.ID = a.PersonID
	WHERE a.PersonID = @id
END