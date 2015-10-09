USE TelerikAcademy

CREATE TABLE WorkHours (
	EmployeeID INT NOT NULL,
	WorkDate DATE NOT NULL,
	WorkTask NVARCHAR(50) NOT NULL,
	WorkHoursPerEmp int NOT NULL,
	Comments NVARCHAR(100),
	CONSTRAINT Enough_Hours CHECK(WorkHoursPerEmp < 13),
	CONSTRAINT Unique_ID UNIQUE(EmployeeID),
	CONSTRAINT PK_Employee PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_EmployeeWorkHours
		FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID))
GO

CREATE TABLE WorkHoursLog (
	ChangeID INT UNIQUE IDENTITY NOT NULL,
	EmployeeID INT NOT NULL,
	WorkDate DATE NOT NULL,
	WorkTask NVARCHAR(50) NOT NULL,
	WorkHoursPerEmp int NOT NULL,
	Comments NVARCHAR(100),
	Command NVARCHAR(20) NOT NULL,
	ChangedCols NVARCHAR(50),
	CONSTRAINT PK_ChangeID PRIMARY KEY(ChangeID))
GO


CREATE TRIGGER TR_OnInsert ON WorkHours FOR INSERT 
AS
INSERT INTO WorkHoursLog(EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments, Command, ChangedCols)
	SELECT EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments, 'INSERT', '1 2 3 4 5'
	FROM inserted
GO

CREATE TRIGGER TR_OnDelete ON WorkHours FOR DELETE
AS
INSERT INTO WorkHoursLog(EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments, Command, ChangedCols)
	SELECT EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments, 'DELETE', '1 2 3 4 5'
	FROM deleted
GO

CREATE TRIGGER TR_OnUpdate ON WorkHours FOR UPDATE
AS

DECLARE @insEmployeeID INT,
		@insWorkDate DATE,
		@insWorkTask NVARCHAR(50),
		@insWorkHourPerEmp INT,
		@insComments NVARCHAR(100),
		@delEmployeeID INT,
		@delWorkDate DATE,
		@delWorkTask NVARCHAR(50),
		@delWorkHourPerEmp INT,
		@delComments NVARCHAR(100),
		@changedColums NVARCHAR(30) = ''

SELECT @insEmployeeID = i.EmployeeID, @delEmployeeID = d.EmployeeID,
		@insWorkDate = i.WorkDate, @delWorkDate = d.WorkDate,
		@insWorkTask = i.WorkTask, @delWorkTask = d.WorkTask,
		@insWorkHourPerEmp = i.WorkHoursPerEmp, @delWorkHourPerEmp = d.WorkHoursPerEmp,
		@insComments = i.Comments, @delComments = d.Comments
FROM [inserted] i, [deleted] d

IF @insEmployeeID != @delEmployeeID
	 SET @changedColums += ' 1'
IF @insWorkDate != @delWorkDate
	SET @changedColums += ' 2'
IF @insWorkTask != @delWorkTask
	SET @changedColums += ' 3'
IF @insWorkHourPerEmp != @delWorkHourPerEmp
	SET @changedColums += ' 4'
IF @insComments != @delComments
	SET @changedColums += ' 5'



INSERT INTO WorkHoursLog(EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments, Command, ChangedCols)
	SELECT d.EmployeeID, d.WorkDate, d.WorkTask, d.WorkHoursPerEmp, d.Comments, 'BEFOREUPDATE', @changedColums
	FROM [deleted] d

INSERT INTO WorkHoursLog(EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments, Command, ChangedCols)
	SELECT i.EmployeeID, i.WorkDate, i.WorkTask, i.WorkHoursPerEmp, i.Comments, 'AFTERUPDATE', @changedColums
	FROM [inserted] i
GO

-- Testing Triggers -- 

--- INSERT --
INSERT INTO WorkHours(EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments) 
VALUES (5, '2015-8-24', 'Fix performance problem', 6, 'Keep search for bottlenecks.'),
		(20, '2009-12-01', 'Create documentation for the project', 12, 'Use Sandcastle'),
		(30, '2010-01-03', 'Go but some pizzas', 1, 'Grab & Go'),
		(31, '2015-09-24', 'Check Finance Budget', 3, 'At Finance Department')
GO
-- DeLETE ---
DELETE FROM WorkHours
WHERE WorkHoursPerEmp < 8
GO
--Oops one row left OK again insert some bullshits

INSERT INTO WorkHours(EmployeeID, WorkDate, WorkTask, WorkHoursPerEmp, Comments) 
VALUES (99, '2015-8-24', 'Ensure Code Quality', 10, 'Normal priority'),
		(88, '2013-12-01', 'Quality Assurance', 12, 'Bonus salary'),
		(74, '2015-01-26', 'Unit tests', 12, 'Make in quick as possible'),
		(92, '2015-09-25', 'Fix Bug #22', 11, 'Try to not broke code structure')
GO

-- UPDATE --
UPDATE WorkHours
SET WorkDate='2015-02-01', WorkTask='IMPORTANT! Unit tests', WorkHoursPerEmp=9, Comments='Come on dude!'
WHERE EmployeeID = 74


