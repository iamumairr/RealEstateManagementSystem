using Microsoft.EntityFrameworkCore;
using RealEstateManagementSystem.Models;

namespace RealEstateManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Home>? Homes { get; set; }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Category>? Categories { get; set; }
    }
}
