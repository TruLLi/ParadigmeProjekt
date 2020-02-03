using Microsoft.Extensions.Logging;
using Lambda3.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Vjezba2.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Vjezba2.Test
{
    public static class WebAppFactoryExt
    {
        public static async Task MigrateDbAndSeedAsync<TStartup>(this WebApplicationFactory<TStartup> webApplicationFactory) where TStartup : class
        {
            var services = webApplicationFactory.Host.Services;
            using (var scope = services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<DriverContext>();
                var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();
                await db.Database.EnsureCreatedAsync();
            }
        }

        public static WebApplicationFactory<TStartup> EnsureServerStarted<TStartup>(this WebApplicationFactory<TStartup> webApplicationFactory) where TStartup : class
        {
            webApplicationFactory.CreateDefaultClient();
            return webApplicationFactory;
        }
    }
}
