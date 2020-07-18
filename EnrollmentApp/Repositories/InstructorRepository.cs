using EnrollmentApp.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Repositories
{
    public class InstructorRepository
    {
        private readonly EnrollmentContext _context;
        public InstructorRepository()
        {
            _context = new EnrollmentContext();
        }

        public InstructorRepository(EnrollmentContext context)
        {
            _context = context;
        }


    }
}
