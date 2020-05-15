using EnrollmentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Persistence
{
    public class EnrollmentContextNoTrack : DbContext
    {
        public EnrollmentContextNoTrack()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        private readonly string _connString = "Server = (localdb)\\mssqllocaldb; Database=EnrollmentDb;";
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<CourseStat> CourseStats { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseConsoleLoggerFactory()
                .EnableSensitiveDataLogging()
                .UseSqlServer(_connString)
                ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnrollmentContext).Assembly);
        }
    }
}
