USE TelerikAcademy
GO

SELECT e.ManagerID, emp.FirstName, emp.LastName, COUNT(e.EmployeeID) AS [Employees]
FROM [Employees] e
JOIN [Employees] emp
ON emp.EmployeeID = e.ManagerID

GROUP BY e.ManagerID, emp.FirstName, emp.LastName
	HAVING COUNT(e.ManagerID) = 5 
ORDER BY e.ManagerID