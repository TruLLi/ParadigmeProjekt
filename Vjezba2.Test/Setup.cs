using Lambda3.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba2.Test
{
    [SetUpFixture]
    public class Setup
    {
        private WebApplicationFactory<Startup> webAppFactory;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            StartApiServer();
            BaseIntegration.WebAppFactory = webAppFactory;
            await webAppFactory.MigrateDbAndSeedAsync();
        }

        private void StartApiServer() => webAppFactory = new WebApplicationFactory<Startup>(inMemory: true).EnsureServerStarted();

        [OneTimeTearDown]
        public void OneTimeTearDown() => webAppFactory?.Dispose();
    }
}
