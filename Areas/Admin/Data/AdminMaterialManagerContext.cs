using Microsoft.EntityFrameworkCore;
using MnsLocation5.Models;

namespace MnsLocation5.Areas.Admin.Data
{
    public class AdminMaterialManagerContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public AdminMaterialManagerContext(DbContextOptions<AdminMaterialManagerContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material");
        }
    }
}
