Use Performance
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS; 

SELECT t.Content
 FROM [TestTable] t
 WHERE LEN(t.Content) BETWEEN 10 AND 15
 -- 18 seconds with Out index on [Content] column