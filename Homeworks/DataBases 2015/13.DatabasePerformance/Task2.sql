Use Performance
GO

CHECKPOINT; DBCC DROPCLEANBUFFERS; 

SELECT t.BirthDay
 FROM [TestTable] t
 WHERE YEAR(t.BirthDay) BETWEEN 2010 AND 2015  
 -- 15 seconds. Double faster than previous. Non cluster Index added to column [BirthDay].