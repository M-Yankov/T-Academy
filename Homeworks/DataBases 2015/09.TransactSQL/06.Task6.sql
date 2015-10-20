USE TransactSQL
GO

CREATE TRIGGER tr_Logs ON Accounts FOR UPDATE
AS
	--CREATE TABLE #UpdatedBalances ( OldBalance money, newBalance money,  )
	(SELECT d.Balance AS [Old Balance], i.Balance AS [New Balance], d.ID AS [Accaunt ID]
	 INTO #UpdatedBalances
	 FROM [deleted] d, [inserted] i)

	INSERT INTO Logs(AccountID, OldBalance, NewBalance) 
		SELECT ub.[Accaunt ID], ub.[Old Balance], ub.[New Balance] 
		FROM [#UpdatedBalances] ub
GO

-- Examples
EXEC usp_Deposit 2, 21
EXEC usp_Deposit 5, 222 
GO