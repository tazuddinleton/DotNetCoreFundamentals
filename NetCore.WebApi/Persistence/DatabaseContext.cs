using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.WebApi.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext()
        { 
        
        }

        public DbSet<Domain.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-O2E45CT;Database=TaskManagement;Trusted_Connection=True;user id=sa;password=1234;");
            base.OnConfiguring(optionsBuilder);
        }

        
    }
}
