using Lambda3.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Vjezba2.Test
{
    public abstract class BaseIntegration
    {
        private IServiceScope scope;
        protected IServiceProvider serviceProvider;
        protected HttpClient client;

        public static WebApplicationFactory<Startup> WebAppFactory { get; set; }

        [OneTimeSetUp]
        public void BaseIntegrationTestOneTimeSetUp()
        {
            client = WebAppFactory.CreateDefaultClient();
            scope = WebAppFactory.Host.Services.CreateScope();
            serviceProvider = scope.ServiceProvider;
        }

        [OneTimeTearDown]
        public void BaseIntegrationTestOneTimeTearDown() => scope.Dispose();
    }
}
