using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            Enrollments = new List<Enrollment>();
        }

    }
}
