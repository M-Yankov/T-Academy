Use Performance
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS; 

SELECT t.BirthDay
 FROM [TestTable] t
 WHERE YEAR(t.BirthDay) BETWEEN 2010 AND 2015  
 -- 29 seconds first time executed. without index etc.