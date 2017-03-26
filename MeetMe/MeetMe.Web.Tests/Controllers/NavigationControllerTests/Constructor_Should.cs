using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.NavigationControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_StatisticServiceIsNull()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NavigationController(
                null,
                mockedMapperService.Object));

            // Assert
            Assert.That(ex.Message.Contains("StatisticService"));
        }

        [Test]
        public void ThrowsWhen_MapperServiceIsNull()
        {
            // Arrange
            var mockedStatisticService = new Mock<IStatisticService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NavigationController(
                mockedStatisticService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("MapperService"));
        }

        [Test]
        public void ReturnInstanceOfNavigationController_Correct()
        {
            // Arrange
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedMapperService = new Mock<IMapperService>();

            // Act
            var navigationController = new NavigationController(
                mockedStatisticService.Object,
                mockedMapperService.Object);

            // Assert
            Assert.IsNotNull(navigationController);
            Assert.IsInstanceOf<NavigationController>(navigationController);
        }
    }
}
