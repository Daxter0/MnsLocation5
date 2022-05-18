using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.AdminArea.Data
{
    public class AdminManagerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> Types { get; set; }
        public AdminManagerContext(DbContextOptions<AdminManagerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<MaterialType>().ToTable("Type");
        }
    }
}
