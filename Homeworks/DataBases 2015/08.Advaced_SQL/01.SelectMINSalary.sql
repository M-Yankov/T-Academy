USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, e.Salary
FROM [Employees] e
WHERE e.Salary = 
	(SELECT MIN(emp.Salary) FROM [Employees] emp)