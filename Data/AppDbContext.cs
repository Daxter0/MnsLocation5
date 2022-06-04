using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> Types { get; set; }
        public DbSet<RentalCart> RentalCarts { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentValidation> RentValidations { get; set; }
        public DbSet<HistoricUser> HistoricUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<MaterialType>().ToTable("Type");
            modelBuilder.Entity<RentalCart>().ToTable("RentalCart");
            modelBuilder.Entity<Rent>().ToTable("Rent");
            modelBuilder.Entity<RentValidation>().ToTable("RentValidation");
            modelBuilder.Entity<HistoricUser>().ToTable("HistoricUser");


        }
    }
}
