USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, e.Salary
FROM [Employees] e
WHERE e.Salary > 
	(SELECT MIN(emp.Salary)/10 + MIN(emp.Salary) FROM [Employees] emp)
ORDER BY e.Salary
-- MIN(emp.Salary)/10 is 10% from minimal salary i.e. 900