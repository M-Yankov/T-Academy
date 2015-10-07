USE TelerikAcademy
GO

SELECT e.EmployeeID, e.FirstName, e.LastName, m.FirstName + ' ' + m.LastName AS 'Manager', a.AddressText AS 'Employee Adress'
FROM [Employees] e
JOIN [Employees] m
ON e.ManagerID = m.EmployeeID
JOIN [Addresses] a
ON e.AddressID = a.AddressID
/* Who's addres Empoloyee addres or manager adress? 
 >  e.AddressID = a.AddressID  -- Shows Employees adresses
 >  m.AddressID = a.AddressID  -- Show Manager Adress
*/