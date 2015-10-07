USE TelerikAcademy
GO

SELECT e.FirstName, e.LastName, e.JobTitle, e.HireDate, d.Name
FROM [Employees] e
JOIN [Departments] d
ON e.DepartmentID = d.DepartmentID
WHERE 
(d.Name = 'Sales' OR d.Name = 'Finance')
 AND (e.HireDate BETWEEN '1995-01-01' AND '2005-12-12')