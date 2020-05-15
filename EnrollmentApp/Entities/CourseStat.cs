using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class CourseStat
    {        
        public string Title { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
