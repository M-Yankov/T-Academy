USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, e.Salary, e.DepartmentID
FROM [Employees] e
WHERE e.Salary IN
	(SELECT MIN(emp.Salary) FROM [Employees] emp 
	 WHERE e.DepartmentID =  emp.DepartmentID)
ORDER BY DepartmentID