USE TelerikAcademy
GO

SELECT 'Boss ' + CAST(COUNT(*) AS NVARCHAR) AS [Master Chefs]
FROM [Employees] e
WHERE e.ManagerID IS NULL
