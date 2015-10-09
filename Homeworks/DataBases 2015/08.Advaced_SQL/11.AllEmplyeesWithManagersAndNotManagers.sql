USE TelerikAcademy
GO
													--ISNULL--
SELECT e.FirstName + ' ' + e.LastName AS [Employee], COALESCE(emp.FirstName + ' ' + emp.LastName, 'No manager') AS [Manager]
FROM [Employees] e
LEFT JOIN [Employees] emp
ON emp.EmployeeID = e.ManagerID

ORDER BY e.ManagerID