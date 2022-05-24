using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MnsLocation5.Areas.Identity.Data;
using MnsLocation5.Data;

[assembly: HostingStartup(typeof(MnsLocation5.Areas.Identity.IdentityHostingStartup))]
namespace MnsLocation5.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MnsLocation5Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<MnsLocation5User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MnsLocation5Context>();
            });
        }
    }
}