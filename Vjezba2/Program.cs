using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vjezba2.Models;

namespace Vjezba2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();
            var env = host.Services.GetRequiredService<IHostingEnvironment>();
            if (env.IsDevelopment())
            {
                using (var scope = host.Services.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DriverContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<Startup>>();
                    db.Database.EnsureCreated();
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
