using BPieShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.Persistence
{
    public class PieShopDbContext : DbContext
    {
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<PieReview> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PieShopDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PieShopDbContext).Assembly);
        }

    }
}
