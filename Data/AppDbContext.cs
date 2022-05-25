using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> Types { get; set; }
        public DbSet<RentalCart> RentalCarts { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material");

            modelBuilder.Entity<MaterialType>().ToTable("Type");
            modelBuilder.Entity<RentalCart>().ToTable("RentalCarts");
            modelBuilder.Entity<Rent>().ToTable("Rents");

        }
    }
}
