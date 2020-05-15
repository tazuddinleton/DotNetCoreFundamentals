using EnrollmentApp.Entities;
using EnrollmentApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnrollmentApp.EntityFrameworkFeatures.ViewStoredProceduresRawSql
{
    public static class TestCourseStatView
    {
        public static void DisplayFromCourseView()
        {
            using (var context = new EnrollmentContext())
            {
                var stats = context.CourseStats.ToList();
                stats.ForEach(st => Console.WriteLine(st.Title));
            }
        }
    }
}
