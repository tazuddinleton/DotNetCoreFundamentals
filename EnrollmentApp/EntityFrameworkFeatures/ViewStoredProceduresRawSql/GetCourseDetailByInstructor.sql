CREATE OR ALTER PROCEDURE
GetCourseByInstructor
@InstructorId INT = 0
AS
BEGIN
	SELECT I.Name
	, C.Title
	, COUNT(1) AS NumOfEnrolledStudents
FROM Courses C
INNER JOIN Instructors I
	ON C.InstructorId = I.InstructorId
INNER JOIN Enrollments E ON C.CourseId = E.CourseId
WHERE C.InstructorId = @InstructorId
GROUP BY I.Name
	, C.Title
END