USE TelerikAcademy
GO

INSERT INTO Users (FullName, UserName, UserPassword)

SELECT	FirstName + ' ' + LastName AS [FullName] , 
		CONVERT(NVARCHAR(1), FirstName) + LOWER(LastName) AS [UserName],
		CONVERT(NVARCHAR(1), FirstName) + LOWER(LastName) AS [UserPassword]
FROM Employees