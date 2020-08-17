using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Schedule
    {

        public Schedule()
        {
            Instances = new HashSet<Instance>();
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Instance> Instances { get; set; }
    }
}
