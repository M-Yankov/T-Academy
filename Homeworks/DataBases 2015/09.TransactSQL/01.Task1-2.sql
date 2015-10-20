USE TransactSQL
GO

CREATE PROC dbo.usp_SelectFullNamesFromPersons
AS 
	SELECT p.[First Name] + ' ' + p.[Last Name] AS [FullName]
	FROM [Persons] p
GO


/* After stored procedure is created. Executed like below */

EXEC usp_SelectFullNamesFromPersons
