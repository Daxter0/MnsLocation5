using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.UserArea.Data
{
    public class BorrowerContext : DbContext
    {
        public DbSet<RentalCart> RentalCarts { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public BorrowerContext(DbContextOptions<BorrowerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalCart>().ToTable("RentalCart");
           
        }
    }
}
