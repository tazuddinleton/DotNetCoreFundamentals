using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
