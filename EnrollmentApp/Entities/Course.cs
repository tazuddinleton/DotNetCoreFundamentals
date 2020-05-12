using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Instructor Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        public Course()
        {
            Enrollments = new List<Enrollment>();
        }

    }
}
