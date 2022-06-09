using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;
using System;

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
        public DbSet<MaterialRentalCart> MaterialRentalCarts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<MaterialType>().ToTable("Type");
            modelBuilder.Entity<Rent>().ToTable("Rent");
            modelBuilder.Entity<RentalCart>().ToTable("RentalCart");
            modelBuilder.Entity<RentValidation>().ToTable("RentValidation");
            modelBuilder.Entity<HistoricUser>().ToTable("HistoricUser");
            modelBuilder.Entity<Material>().HasMany(x => x.RentalCarts)
                .WithMany(x => x.ChoosenMaterials)
                .UsingEntity<MaterialRentalCart>(
                    x => x.HasOne(x => x.RentalCart)
                    .WithMany().HasForeignKey(x => x.RentalCartID),
                    x => x.HasOne(x => x.Material)
                   .WithMany().HasForeignKey(x => x.MaterialID));

        }

    }
}
