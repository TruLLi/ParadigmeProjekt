using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using Vjezba2.Models;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using System.Net.Http;
using System.Linq;

namespace Vjezba2.Test.IntegrationTests
{
    class DriverController : BaseIntegration
    {

        // GET ALL Test
        [Test]
        public async Task GetNotFound()
        {
            var repository = serviceProvider.GetService<IDriversRepository>();
            var allDrivers = await repository.GetAll();
            foreach (var driver in allDrivers)
                await repository.Delete(driver.Id);
            var response = await client.GetAsync("/api/drivers/3");
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NotFound);
        }


    }

    class DriverControllerGETTest : BaseIntegration
    {

        private IDriversRepository repository;
        private HttpResponseMessage response;
        private Driver driver;

        [OneTimeSetUp]
        public async Task Setup()
        {
            repository = serviceProvider.GetService<IDriversRepository>();
            var allDrivers = await repository.GetAll();

            foreach (var d in allDrivers)
                await repository.Delete(d.Id);

            driver = DriverGenerator.Driver;
            await repository.Create(driver);

            response = await client.GetAsync($"/api/drivers/{driver.Id}");
        }

        [Test]
        public async Task DriverFound()
        {
            var driverReturned = await response.Content.ReadAsAsync<Driver>();
            driverReturned.Should().BeEquivalentTo(driver);
        }


    }

    class DriverControllerPOSTTest : BaseIntegration
    {
        private IDriversRepository repository;
        private HttpResponseMessage response;
        private Driver driver;

        [OneTimeSetUp]
        public async Task Setup()
        {
            repository = serviceProvider.GetService<IDriversRepository>();
            var allDrivers = await repository.GetAll();

            foreach (var d in allDrivers)
                await repository.Delete(d.Id);

            driver = DriverGenerator.Driver;
            await repository.Create(driver);

            response = await client.PostAsJsonAsync($"/api/drivers/",driver);
        }

        [Test]
        public async Task OnlyOneItemIsInDb() => (await repository.GetAll()).Count().Should().Be(1);



    }
}