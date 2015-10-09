USE TelerikAcademy
GO

SELECT 'People in dept. Sales' + CAST(COUNT(*) AS NVARCHAR)
FROM [Employees] e
WHERE e.DepartmentID =
	(SELECT dep.DepartmentID FROM [Departments] dep
	 WHERE dep.Name = 'Sales')