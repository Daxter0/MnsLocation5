using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.Admin.Data
{
    public class AdminAccountManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AdminAccountManagerContext(DbContextOptions<AdminAccountManagerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
