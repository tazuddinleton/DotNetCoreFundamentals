using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }        
        public List<Course> Courses { get; set; }

    }
}
