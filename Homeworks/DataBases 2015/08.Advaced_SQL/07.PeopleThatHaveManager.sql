USE TelerikAcademy
GO

SELECT 'People That have manager ' + CAST(COUNT(*) AS NVARCHAR) AS [Employees]
FROM [Employees] e
WHERE e.ManagerID IN
	(SELECT emp.EmployeeID FROM [Employees] emp)

SELECT em.FirstName, em.LastName, em.ManagerID
FROM [Employees] em
WHERE em.ManagerID IS NOT NULL

SELECT COUNT(e.ManagerID)
FROM [Employees] e