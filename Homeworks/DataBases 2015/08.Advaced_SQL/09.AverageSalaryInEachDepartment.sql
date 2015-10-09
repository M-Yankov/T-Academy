USE TelerikAcademy
GO

SELECT  AVG(e.Salary) AS [Average Salary], d.Name
FROM [Employees] e JOIN [Departments] d
ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID IN
	(SELECT emp.DepartmentID FROM [Employees] emp )
GROUP BY d.Name
