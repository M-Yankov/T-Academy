USE TelerikAcademy
GO

SELECT COUNT(DISTINCT m.EmployeeID) AS [Managers in town], t.Name
FROM [Employees] e
JOIN [Employees] m ON e.ManagerID = m.EmployeeID
JOIN [Addresses] a ON m.AddressID = a.AddressID
JOIN [Towns] t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Managers in town] DESC


/* in seattle only
SELECT COUNT(DISTINCT m.EmployeeID) AS [Managers in Seattle]
FROM [Employees] e
JOIN [Employees] m ON m.EmployeeID = e.ManagerID
WHERE m.AddressID IN 
					(SELECT a.AddressID
					FROM [Addresses] a
					WHERE a.TownID =(SELECT t.TownID
									FROM [Towns] t
									WHERE t.Name = 'Seattle'))
									*/