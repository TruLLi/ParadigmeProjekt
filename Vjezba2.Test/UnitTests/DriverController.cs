using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vjezba2.Controllers;
using Vjezba2.Models;
using Vjezba2.Test;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class Tests
    {
        [Test]
        public async Task GetDrivers_AllDrivers_Succeeds()
        {
            // Arrange
            var driversRepositoryMock = new Mock<IDriversRepository>();
            var expectedDrivers = new List<Driver>();

            driversRepositoryMock.Setup(d => d.GetAll()).ReturnsAsync(expectedDrivers);
            var driversController = new DriversController(driversRepositoryMock.Object);

            // Act
            var driverRetrieved = await driversController.GetDriver();

            // Assert
            ((OkObjectResult)driverRetrieved.Result).Value.Should().BeSameAs(expectedDrivers);
        }

        [Test]
        public async Task GetDriver_OneDriver_Succeeds()
        {
            // Arrange
            Driver driver = DriverGenerator.Driver;
            var driversController = new DriversController(Mock.Of<IDriversRepository>(pr => pr.Get(1) == Task.FromResult(driver)));

            // Act
            var driverRetrieved = await driversController.GetDriver(1);

            // Assert
            driverRetrieved.Value.Should().Be(driver);
        }

        [Test]
        public async Task PostDriver_ReturnsDriver_Succeeds()
        {
            // Arrange
            var driversRepositoryMock = new Mock<IDriversRepository>();
            Driver driver = DriverGenerator.Driver;
            driversRepositoryMock.Setup(pr => pr.Create(driver)).ReturnsAsync(true);
            var driversController = new DriversController(driversRepositoryMock.Object);

            // Act
            var result = await driversController.Post(driver);

            // Assert
            ((CreatedAtActionResult)result.Result).Value.Should().Be(driver);
        }
    }
}