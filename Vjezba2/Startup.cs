using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metrics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vjezba2.Models;

namespace Vjezba2
{
    public class Startup
    {
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            this.env = env;

            Metric.Config.WithHttpEndpoint("http://localhost:12345/")
                .WithInternalMetrics()
                .WithReporting(config => config
                    .WithCSVReports(@"c:\temp\reports\", TimeSpan.FromSeconds(30))
                    .WithConsoleReport(TimeSpan.FromSeconds(30))
                    .WithTextFileReport(@"C:\temp\reports\metrics.txt", TimeSpan.FromSeconds(30))
                );
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IDriversRepository, DriversRepository>();
            if (env.IsEnvironment("Test"))
            {
                services.AddEntityFrameworkInMemoryDatabase();
                services.AddDbContext<DriverContext>(options => options.UseInMemoryDatabase("InMemoryDbForTesting"));
            }
            else
            {
                services.AddDbContext<DriverContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DriverContext")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsEnvironment("Test")){}
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
