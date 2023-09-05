-- Create a new database named "TinyDB".
CREATE DATABASE TinyDB;
GO

-- Use the "TinyDB" database for subsequent operations.
USE TinyDB;
GO

-- Create the "Instructors" table to store information about instructors.
CREATE TABLE Instructors (
    InstructorId INT PRIMARY KEY,
    InstructorName NVARCHAR(50)
);
GO

-- Create the "Students" table to store information about students.
CREATE TABLE Students (
    StudentId INT PRIMARY KEY,
    StudentName NVARCHAR(50),
    CoursesRegistered NVARCHAR(MAX) DEFAULT ('') -- Add the default value constraint
);
GO

-- Create the "Courses" table to store information about courses.
-- The "InstructorId" column is a foreign key referencing the "Instructors" table.
CREATE TABLE Courses (
    CourseId INT PRIMARY KEY,
    CourseTitle NVARCHAR(100),
    InstructorId INT,
    AvailableSeats INT,
    IsActive BIT,
    InstructorName NVARCHAR(50),
    FOREIGN KEY (InstructorId) REFERENCES Instructors(InstructorId)
);
GO

-- Insert sample data into the "Instructors" table.
INSERT INTO Instructors (InstructorId, InstructorName)
VALUES (1, 'Salamah Peake'), (2, 'Ian Rhoades'), (3, 'Zach Galindo'), (4, 'Erin York');

-- Insert sample data into the "Courses" table, including the additional columns and the "InstructorId" to establish relationships.
INSERT INTO Courses (CourseId, CourseTitle, InstructorId, AvailableSeats, IsActive, InstructorName)
VALUES (1, 'Art History', 1, 9, 1, 'Salamah Peake'), 
       (2, 'Programming 101', 2, 8, 1, 'Ian Rhoades'), 
       (3, 'Advanced Mathematics', 2, 6, 1, 'Ian Rhoades'), 
       (4, 'Creative Writing', 3, 3, 1, 'Zach Galindo'), 
       (5, 'Astronomy', 3, 4, 1, 'Zach Galindo'), 
       (6, 'Modern Philosophy', 3, 7, 1, 'Zach Galindo');
GO

-- Check if the tables "Instructors," "Students," and "Courses" exist in the database.
SELECT * FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_NAME IN ('Instructors', 'Students', 'Courses');

-- Create the "StudentCourses" table to store the relationship between students and courses.
CREATE TABLE StudentCourses (
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    CONSTRAINT PK_StudentCourses PRIMARY KEY (StudentId, CourseId),
    CONSTRAINT FK_StudentCourses_Students FOREIGN KEY (StudentId) REFERENCES Students (StudentId) ON DELETE CASCADE,
    CONSTRAINT FK_StudentCourses_Courses FOREIGN KEY (CourseId) REFERENCES Courses (CourseId) ON DELETE CASCADE
);
GO
-- Insert data into the StudentCourses table
INSERT INTO StudentCourses (StudentId, CourseId)
VALUES
    (3672, 1),
    (3672, 6),
    (3672, 12033),
    (3672, 79021),
    (4629, 1),
    (4629, 3),
    (4629, 5),
    (4629, 12033);