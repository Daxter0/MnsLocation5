using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MnsLocation5.Areas.Identity.Data;
using MnsLocation5.Areas.Identity.Models;

namespace MnsLocation5.Data
{
    public class MnsLocation5Context : IdentityDbContext<MnsLocation5User>
    {
        public DbSet<BorrowerTable> Borrowers { get; set; }
        public DbSet<Administrator> Admins { get; set; }
        public MnsLocation5Context(DbContextOptions<MnsLocation5Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BorrowerTable>().ToTable("Borrower");
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
