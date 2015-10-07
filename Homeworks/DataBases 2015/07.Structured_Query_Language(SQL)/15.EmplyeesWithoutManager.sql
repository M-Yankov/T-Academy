USE TelerikAcademy
GO

SELECT [FirstName], [LastName], [ManagerID]
FROM [Employees]
WHERE ManagerID IS NULL
