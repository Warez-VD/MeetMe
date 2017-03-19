using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MeetMe.Services.Contracts;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;

namespace MeetMe.Services.Tests.NotificationServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_NotificationRepositoryIsNull()
        {
            // Arrange
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationService(
                null,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object));

            // Assert
            Assert.That(ex.Message.Contains("NotificationRepository"));
        }

        [Test]
        public void ThrowsWhen_DateTimeServiceIsNull()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationService(
                mockedNotificationRepository.Object,
                null,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object));

            // Assert
            Assert.That(ex.Message.Contains("DateTimeService"));
        }

        [Test]
        public void ThrowsWhen_NotificationFactoryIsNull()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                null,
                mockedUnitOfWork.Object,
                mockedUserService.Object));

            // Assert
            Assert.That(ex.Message.Contains("NotificationFactory"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                null,
                mockedUserService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ReturnInstanceOfAccountService_Correct()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            // Act
            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);

            // Assert
            Assert.IsNotNull(notificationService);
            Assert.IsInstanceOf<NotificationService>(notificationService);
        }
    }
}
