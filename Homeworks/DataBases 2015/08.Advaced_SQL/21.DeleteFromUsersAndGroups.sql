USE TelerikAcademy
GO

DELETE FROM Users
WHERE LastLogin <= '2015-01-01'
GO

DELETE FROM Groups
WHERE Name LIKE 'Foot%'
GO