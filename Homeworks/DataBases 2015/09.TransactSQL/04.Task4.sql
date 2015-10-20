USE TransactSQL
GO

CREATE PROC usp_GivePersonInterasteRate
			(@AccountID int ,@interestRate money)
AS
	 DECLARE @money int = (SELECT Balance FROM Accounts
					WHERE PersonID = @AccountID)

	UPDATE Accounts
	 SET Balance= dbo.ufn_CalculateSumAfterMonths(@money, @interestRate, 1)
	 WHERE PersonID = @AccountID
GO


BEGIN
	DECLARE @id int = 3
	SELECT p.[First Name] + ' ' + p.[Last Name], a.Balance AS [Before]
	FROM [Persons] p 
	JOIN [Accounts] a ON p.ID = a.PersonID
	WHERE PersonID = @id

	EXEC usp_GivePersonInterasteRate @id, 8.2

	SELECT p.[First Name] + ' ' + p.[Last Name], a.Balance AS [After]
	FROM [Persons] p 
	JOIN [Accounts] a ON p.ID = a.PersonID
	WHERE PersonID = @id
END
