USE TelerikAcademy
GO
SELECT [FirstName], [LastName], [JobTitle]
FROM Employees
WHERE JobTitle = 'Sales Representative'
/*WHERE JobTitle LIKE 'Sales Representative'*/