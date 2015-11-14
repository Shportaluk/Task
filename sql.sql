USE SAP_TASK_TODO

CREATE TABLE tbl_task
(
	Id INT IDENTITY( 1,1 ),
	Title NCHAR( 255 ),
	IsDone BIT,
	Priority INT
);
/*0 critical - 1 height - 2 normal - 3 low - 4 minimum */

INSERT INTO tbl_task VALUES ( 'Task #1' , '0', 2 );
INSERT INTO tbl_task VALUES ( 'Task #2' , '1', 2 );
INSERT INTO tbl_task VALUES ( 'Task #3' , '0', 2 );
INSERT INTO tbl_task VALUES ( 'Task #4' , '1', 2 );
INSERT INTO tbl_task VALUES ( 'Task #5' , '0', 2 );

SELECT * FROM tbl_task

SELECT * FROM tbl_task WHERE IsDone = 0
SELECT * FROM tbl_task WHERE IsDone = 1


UPDATE tbl_task SET Priority = 0 WHERE Id = 5

UPDATE tbl_task SET IsDone = 0
UPDATE tbl_task SET IsDone = 1 WHERE Id = 5

DROP TABLE tbl_task