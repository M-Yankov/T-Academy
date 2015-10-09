USE TelerikAcademy
GO

SELECT TOP 1 COUNT(e.AddressID) AS [Counts], t.Name
FROM [Employees] e
JOIN [Addresses] a ON a.AddressID = e.AddressID
JOIN [Towns] t ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY Counts DESC