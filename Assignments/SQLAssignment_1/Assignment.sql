create database SQLAssignments
use SQLAssignments
CREATE TABLE Worker (
	WORKER_ID INT PRIMARY KEY IDENTITY(1,1),
	FIRST_NAME VARCHAR(25),
	LAST_NAME VARCHAR(25),
	SALARY INT,
	JOINING_DATE DATETIME,
	DEPARTMENT CHAR(25)
);
CREATE TABLE Bonus (
	WORKER_REF_ID INT,
	BONUS_AMOUNT INT,
	BONUS_DATE DATETIME,
	FOREIGN KEY (WORKER_REF_ID) REFERENCES Worker(WORKER_ID)
    ON DELETE CASCADE
);
CREATE TABLE Title (
	WORKER_REF_ID INT,
	WORKER_TITLE CHAR(25),
	AFFECTED_FROM DATETIME,
	FOREIGN KEY (WORKER_REF_ID) REFERENCES Worker(WORKER_ID)
    ON DELETE CASCADE
);
INSERT INTO Worker(FIRST_NAME, LAST_NAME, SALARY, JOINING_DATE, DEPARTMENT) VALUES
('Monika','Arora',100000,'2014-02-20 09:00:00','HR'),
('Niharika','Verma',80000,'2014-06-11 09:00:00','Admin'),
('Vishal','Singhal',300000,'2014-02-20 09:00:00','HR'),
('Amitabh','Singh',500000,'2014-02-20 09:00:00','Admin'),
('Vivek','Bhati',500000,'2014-06-11 09:00:00','Admin'),
('Vipul','Diwan',200000,'2014-06-11 09:00:00','Account'),
('Satish','Kumar',75000,'2014-01-20 09:00:00','Account'),
('Geetika','Chauhan',90000,'2014-04-11 09:00:00','Admin')

INSERT INTO Bonus(WORKER_REF_ID, BONUS_DATE, BONUS_AMOUNT) VALUES
(1,'2016-02-20 00:00:00', 5000),
(2,'2016-06-11 00:00:00', 3000),
(3,'2016-02-20 00:00:00', 4000),
(1,'2016-02-20 00:00:00', 4500),
(2,'2016-06-11 00:00:00', 3500)

INSERT INTO Title(WORKER_REF_ID, AFFECTED_FROM, WORKER_TITLE) VALUES
(1,'2016-02-20 00:00:00', 'Manager'),
(2,'2016-06-11 00:00:00', 'Executive'),
(8,'2016-06-11 00:00:00', 'Executive'),
(5,'2016-06-11 00:00:00', 'Manager'),
(4,'2016-06-11 00:00:00', 'Asst. Manager'),
(7,'2016-06-11 00:00:00', 'Executive'),
(6,'2016-06-11 00:00:00', 'Lead'),
(3,'2016-06-11 00:00:00', 'Lead')

select FIRST_NAME as WORKER_NAME from Worker
select UPPER(FIRST_NAME) as WORKER_NAME from Worker
select DISTINCT Department as UNIQUE_DEPARTMENT from Worker
select SUBSTRING(FIRST_NAME,1,3) from Worker
select CHARINDEX('a', FIRST_NAME) from Worker where FIRST_NAME='Amitabh';
select RTRIM(FIRST_NAME) from Worker;
select LTRIM(DEPARTMENT) from Worker;
select DISTINCT DEPARTMENT, LEN(DEPARTMENT) FROM Worker
select REPLACE(FIRST_NAME, 'a', 'A') from Worker
select FIRST_NAME+' '+LAST_NAME as COMPLETE_NAME from Worker
select * from Worker ORDER BY FIRST_NAME ASC
select * from Worker ORDER BY FIRST_NAME ASC, DEPARTMENT DESC
select * from Worker where FIRST_NAME IN('Vipul','Satish')
select * from Worker where FIRST_NAME NOT IN('Vipul','Satish')
select * from Worker where DEPARTMENT='Admin'
select * from Worker where FIRST_NAME LIKE '%a%'
select * from Worker where FIRST_NAME LIKE '%a'
select * from Worker where FIRST_NAME LIKE '_____h'
select * from Worker where SALARY BETWEEN 100000 AND 500000
select * from Worker where YEAR(JOINING_DATE)=2014 AND MONTH(JOINING_DATE)=2;
select FIRST_NAME+' '+LAST_NAME as WORKER_NAME from Worker where SALARY>= 50000 AND SALARY<=100000
select DEPARTMENT, COUNT(WORKER_ID) as No_of_Workers from Worker GROUP BY DEPARTMENT ORDER BY No_of_Workers DESC;
SELECT GETDATE()
SELECT TOP 10 * from Worker;
--join
select W.* from Worker W INNER JOIN Title T ON W.WORKER_ID=T.WORKER_REF_ID
WHERE T.WORKER_TITLE='Manager'