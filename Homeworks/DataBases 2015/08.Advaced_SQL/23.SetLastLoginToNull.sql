USE TelerikAcademy
Go

UPDATE Users
SET LastLogin=NULL
WHERE LastLogin <= '2010-03-10'
GO