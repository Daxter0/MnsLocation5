using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.Borrower.Data
{
    public class Context : DbContext
    {
        public DbSet<RentalCart> RentalCarts { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalCart>().ToTable("RentalCart");
           
        }
    }
}
