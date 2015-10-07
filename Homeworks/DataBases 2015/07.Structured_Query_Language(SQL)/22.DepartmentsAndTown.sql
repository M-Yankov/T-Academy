USE TelerikAcademy
GO

SELECT t.Name 
FROM [Towns] t
UNION
SELECT d.Name 
FROM [Departments] d

