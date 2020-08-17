using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Instance
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public DateTime Date { get; set; }

        public Schedule Schedule { get; set; }
    }
}
