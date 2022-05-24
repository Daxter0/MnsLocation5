using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MnsLocation5.Areas.Admin.Data;
using MnsLocation5.Areas.Borrower.Data;
using MnsLocation5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MnsLocation5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    ManagerContext contextAdmin = services.GetRequiredService<ManagerContext>();
                    ManagerDbInitializer.Initialize(contextAdmin);
                    Context userContext = services.GetRequiredService<Context>();
                    DbInitializer.Initialize(userContext);
                    //MnsLocation5Context mnsLocation5Context = services.GetRequiredService<MnsLocation5Context>();
                    //DbInitializer.Initialize(mnsLocation5Context);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
