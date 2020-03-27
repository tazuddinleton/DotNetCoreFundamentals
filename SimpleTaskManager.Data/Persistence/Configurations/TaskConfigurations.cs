using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManager.Data.Persistence.Configurations
{
    public class TaskConfigurations : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> modelBuilder)
        {
            modelBuilder.HasKey(x => x.TaskId);
            modelBuilder.Property(p => p.TaskId).ValueGeneratedOnAdd();

            modelBuilder.HasData(
                new Task()
                {
                    TaskId = 1,
                    Title = "Test 1",
                    Description = "Description 1",
                    AssignedById = null,
                    AssignedToId = null,
                    CreatedAt = DateTime.Now,
                    CreatedById = 1,
                    LastUpdated = DateTime.Now,
                    Priority = TaskPriority.Normal,
                    Status = TaskStatus.Pending
                });

            modelBuilder.HasData(
           new Task()
           {
               TaskId = 2,
               Title = "Test 2",
               Description = "Description 2",
               AssignedById = null,
               AssignedToId = null,
               CreatedAt = DateTime.Now,
               CreatedById = 1,
               LastUpdated = DateTime.Now,
               Priority = TaskPriority.Normal,
               Status = TaskStatus.Pending
           });

            modelBuilder.HasData(
           new Task()
           {
               TaskId = 3,
               Title = "Test 3",
               Description = "Description 3",
               AssignedById = null,
               AssignedToId = null,
               CreatedAt = DateTime.Now,
               CreatedById = 1,
               LastUpdated = DateTime.Now,
               Priority = TaskPriority.Normal,
               Status = TaskStatus.Pending
           });
        }
    }
}
