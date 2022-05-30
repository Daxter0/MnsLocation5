using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MnsLocation5.Data;
using MnsLocation5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnsLocation5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // services.AddDbContext<UserContext>(options =>
           //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
           //);
            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
            services.AddRazorPages();
            services.AddControllersWithViews();
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

           services.AddIdentity<User, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding customs roles : Question 1
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Borrower" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 2
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();


            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapAreaControllerRoute(

                name: "Admin",
                areaName: "Identity",
                pattern: "{area=Identity}/{controller=Account}/{action=Login}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=Index1}/{id?}"
                );
            });
            CreateRoles(serviceProvider).Wait();
        }
    }
}
