USE TelerikAcademy
GO

SELECT ISNULL(e.LastName,'No manager') AS EmployeeLastName, m.EmployeeID AS ManagerID, m.LastName ManagerLastName
FROM Employees e RIGHT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID

/* Left outer join */
SELECT ISNULL(e.LastName,'No manager') AS EmployeeLastName, m.EmployeeID AS ManagerID, m.LastName ManagerLastName
FROM Employees m LEFT OUTER JOIN Employees e
  ON e.ManagerID = m.EmployeeID
