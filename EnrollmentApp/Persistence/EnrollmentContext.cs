using EnrollmentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnrollmentApp.Persistence
{
    public class EnrollmentContext : DbContext
    {
        private readonly string _connString = "Server = (localdb)\\mssqllocaldb; Database=EnrollmentDb;";
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseStat> CourseStats { get; set; }
        //public DbSet<CourseDetail> CourseDetails { get; set; }


        public EnrollmentContext()
        {

        }

        public EnrollmentContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    //.UseConsoleLoggerFactory()
                    //.EnableSensitiveDataLogging()
                    .UseSqlServer(_connString)
                    ;
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnrollmentContext).Assembly);
        }
    }
}
