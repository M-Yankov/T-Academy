USE TelerikAcademy


BEGIN TRAN


SELECT EmployeeID, ProjectID
INTO #TempProjects
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID INT,
	ProjectID INT,
	CONSTRAINT PK_s PRIMARY KEY(EmployeeID, ProjectID)
)

INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	SELECT EmployeeID, ProjectID FROM #TempProjects
ROLLBACK TRAN