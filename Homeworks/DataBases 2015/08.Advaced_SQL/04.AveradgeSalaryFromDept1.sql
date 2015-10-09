USE TelerikAcademy
GO

SELECT AVG(e.Salary) AS [Average Salary]
FROM [Employees] e
WHERE e.DepartmentID = 1