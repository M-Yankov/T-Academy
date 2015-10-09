
CREATE VIEW [Active users today] AS
SELECT * FROM  [TelerikAcademy].[dbo].[Users]
WHERE CAST(LastLogin AS DATE) = CAST(GETDATE() AS DATE)
GO

SELECT * FROM [Active users today]
GO