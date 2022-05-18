using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.UserArea.Data
{
    public class UserContext : DbContext
    {
        public DbSet<RentalCart> RentalCarts { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalCart>().ToTable("RentalCart");
           
        }
    }
}
