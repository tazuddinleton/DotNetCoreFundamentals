using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Persistence.Configurations
{
    public class TaskConfigurations : IEntityTypeConfiguration<Domain.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Task> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);
            modelBuilder.Property(c => c.Id).HasField("_id");
            modelBuilder.Property(c => c.Title).HasField("_title");
            modelBuilder.Property(c => c.Description).HasField("_description");
            modelBuilder.Property(c => c.ActualStartDate).HasField("_actualStartDate");
            modelBuilder.Property(c => c.ActualEndDate).HasField("_actualEndDate");
            modelBuilder.Property(c => c.PlannedStartDate).HasField("_plannedStartDate");
            modelBuilder.Property(c => c.PlannedEndDate).HasField("_plannedEndDate");

            modelBuilder.Property(c => c.AssignedTo).HasField("_assignedTo");
            modelBuilder.Property(c => c.Status).HasField("_status");
            modelBuilder.Property(c => c.Priority).HasField("_priority");
            modelBuilder.Property(c => c.ActualEndDate).HasField("_actualEndDate");
            modelBuilder.Property(c => c.Owner).HasField("_owner");
            modelBuilder.Property(c => c.EntryDate).HasField("_entryDate");
        }
    }
}
