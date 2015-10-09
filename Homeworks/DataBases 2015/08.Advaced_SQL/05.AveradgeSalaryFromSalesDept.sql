USE TelerikAcademy
GO

SELECT AVG(e.Salary) AS [Averadge salary from 'Sales']
FROM [Employees] e
WHERE e.DepartmentID =
	(SELECT dep.DepartmentID FROM [Departments] dep
	 WHERE dep.Name = 'Sales')