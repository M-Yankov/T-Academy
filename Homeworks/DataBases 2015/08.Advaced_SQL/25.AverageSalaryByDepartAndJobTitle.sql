USE TelerikAcademy
GO

SELECT AVG(e.Salary), e.JobTitle, d.Name AS [Department Name]
FROM [Employees] e
JOIN [Departments] d ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name