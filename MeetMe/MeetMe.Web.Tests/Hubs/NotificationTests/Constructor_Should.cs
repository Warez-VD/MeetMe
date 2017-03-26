using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Hubs.NotificationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_FriendsRepositoryIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedNotificationService = new Mock<INotificationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Web.Hubs.Notification(
                null,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedPublicationService.Object,
                mockedNotificationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("FriendsRepository"));
        }

        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedNotificationService = new Mock<INotificationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Web.Hubs.Notification(
                mockedFriendsRepository.Object,
                null,
                mockedStatisticService.Object,
                mockedPublicationService.Object,
                mockedNotificationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_StatisticServiceIsNull()
        {
            // Arrange
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedNotificationService = new Mock<INotificationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Web.Hubs.Notification(
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                null,
                mockedPublicationService.Object,
                mockedNotificationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("StatisticService"));
        }

        [Test]
        public void ThrowsWhen_PublicationServiceIsNull()
        {
            // Arrange
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedNotificationService = new Mock<INotificationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Web.Hubs.Notification(
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                null,
                mockedNotificationService.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationService"));
        }

        [Test]
        public void ThrowsWhen_NotificationServiceIsNull()
        {
            // Arrange
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedPublicationService = new Mock<IPublicationService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new Web.Hubs.Notification(
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedPublicationService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("NotificationService"));
        }

        [Test]
        public void ReturnInstanceOfNotification_Correct()
        {
            // Arrange
            var mockedFriendsRepository = new Mock<IEFRepository<UserFriend>>();
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedNotificationService = new Mock<INotificationService>();

            // Act
            var notification = new Web.Hubs.Notification(
                mockedFriendsRepository.Object,
                mockedUserService.Object,
                mockedStatisticService.Object,
                mockedPublicationService.Object,
                mockedNotificationService.Object);

            // Assert
            Assert.IsNotNull(notification);
            Assert.IsInstanceOf<Web.Hubs.Notification>(notification);
        }
    }
}
