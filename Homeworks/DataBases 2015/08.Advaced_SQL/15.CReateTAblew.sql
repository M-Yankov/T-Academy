USE TelerikAcademy
GO

CREATE TABLE Users (
	UserID int IDENTITY NOT NULL,
	UserName NVARCHAR(30) NOT NULL,
	UserPassword NVARCHAR(25) NOT NULL,
	FullName  NVARCHAR(40) NOT NULL,
	LastLogin DATE,
	CONSTRAINT PK_User PRIMARY KEY(UserID),
	CONSTRAINT uc_PersonID UNIQUE(UserID,UserName),
	CONSTRAINT UserPass CHECK(DATALENGTH(UserPassword) >= 5)
)