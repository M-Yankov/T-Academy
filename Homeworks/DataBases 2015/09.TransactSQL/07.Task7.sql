USE TelerikAcademy
Go

/* @letters are the letters that must be comprised each town */
CREATE FUNCTION ufn_EmployeesInTownComparised(@letters nvarchar(50))
		RETURNS @tbl_employeesFromTowns TABLE
		(SomeName nvarchar(50) NOT NULL,
		Town nvarchar(50) NOT NULL )
AS 
BEGIN
	INSERT @tbl_employeesFromTowns 
	SELECT e.FirstName, t.Name
	
	FROM [Towns] t
	JOIN [Addresses] a ON a.TownID = t.TownID
	JOIN [Employees] e ON e.AddressID = a.AddressID
	WHERE t.Name IN
					(SELECT Name 
					FROM Towns 
					WHERE dbo.ufn_TownsContainsInLetters(@letters, Name) = 1)

	RETURN
END


/* --------- Additional helper function to make the magic ---------*/
CREATE FUNCTION ufn_TownsContainsInLetters(@letters nvarchar(50), @town nvarchar(50))
		RETURNS bit
AS 
BEGIN
	SET @letters = LOWER(@letters)
	SET @town = LOWER(@town)
	DECLARE @index int = 1
	DECLARE @char nvarchar(1)
	DECLARE @lengthOfTown int = LEN(@town)
	WHILE @lengthOfTown >= @index
	BEGIN
		SET @char = SUBSTRING(@town, @index, 1)
		IF CHARINDEX(@char, @letters, 1) = 0
		BEGIN
			RETURN 0
		END
		SET @index = @index + 1;
	END 
	RETURN 1
END

/* ------ And here is the demo result -------*/
SELECT * FROM dbo.ufn_EmployeesInTownComparised('sofiaredmond')

