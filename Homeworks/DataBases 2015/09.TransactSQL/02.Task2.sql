USE TransactSQL
GO

CREATE PROCEDURE dbo.usp_FindAllPersonsThatHaveBalanceHigherThan
				 (@balanceMoreThan money)
AS
	SELECT  p.[First Name], p.[Last Name], a.Balance
	FROM [Persons] p
	JOIN [Accounts] a ON p.ID = a.PersonID
	WHERE a.Balance > @balanceMoreThan
GO

EXEC usp_FindAllPersonsThatHaveBalanceHigherThan 1000.2
