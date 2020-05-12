using EnrollmentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Persistence.Configurations
{
    class CourseConfigurations : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.StartDate)
                .HasColumnType("datetime");
            builder.Property(c => c.EndDate)
                .HasColumnType("datetime");
        }
    }
}
