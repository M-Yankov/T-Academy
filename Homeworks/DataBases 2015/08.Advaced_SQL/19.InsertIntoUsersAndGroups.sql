INSERT INTO Groups (Name) VALUES
	('Admins'),
	('Members'),
	('Hackers'),
	('Anonymous'),
	('Stalkers'),
	('Warriors'),
	('Students'),
	('Footballers')
GO

UPDATE Users
SET GroupID=2
WHERE GroupID IS NULL
GO

INSERT INTO Users (UserName, UserPassword, FullName, LastLogin, GroupID) VALUES
('bakary', '*883donttuch', 'Vasilii Hrushtiov', GETDATE(), 3),
('balter', '!@#$%$%#$%^^', 'Aznan Kazul', GETDATE(), 2),
('bitshop', '*aaa5552222ss', 'Bob Sheims', GETDATE(), 1),
('zafer', '*llfoflklfv', 'Hrebel Mesecel', '2014-04-04', 4),
('claudi', '*123f-140c102-23ba0-297fe', 'Scott Tomson', '2015-10-01', 7),
('Cokcz', 'longpassword', 'Cirulium Papadopolo', GETDATE(), 6),
('boyzRULEZ', '*stupidpassword', 'Greck Klein', '2012-04-01', 3),
('GangamStyle', 'enoughpasswordsfortoday', 'Jack Boston', GETDATE(), 6),
('TAcademy', 'badjobdab', 'Los Amigos', GETDATE(), 5),
('Operator172', 'ska23ss89', 'Chien Hawall', '2015-09-03', 6),
('Omruznami', 'soske0000', 'Segei Peevich', GETDATE(), 5),
('na_Sakoto_Qkata', 'gerallis', 'Vasilii Hrushtiov', GETDATE(), 5),
('barabamti', '10293847', 'Hris Petrov', '2015-09-09', 1),
('Chip&Dale', 'op9-32_@', 'Chistophar Robbin', GETDATE(), 4)
GO