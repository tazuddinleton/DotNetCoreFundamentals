using Microsoft.EntityFrameworkCore;
using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Persistence
{
    public class TaskManagerContext : DbContext
    {



        public DbSet<Task> Tasks { get; set; }

        public TaskManagerContext(DbContextOptions<TaskManagerContext> options): base(options)
        { 
            
        }
        public TaskManagerContext()
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimpleTaskManagerDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
