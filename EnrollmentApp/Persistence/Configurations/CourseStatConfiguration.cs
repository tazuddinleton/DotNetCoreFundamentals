using EnrollmentApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Persistence.Configurations
{
    public class CourseStatConfiguration : IEntityTypeConfiguration<CourseStat>

    {
        public void Configure(EntityTypeBuilder<CourseStat> builder)
        {
            builder.HasNoKey().ToView("CourseStat");
        }
    }
}
