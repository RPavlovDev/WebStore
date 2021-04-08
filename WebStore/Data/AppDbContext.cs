using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;
using WebStore.Models;

namespace WebStore.Data
{
    public class AppDbContext : DbContext
    {
        public int SectionId { get; set; }
        public int BrandId { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.BrandId == this.BrandId);
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.SectionId == this.SectionId);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
