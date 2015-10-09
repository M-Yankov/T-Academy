USE TelerikAcademy
GO

SELECT	MIN(e.Salary),
		d.Name AS [Department],
		e.JobTitle,  
		MIN(e.FirstName + ' ' + e.LastName) AS [Employee]
FROM [Employees] e
JOIN [Departments] d ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name