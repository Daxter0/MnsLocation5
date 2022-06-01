using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialType { get; set; }
        public DbSet<RentalCart> RentalCarts { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>().ToTable("Materials");
            modelBuilder.Entity<MaterialType>().ToTable("MaterialType");
            modelBuilder.Entity<RentalCart>().ToTable("RentalCarts");
            modelBuilder.Entity<Rent>().ToTable("Rents");

        }
    }
}
