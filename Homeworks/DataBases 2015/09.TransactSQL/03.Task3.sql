USE TransactSQL
GO

--ALTER PROCEDURE dbo.usp_CalculateSumAfterMonths
--				(@sum money, @interestRate money, @months int)
--AS
--	SELECT (((@interestRate / 12)* 10) * @months) + @sum AS [Your money]

--GO

--EXEC usp_CalculateSumAfterMonths 1000, 3.5, 12

---- There also a better solution to calculate to days, but it also works.

CREATE FUNCTION ufn_CalculateSumAfterMonths
				(@sum money, @interestRate money, @months int)
		RETURNS money
AS
	BEGIN
	RETURN (((@interestRate / 12)* 10) * @months) + @sum
	END
GO

SELECT dbo.ufn_CalculateSumAfterMonths(1000, 3.5, 12) AS [Money] 