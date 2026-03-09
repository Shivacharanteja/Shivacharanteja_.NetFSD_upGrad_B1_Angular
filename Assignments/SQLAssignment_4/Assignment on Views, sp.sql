--View's Assignments
--Assignment 1
create view vw_StudentDepartment as
select S.StudentId, S.FirstName, D.DepartmentName, S.AdmissionDate
from Students S
JOIN Departments D on S.DepartmentId=D.DepartmentId

select * from vw_StudentDepartment

select * from vw_StudentDepartment
where DepartmentName='Science'

drop view vw_StudentDepartment

--Assignment 2
create view vw_StudentCourses as
select S.StudentId, S.FirstName, C.CourseName, E.EnrollmentDate
from Students S
JOIN Enrollments E on S.StudentId=E.StudentId
join Courses C on E.CourseId=C.CourseId

select FirstName, CourseName
from vw_StudentCourses
where StudentId=5;

select FirstName, count(CourseName) as TotalCourses
from vw_StudentCourses
GROUP BY FirstName

select FirstName, CourseName, EnrollmentDate
from vw_StudentCourses
where EnrollmentDate > '2026-01-13'

--Assignment 3
create view vw_ExamResults as
select S.FirstName, C.CourseName, E.ExamType, M.MarksObtained
from Students S
JOIN Marks M on S.StudentId=M.StudentId
join Exams E on M.ExamId=E.ExamId
join Courses C on E.CourseId=C.CourseId

select FirstName, CourseName, MarksObtained
from vw_ExamResults
where MarksObtained > 80 

select CourseName, ExamType, MAX(MarksObtained) as TopScore
from vw_ExamResults
GROUP BY CourseName, ExamType

select FirstName, CourseName, ExamType, MarksObtained
from vw_ExamResults
where MarksObtained < 50
--Assignment 4
CREATE VIEW vw_DepartmentStudentCount AS
SELECT 
    D.DepartmentName, 
    COUNT(S.StudentID) AS TotalStudents
FROM Departments D
LEFT JOIN Students S ON D.DepartmentID = S.DepartmentID
GROUP BY D.DepartmentName;

SELECT * FROM vw_DepartmentStudentCount 
WHERE TotalStudents > 10;

SELECT * FROM vw_DepartmentStudentCount 
ORDER BY TotalStudents DESC;

--Stored Procedure Assignments
--Assignment 1
CREATE PROCEDURE sp_InsertStudent
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender CHAR(1),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO Students (FirstName, Gender, DepartmentID, AdmissionDate)
    VALUES (@FirstName + ' ' + @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;

EXEC sp_InsertStudent 
    @FirstName = 'Shivacharanteja', 
    @LastName = 'Gunda', 
    @Gender = 'M', 
    @DepartmentID = 101, 
    @AdmissionDate = '2026-03-09'
drop procedure sp_InsertStudent
CREATE PROCEDURE sp_InsertStudent
    @StudentId int,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender CHAR(1),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO Students (StudentId,FirstName, LastName Gender, DepartmentID, AdmissionDate)
    VALUES (@StudentId,@FirstName, @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;
EXEC sp_InsertStudent
    @StudentId=21,
    @FirstName = 'Shivacharanteja', 
    @LastName = 'Gunda', 
    @Gender = 'M', 
    @DepartmentID = 101, 
    @AdmissionDate = '2026-03-09'
    select * from Students
    drop procedure sp_InsertStudent
CREATE PROCEDURE sp_InsertStudent
    @StudentId int,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Gender CHAR(1),
    @DepartmentID INT,
    @AdmissionDate DATE
AS
BEGIN
    INSERT INTO Students (StudentId,FirstName, LastName, Gender, DepartmentID, AdmissionDate)
    VALUES (@StudentId,@FirstName, @LastName, @Gender, @DepartmentID, @AdmissionDate);
END;
EXEC sp_InsertStudent
    @StudentId=21,
    @FirstName = 'Shivacharanteja', 
    @LastName = 'Gunda', 
    @Gender = 'M', 
    @DepartmentID = 101, 
    @AdmissionDate = '2026-03-09'

select * from Students where FirstName like '%Shivacharanteja'
--Assignment 2
CREATE PROCEDURE sp_GetStudentsByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        StudentID, 
        FirstName, 
        AdmissionDate
    FROM Students
    WHERE DepartmentID = @DepartmentID;
END;
EXEC sp_GetStudentsByDepartment @DepartmentID = 102
EXEC sp_GetStudentsByDepartment @DepartmentID = 103;

--Assignment 3
CREATE PROCEDURE sp_EnrollStudent
    @StudentID INT,
    @CourseID INT
AS
BEGIN
    INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
    VALUES (@StudentID, @CourseID, GETDATE());
END;

--Assignment 4
CREATE PROCEDURE sp_GetStudentMarks
    @StudentID INT
AS
BEGIN
    SELECT S.FirstName, C.CourseName, E.ExamType, M.MarksObtained
    FROM Students S
    JOIN Marks M ON S.StudentID = M.StudentID
    JOIN Exams E ON M.ExamID = E.ExamID
    JOIN Courses C ON E.CourseID = C.CourseID
    WHERE S.StudentID = @StudentID;
END;

--Assignment 5
CREATE PROCEDURE sp_UpdateMarks
    @MarkID INT, 
    @NewMarks INT
AS
BEGIN
    UPDATE Marks 
    SET MarksObtained = @NewMarks 
    WHERE MarkID = @MarkID;

    SELECT * FROM Marks WHERE MarkID = @MarkID;
END;

--Assignment 6
CREATE PROCEDURE sp_DeleteEnrollment @EnrollmentID INT
AS
BEGIN
    DELETE FROM Enrollments WHERE EnrollmentID = @EnrollmentID;

    SELECT * FROM Enrollments WHERE EnrollmentID = @EnrollmentID;
END;



--User Defined Functions Assignments
--Assignment 1
CREATE FUNCTION fn_GetGrade (@MarksObtained INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Grade VARCHAR(10);
    SET @Grade = CASE 
        WHEN @MarksObtained >= 90 THEN 'A'
        WHEN @MarksObtained >= 75 THEN 'B'
        WHEN @MarksObtained >= 60 THEN 'C'
        ELSE 'Fail'
    END;
    RETURN @Grade;
END;
SELECT FirstName, CourseName, MarksObtained, dbo.fn_GetGrade(MarksObtained) AS Grade
FROM vw_ExamResults;

--Assignment 2
CREATE FUNCTION fn_GetStudentAge (@DateOfBirth DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(YEAR, @DateOfBirth, GETDATE()) - 
           CASE WHEN (MONTH(@DateOfBirth) > MONTH(GETDATE())) OR 
                     (MONTH(@DateOfBirth) = MONTH(GETDATE()) AND DAY(@DateOfBirth) > DAY(GETDATE())) 
                THEN 1 ELSE 0 END;
END;
SELECT FirstName, dbo.fn_GetStudentAge(DateOfBirth) AS Age FROM Students;
--Assignment 3
CREATE FUNCTION fn_GetTotalMarks (@StudentID INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalMarks INT;
    SELECT @TotalMarks = SUM(MarksObtained) 
    FROM Marks 
    WHERE StudentID = @StudentID;
    RETURN ISNULL(@TotalMarks, 0);
END;

--Assignment 4
CREATE FUNCTION fn_GetStudentCourses (@StudentID INT)
RETURNS TABLE AS
RETURN (
    SELECT C.CourseName, E.EnrollmentDate
    FROM Enrollments E
    JOIN Courses C ON E.CourseID = C.CourseID
    WHERE E.StudentID = @StudentID
);

--Assignment 5
CREATE FUNCTION fn_GetDepartmentStudents (@DepartmentID INT)
RETURNS TABLE AS RETURN (
    SELECT StudentID, FirstName, AdmissionDate
    FROM Students WHERE DepartmentID = @DepartmentID
);