using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.NotificationControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_NotificationServiceIsNull()
        {
            // Arrange
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationController(
                null,
                mockedStatisticService.Object,
                mockedUserService.Object,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("NotificationService"));
        }

        [Test]
        public void ThrowsWhen_StatisticServiceIsNull()
        {
            // Arrange
            var mockedNotificationService = new Mock<INotificationService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationController(
                mockedNotificationService.Object,
                null,
                mockedUserService.Object,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("StatisticService"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedNotificationService = new Mock<INotificationService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationController(
                mockedNotificationService.Object,
                mockedStatisticService.Object,
                null,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedNotificationService = new Mock<INotificationService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationController(
                mockedNotificationService.Object,
                mockedStatisticService.Object,
                mockedUserService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ReturnInstanceOfNotificationController_Correct()
        {
            // Arrange
            var mockedNotificationService = new Mock<INotificationService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var notificationController = new NotificationController(
                mockedNotificationService.Object,
                mockedStatisticService.Object,
                mockedUserService.Object,
                mockedViewModelService.Object);

            // Assert
            Assert.IsNotNull(notificationController);
            Assert.IsInstanceOf<NotificationController>(notificationController);
        }
    }
}
