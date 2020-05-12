﻿using EnrollmentApp.Entities;
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

            Display_Students_Of_Course_CleanCode();
            
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