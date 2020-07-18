using EnrollmentApp.Entities;
using EnrollmentApp.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentAppTests
{
 
    [TestFixture]
    public class InMemoryTests
    {
        [Test]
        public void CanInsertInstructorIntoDatabse()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("InstructorDb");
            using (var context = new EnrollmentContext(builder.Options))
            {
                var instructor = new Instructor();
                context.Instructors.Add(instructor);
                Assert.AreEqual(EntityState.Added, context.Entry(instructor).State);
            }

        }
    }
}
