USE TelerikAcademy

BEGIN TRAN
ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

DELETE FROM Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments
						WHERE Name = 'Sales')


ROLLBACK TRAN
GO

