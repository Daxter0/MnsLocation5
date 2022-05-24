using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.Admin.Data
{
    public class ManagerContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> Types { get; set; }
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material");
            
            modelBuilder.Entity<MaterialType>().ToTable("Type");
        }
    }
}
