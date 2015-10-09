USE TelerikAcademy
GO

UPDATE Groups 
SET Name='Europeans'
WHERE Name LIKE '%rr%'  -- Will change warriors to Europeans WHat is the sense, don't ask
GO

UPDATE Users
SET UserPassword='********'
WHERE GroupID IN(1,3,4)
GO