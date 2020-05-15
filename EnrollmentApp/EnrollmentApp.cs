using EnrollmentApp.Entities;
using EnrollmentApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnrollmentApp
{
    class EnrollmentApp
    {
        static void Main(string[] args)
        {
            QueryingManyToMany();
        }

        static void QueryingManyToMany()
        {
            using (var context = new EnrollmentContext())
            {
                //var instructor = 
                //    context.Instructors
                // .Include(x => x.Courses)
                // .ThenInclude(e => e.Enrollments)
                // .ThenInclude(s => s.Student)                 
                // .FirstOrDefault(x => x.Name.Contains("Bob"));

                var instructor = context.Instructors.SingleOrDefault(x => x.Name.Contains("Bob"));

                var bobsCourseInfo =
                    context.Courses
                    .Where(x => x.InstructorId == instructor.InstructorId)
                    .Select(x => new
                    {                        
                        Course = new
                        {
                            Title = x.Title,
                            Students = x.Enrollments.Select(e => e.Student)
                        }
                    })
                    .ToList();
            }
        }

        static void UpdateUsingEntry()
        {
            var context = new EnrollmentContext();
            var instructor = context.Instructors
                .Include(i => i.Courses)
                .SingleOrDefault(x => x.Name.Contains("Shifu"));

            var course = instructor.Courses[0];
            course.Title = "The first course of master shifu";
            using (var newContext = new EnrollmentContext())
            {
                newContext.Entry(course).State = EntityState.Modified;
                newContext.SaveChanges();
            }
        }

        static void ProjectAndJoin()
        {


            using (var context = new EnrollmentContext())
            {


                var courses = context.Courses
                    .Where(x => x.Enrollments.Count > 2)
                    .Select(x => new
                    {
                        Title = x.Title,
                        Instructor = x.Instructor.Name
                    })
                    .ToList();
            }
        }

        static void Projection()
        {
            using (var context = new EnrollmentContext())
            {
                var courses = context.Courses
                    .Where(x => x.Enrollments.Count > 2)
                    .Select(x => new
                    {
                        Title = x.Title,
                        Instructor = x.Instructor.Name
                    })
                    .ToList();
            }
        }

        static void EagerLoading()
        {
            using (var context = new EnrollmentContext())
            {
                context.Students.
                    Include(x => x.Enrollments).
                    ToList();

                context.Courses
                    .Include(x => x.Instructor)
                    .ThenInclude(x => x.Courses)
                    .ToList();
            }
        }

        static void InsertCourseWithFK(int id)
        {
            var newCourse = new Course() { InstructorId = id, Title = "New Chopstick mastery course", StartDate = DateTime.Now, EndDate = DateTime.Now };
            using (var newContext = new EnrollmentContext())
            {
                newContext.Courses.Add(newCourse);
                newContext.SaveChanges();
            }
        }

        static void UpdateInstructorUsingAttach(int id)
        {
            var context = new EnrollmentContext();
            var instructor = context.Instructors
                    .Include(i => i.Courses)
                    .FirstOrDefault(i => i.InstructorId == id);

            instructor.Name = "Master Shifu - The true master";
            instructor.Courses.Add(new Course() { Title = "Mastering chop sticks 3", StartDate = DateTime.Now, EndDate = DateTime.Now });

            using (var newContext = new EnrollmentContext())
            {
                newContext.Instructors.Attach(instructor);

                newContext.SaveChanges();
            }
        }

        static void UpdateInstructorDisconnected(int id)
        {
            var context = new EnrollmentContext();
            var instructor = context.Instructors
                    .Include(i => i.Courses)
                    .FirstOrDefault(i => i.InstructorId == id);

            instructor.Name = "Master Shifu - The true master";

            using (var newContext = new EnrollmentContext())
            {
                newContext.Instructors.Update(instructor);
                newContext.Courses.RemoveRange(instructor.Courses.OrderBy(x => x.CourseId).Last());
                newContext.SaveChanges();
            }
        }

        static void UpdateInstructor(int id)
        {
            using (var context = new EnrollmentContext())
            {
                var instructor = context.Instructors
                    .Include("Courses")
                    .FirstOrDefault(i => i.InstructorId == id);
                instructor.Courses.Add(new Course() { Title = "Mastering chop sticks 2", StartDate = DateTime.Now, EndDate = DateTime.Now });
                context.Instructors.Update(instructor);
                context.SaveChanges();
            }
        }

        static void GetAllCourses()
        {
            using (var context = new EnrollmentContext())
            {
                var courses = context.Courses
                    .Include(c => c.Instructor)
                    .ToList();
                courses.ForEach(c => Console.WriteLine($"{c.Title} \n\tby {c.Instructor.Name}"));
            }
        }

        static void InsertRelatedData()
        {
            using (var context = new EnrollmentContext())
            {
                context.Instructors.Add(new Instructor()
                {
                    Name = "Master Shifu",
                    Courses = new List<Course>
                    {
                        new Course(){ Title = "Mastering the troll fu", StartDate = DateTime.Now, EndDate = DateTime.Now}
                    }
                });

                context.SaveChanges();
            }
        }

        static void NoTrackingDbContext()
        {
            using (var context = new EnrollmentContextNoTrack())
            {
                context.Students.ToList();
            }
        }

        static void QueryAsNoTracking()
        {
            using (var context = new EnrollmentContext())
            {
                context
                    .Courses
                    .AsNoTracking()
                    .Skip(1)
                    .Take(2)
                    .ToList();
            }
        }

        static void Paginate()
        {
            using (var context = new EnrollmentContext())
            {
                context
                    .Courses
                    .Skip(1)
                    .Take(2)
                    .ToList();
            }
        }

        static void Like_Search()
        {
            var context = new EnrollmentContext();
            var name = "%Taz%";
            context.Students.SingleOrDefault(s => EF.Functions.Like(s.Name, name));

        }

        static void Execution_Methods()
        {
            var context = new EnrollmentContext();
            context.Students.ToList();
            context.Students.First();
            context.Students.FirstOrDefault();
            context.Students.Single(s => s.StudentId == 1);
            context.Students.SingleOrDefault(s => s.StudentId == 1);

            // Last() and LastOrDefault() works with OrderBy()
            context.Students.OrderBy(s => s.StudentId).Last();
            context.Students.OrderBy(s => s.StudentId).LastOrDefault();
            context.Students.Find(2);

            /*
             * Aggregate Functions
             Average(), Sum(), Min(), Max()
             */

        }

        static void Display_Students_Of_Course_CleanCode()
        {

            var context = new EnrollmentContext();
            var course = context.Courses
                .Include("Enrollments")
                .FirstOrDefault(x => x.CourseId == 4);

            foreach (var item in course.Enrollments)
            {
                context.Entry(item).Reference(x => x.Student).Load();
                Console.WriteLine(item.Student.Name);
            }
        }

        static void Remove_Jack_Sparrow_From_CleanCode()
        {
            using (var context = new EnrollmentContext())
            {
                var student = context.Students
                    .Include("Enrollments")
                    .FirstOrDefault(s => s.StudentId == 4);

                var course = context.Courses
                    .Include("Enrollments")
                    .FirstOrDefault(c => c.CourseId == 4);

                var enrollment = student.Enrollments.FirstOrDefault(x => x.CourseId == course.CourseId);

                if (enrollment != null)
                {
                    course.Enrollments.Remove(enrollment);
                }
                context.SaveChanges();

            }
        }

        static void Enroll_Every_Student_In_Clean_Code_Course()
        {
            using (var context = new EnrollmentContext())
            {
                var students = context.Students.ToList();
                var cleanCode = context.Courses.Find(4);

                students.ForEach(s =>
                {
                    cleanCode.Enrollments.Add(new Enrollment { StudentId = s.StudentId, CourseId = cleanCode.CourseId });
                });

                context.SaveChanges();
            }
        }

        static void Seed()
        {
            using (var context = new EnrollmentContext())
            {

                if (!context.Instructors.Any())
                {

                    var instructors = new List<Instructor>()
                {
                    new Instructor { Name = "Uncle Bob"},
                    new Instructor { Name = "Martin Fowler"},
                    new Instructor { Name = "Kent Beck"}
                };

                    context.AddRange(instructors);
                }

                if (!context.Students.Any())
                {
                    var students = new List<Student>()
                {
                    new Student() { Name = "Taz Uddin"},
                    new Student() { Name = "Batman the Bat Man"},
                    new Student() { Name = "Popey The Sailor Man"},
                    new Student() { Name = "Jack Sparrow"},
                };
                    context.AddRange(students);
                }

                if (!context.Courses.Any())
                {
                    var courses = new List<Course>()
                {
                    new Course() { Title = "The future of programming", InstructorId = 1, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(30)},
                    new Course() { Title = "Making architecture matter", InstructorId = 2, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(30)},
                    new Course() { Title = "Extreme Programming in practice", InstructorId = 3, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(30)},
                    new Course() { Title = "Clean Code", InstructorId = 1, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(30)},
                };
                    context.AddRange(courses);
                }
                context.SaveChanges();
            }
        }

    }
}
