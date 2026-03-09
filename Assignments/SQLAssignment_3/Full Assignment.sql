--Assignment 1
create database SchoolDb
use SchoolDb
create table Departments(
DepartmentId INT PRIMARY KEY,
DepartmentName VARCHAR(100) not null,
Location varchar(100)
);
create table Teachers(
TeacherId INT PRIMARY KEY,
TeacherName varchar(100) not null,
Email varchar(100),
DepartmentId INT,
HireDate DATE,
foreign key (DepartmentId) references Departments(DepartmentId)
);
create table Students(
StudentId INT PRIMARY KEY,
FirstName varchar(50) not null,
LastName varchar(50) not null,
DateOfBirth DATE,
Gender varchar(10),
DepartmentId INT,
AdmissionDate DATE,
foreign key (DepartmentId) references Departments(DepartmentId)
);
create table Courses(
CourseId INT PRIMARY KEY,
CourseName varchar(50) not null,
Credits INT,
DepartmentId INT,
TeacherId INT,
foreign key (DepartmentId) references Departments(DepartmentId),
foreign key (TeacherId) references Teachers(TeacherId)
);
create table Enrollments(
EnrollmentId INT PRIMARY KEY,
StudentId INT,
CourseId INT,
EnrollmentDate DATE,
foreign key (StudentId) references Students(StudentId),
foreign key (CourseId) references Courses(CourseId)
);
create table Exams(
ExamId INT PRIMARY KEY,
CourseId INT,
ExamType varchar(50),
ExamDate DATE
foreign key (CourseId) references Courses(CourseId)
);
create table Marks(
MarkId INT PRIMARY KEY,
StudentId INT,
ExamId INT,
MarksObtained decimal(10,2),
foreign key (StudentId) references Students(StudentId),
foreign key (ExamId) references Exams(ExamId)
);

--Assignment 2
ALTER TABLE Departments 
ADD CONSTRAINT UQ_DepartmentName UNIQUE (DepartmentName);

ALTER TABLE Students 
ADD CONSTRAINT CHK_Gender CHECK (Gender IN ('M', 'F'));

ALTER TABLE Courses 
ADD CONSTRAINT CHK_Credits CHECK (Credits BETWEEN 1 AND 5);

ALTER TABLE Marks 
ADD CONSTRAINT CHK_MarksObtained CHECK (MarksObtained BETWEEN 0 AND 100);

ALTER TABLE Teachers 
ADD CONSTRAINT UQ_Email UNIQUE (Email);

ALTER TABLE Enrollments 
ADD CONSTRAINT DF_EnrollmentDate DEFAULT GETDATE() FOR EnrollmentDate;

--Assignment 3
alter table Students
add PhoneNumber varchar(15);

alter table Teachers
add Salary decimal(10,2);

alter table Teachers
alter column Salary Money;

alter table  Teachers
add constraint CHK_Salary Check (Salary > 20000);

alter table Students
drop column Phonenumber;

exec sp_rename 'Teachers.Salary','MonthlySalary','COLUMN';
alter table  Teachers
drop constraint CHK_Salary;
exec sp_rename 'Teachers.Salary','MonthlySalary','COLUMN';
alter table  Teachers
add constraint CHK_MonthlySalary Check (MonthlySalary > 20000);

--Assignment 4
insert into Departments(DepartmentId, DepartmentName,Location) values
(101,'Telugu','Room A'),
(102,'Hindi','Room B'),
(103,'English','Room C'),
(104,'Maths','Room D'),
(105,'Science','Room E');
insert into Teachers(TeacherId,TeacherName,Email,DepartmentId,HireDate,MonthlySalary) values
(201,'Virat Kohli','virat@gmail.com',101,'2026.10.02',1000000),
(202,'Dinesh Karthik','dinesh@gmail.com',102,'2026.10.03',400000),
(203,'Dale Steyn','dale@gmail.com',102,'2026.10.04',200000),
(204,'Yuzi Chahal','yuzi@gmail.com',102,'2026.10.05',400000),
(205,'ABD','abd@gmail.com',101,'2026.10.06',800000),
(206,'Chris Gayle','gayle@gmail.com',101,'2026.10.07',800000),
(207,'Bhuvaneshwar','bhuvi@gmail.com',103,'2026.10.08',300000),
(208,'Rajat Patidar','rajat@gmail.com',104,'2026.10.09',500000),
(209,'Phil Salt','salt@gmail.com',105,'2026.10.10',500000),
(210,'Jacob Bethell','jacob@gmail.com',104,'2026.10.11',500000);
insert into Students(StudentId,FirstName,LastName,DateOfBirth,Gender,DepartmentId,AdmissionDate) values
(1,'Suyash','Sharma','2000-02-02','M',101,'2023-11-04'),
(2,'Ngidi','Lungi','2001-03-04','M',101,'2023-10-04'),
(3,'Stokes','Ben','2002-06-02','M',102,'2023-12-04'),
(4,'Buttler','Jos','2010-01-06','M',105,'2022-11-04'),
(5,'Gambhir','Gautam','2020-01-09','M',103,'2022-11-05'),
(6,'Surya','Kumar','2010-02-11','M',102,'2022-11-06'),
(7,'Hardik','Pandya','1987-11-12','M',101,'2024-07-04'),
(8,'Krunal','Pandya','1999-02-06','M',104,'2024-05-04'),
(9,'Tim','David','2009-06-02','M',104,'2024-11-09'),
(10,'Shepherd','Romario','2016-11-11','M',104,'2025-11-02'),
(11,'Bumrah','Jasprit','2019-01-01','M',103,'2025-11-09'),
(12,'Tilak','Varma','2001-11-01','M',102,'2025-01-11'),
(13,'Rinku','Singh','2002-03-02','M',102,'2021-02-02'),
(14,'Dube','Shivam','2003-02-03','M',101,'2021-03-03'),
(15,'Axar','Patel','2004-03-04','M',101,'2021-11-11'),
(16,'Varun','Chakravarthy','2005-04-05','M',105,'2022-06-06'),
(17,'Sanju','Samson','2006-05-06','M',105,'2022-07-07'),
(18,'Abhishek','Sharma','2007-06-07','M',105,'2022-08-08'),
(19,'Ishan','Kishan','2008-07-08','M',104,'2020-11-09'),
(20,'Arshdeep','Singh','2009-08-09','M',104,'2020-11-10');

insert into Courses(CourseId,CourseName,Credits,DepartmentId,TeacherId) values
(311,'Java Fullstack',4,101,201),
(302,'Python Fullstack',3,102,202),
(303,'MERN stack',5,101,203),
(304,'DevOps',1,103,204),
(305,'Manual Testing',1,104,205),
(306,'Automation Testing',2,101,206),
(307,'Data science with AI',3,105,207),
(308,'ServiceNow',1,102,208),
(309,'Salesforce',4,102,209),
(310,'SAP',3,105,210);

INSERT INTO Exams (ExamId, CourseId, ExamType, ExamDate) VALUES
(401, 301, 'Midterm', '2024-03-10'),
(402, 302, 'Final', '2024-05-15'),
(403, 303, 'Midterm', '2024-03-12'),
(404, 305, 'Quiz', '2024-02-20'),
(405, 307, 'Final', '2024-05-18');

INSERT INTO Enrollments (EnrollmentId, StudentId, CourseId, EnrollmentDate) VALUES
(501, 1, 301, '2026-01-10'), (502, 2, 301, '2026-01-10'), (503, 3, 302, '2026-01-11'),
(504, 4, 302, '2026-01-11'), (505, 5, 303, '2026-01-12'), (506, 6, 303, '2026-01-12'),
(507, 7, 304, '2026-01-13'), (508, 8, 304, '2026-01-13'), (509, 9, 305, '2026-01-14'),
(510, 10, 305, '2026-01-14'), (511, 11, 306, '2026-01-15'), (512, 12, 306, '2026-01-15'),
(513, 13, 307, '2026-01-16'), (514, 14, 307, '2026-01-16'), (515, 15, 308, '2026-01-17'),
(516, 16, 308, '2026-01-17'), (517, 17, 309, '2026-01-18'), (518, 18, 309, '2026-01-18'),
(519, 19, 310, '2026-01-19'), (520, 20, 310, '2026-01-19'), (521, 1, 302, '2026-01-20'),
(522, 2, 303, '2026-01-20'), (523, 3, 304, '2026-01-21'), (524, 4, 305, '2026-01-21'),
(525, 5, 306, '2026-01-22'), (526, 6, 307, '2026-01-22'), (527, 7, 308, '2026-01-23'),
(528, 8, 309, '2026-01-23'), (529, 9, 310, '2026-01-24'), (530, 10, 301, '2026-01-24');
GO

INSERT INTO Marks (MarkId, StudentId, ExamId, MarksObtained) VALUES
(601, 1, 401, 85.50), (602, 2, 401, 78.00), (603, 3, 402, 92.00),
(604, 4, 402, 65.00), (605, 5, 403, 88.00), (606, 6, 403, 74.50),
(607, 7, 404, 45.00), (608, 8, 404, 52.00), (609, 9, 405, 91.00),
(610, 10, 405, 82.50), (611, 11, 401, 77.00), (612, 12, 401, 69.00),
(613, 13, 402, 84.00), (614, 14, 402, 73.00), (615, 15, 403, 95.00),
(616, 16, 403, 62.00), (617, 17, 404, 58.00), (618, 18, 404, 88.50),
(619, 19, 405, 76.00), (620, 20, 405, 93.00), (621, 1, 402, 81.00),
(622, 2, 403, 70.00), (623, 3, 404, 49.00), (624, 4, 405, 87.00),
(625, 5, 401, 94.00), (626, 6, 402, 68.00), (627, 7, 403, 75.00),
(628, 8, 404, 55.00), (629, 9, 401, 89.00), (630, 10, 402, 72.00);
GO
--Assignment 5
select * from Students where DepartmentId=101
select * from Teachers where HireDate>'2022-12-31'
select * from Students where FirstName like 'A%'
select * from Courses where Credits>3
select * from Students where DateOfBirth between '2005-01-01' and '2008-12-31'
select * from Students where DepartmentId<>105
select * from Teachers where MonthlySalary between 400000 and 700000
select * from Courses where TeacherId <> 202

--Assignment 6
SELECT DepartmentId, COUNT(StudentId) AS TotalStudents
FROM Students
GROUP BY DepartmentId;

SELECT ExamId, AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY ExamId;

SELECT CourseId, COUNT(StudentId) AS EnrolledStudents
FROM Enrollments
GROUP BY CourseId;

SELECT ExamId, MAX(MarksObtained) AS HighestMark
FROM Marks
GROUP BY ExamId;

SELECT E.CourseId, MIN(M.MarksObtained) AS LowestMark
FROM Marks M
JOIN Exams E ON M.ExamId = E.ExamId
GROUP BY E.CourseId;

SELECT DepartmentId, COUNT(StudentId) AS StudentCount
FROM Students
GROUP BY DepartmentId
HAVING COUNT(StudentId) > 2;

--Assignment 7
SELECT S.FirstName, S.LastName, D.DepartmentName
FROM Students S
INNER JOIN Departments D ON S.DepartmentId = D.DepartmentId;
GO

SELECT C.CourseName, T.TeacherName
FROM Courses C
INNER JOIN Teachers T ON C.TeacherId = T.TeacherId;
GO

SELECT S.FirstName, S.LastName, C.CourseName
FROM Students S
INNER JOIN Enrollments E ON S.StudentId = E.StudentId
INNER JOIN Courses C ON E.CourseId = C.CourseId;
GO

SELECT S.FirstName, S.LastName, E.ExamType, M.MarksObtained
FROM Students S
INNER JOIN Marks M ON S.StudentId = M.StudentId
INNER JOIN Exams E ON M.ExamId = E.ExamId;
GO

SELECT C.CourseName, T.TeacherName
FROM Courses C
LEFT JOIN Teachers T ON C.TeacherId = T.TeacherId;
GO

SELECT T.TeacherName
FROM Teachers T
LEFT JOIN Courses C ON T.TeacherId = C.TeacherId
WHERE C.CourseId=303;
GO

--Assignment 8
SELECT StudentId, MarksObtained 
FROM Marks 
WHERE MarksObtained > (SELECT AVG(MarksObtained) FROM Marks);
GO

SELECT CourseName, Credits 
FROM Courses 
WHERE Credits = (SELECT MAX(Credits) FROM Courses)
GO

SELECT StudentId, FirstName, LastName 
FROM Students 
WHERE StudentId IN (
    SELECT StudentId 
    FROM Enrollments 
    GROUP BY StudentId 
    HAVING COUNT(CourseId) > 2
);
GO
SELECT TeacherName, DepartmentId 
FROM Teachers 
WHERE DepartmentId = (
    SELECT DepartmentId 
    FROM Teachers 
    WHERE TeacherName LIKE '%ABD'
) AND TeacherName NOT LIKE '%Virat';
GO

SELECT StudentId, ExamId, MarksObtained 
FROM Marks M1
WHERE MarksObtained = (
    SELECT MAX(MarksObtained) 
    FROM Marks M2 
    WHERE M1.ExamId = M2.ExamId
);

SELECT DepartmentName 
FROM Departments 
WHERE DepartmentId = (
    SELECT TOP 1 DepartmentId 
    FROM Students 
    GROUP BY DepartmentId 
    ORDER BY COUNT(StudentId) DESC
);

--Assignment 10
CREATE INDEX IX_Student_LastName 
ON Students (LastName);
GO

CREATE INDEX IX_Teacher_Email 
ON Teachers (Email);
GO

CREATE INDEX IX_Enrollment_StudentCourse 
ON Enrollments (StudentId, CourseId);
GO

CREATE UNIQUE INDEX UIX_DepartmentName 
ON Departments (DepartmentName);
GO

DROP INDEX Students.IX_Student_LastName;
GO