using EmpireHomes_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpireHomes_BE
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
