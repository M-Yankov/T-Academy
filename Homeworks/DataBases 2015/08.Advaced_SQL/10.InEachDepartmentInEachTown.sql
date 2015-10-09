USE TelerikAcademy
GO

SELECT  COUNT(*) AS [People], d.Name AS [Department], t.Name AS [Town]
FROM [Employees] e 
JOIN [Departments] d ON e.DepartmentID = d.DepartmentID
JOIN [Addresses] adr ON e.AddressID = adr.AddressID
JOIN [Towns] t ON adr.TownID = t.TownID
--WHERE e.DepartmentID IN (SELECT emp.DepartmentID FROM [Employees] emp )
	  
GROUP BY d.Name, T.Name
ORDER BY t.Name