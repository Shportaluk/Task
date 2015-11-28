USE SAP_TASK_TODO

CREATE TABLE tbl_task
(
	Id INT IDENTITY( 1, 1 ),
	Title NCHAR( 255 ),
	IsDone BIT,
	Priority INT,
	Id_User INT
);

CREATE TABLE tbl_Users
(
	Id INT IDENTITY (1,1),
	Login NCHAR(255),
	Pass NCHAR(255),
	Id_Task INT
);
/*0 critical - 1 height - 2 normal - 3 low - 4 minimum */

INSERT INTO tbl_task VALUES ( 'Task #1' , '0', 2, 0 );
INSERT INTO tbl_task VALUES ( 'Task #2' , '1', 2, 0 );
INSERT INTO tbl_task VALUES ( 'Task #3' , '0', 2, 1 );
INSERT INTO tbl_task VALUES ( 'Task #4' , '1', 2, 1 );
INSERT INTO tbl_task VALUES ( 'Task #5' , '0', 2, 2 );

// USERS
INSERT INTO tbl_Users VALUES ( 'admin' , '1111', 0 );
INSERT INTO tbl_Users VALUES ( 'admin2' , '1111', 1 );
INSERT INTO tbl_Users VALUES ( 'admin3' , '1111', 2 );


SELECT * FROM tbl_task
SELECT * FROM tbl_Users


SELECT Id_Task FROM tbl_Users
SELECT * FROM tbl_task WHERE Id_User = 0



SELECT Id_User FROM tbl_Users WHERE Login = 'admin' and Pass = '1111'
SELECT Id_Task FROM tbl_Users WHERE Login = '{0}' and Pass = '{1}'

SELECT * FROM tbl_task WHERE IsDone = 0
SELECT * FROM tbl_task WHERE IsDone = 1


UPDATE tbl_task SET Priority = 0 WHERE Id = 5

UPDATE tbl_task SET IsDone = 0
UPDATE tbl_task SET IsDone = 1 WHERE Id = 5

DROP TABLE tbl_task
DROP TABLE tbl_Users