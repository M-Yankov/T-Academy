USE TelerikAcademy
GO

SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)
