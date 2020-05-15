using EnrollmentApp.Entities;
using EnrollmentApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnrollmentApp.EntityFrameworkFeatures.ViewStoredProceduresRawSql
{
    public static class TestViewsStoredProcedures
    {
        public static void DisplayFromCourseView()
        {
            using (var context = new EnrollmentContext())
            {
                var stats = context.CourseStats.ToList();
                stats.ForEach(st => Console.WriteLine(st.Title));
            }
        }

        public static void RunRawSql()
        {
            using (var context = new EnrollmentContext())
            {
                var stats = context.CourseStats.FromSqlRaw("Select * from CourseStat").ToList();
                stats.ForEach(st => Console.WriteLine(st.Title));

                var id = 2;
                stats = context.CourseStats.FromSqlRaw("Select * from CourseStat WHERE CourseId = {0}", id).ToList();
                
                stats.ForEach(st => Console.WriteLine(st.Title));
            }
        }

        public static void RunRawSqlInterpolated()
        {
            using (var context = new EnrollmentContext())
            {
                var stats = context.CourseStats.FromSqlInterpolated($"Select * from CourseStat WHERE CourseId={2}").ToList();
                stats.ForEach(st => Console.WriteLine(st.Title));
            }
        }

        public static void GetCourseDetailByInstructor(int id)
        {
            using (var context = new EnrollmentContext())
            {
                //var stats = context.CourseDetails
                //    .FromSqlRaw("EXEC GetCourseByInstructor {0}", id)
                //    .ToList();
                //stats.ForEach(st => Console.WriteLine($"{st.Title} - by {st.Name}, Number of students:  {st.NumOfEnrolledStudents}"));

                var stats = context.Set<CourseDetail>()
                    .FromSqlRaw("EXEC GetCourseByInstructor {0}", id)
                    .ToList();
                stats.ForEach(st => Console.WriteLine($"{st.Title} - by {st.Name}, Number of students:  {st.NumOfEnrolledStudents}"));
            }
        }
    }
}
