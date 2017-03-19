using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.NotificationServiceTests
{
    [TestFixture]
    public class RemoveAllNotifications_Should
    {
        [Test]
        public void CallNotificationRepository_UpdateUserNotificationsCountTimes()
        {
            // Arrange
            string userId = "user-xx-id";
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var notifications = new List<Notification>()
            {
                new Notification() { User = new CustomUser() { AspIdentityUserId = userId }, IsDeleted = false },
                new Notification() { User = new CustomUser() { AspIdentityUserId = userId }, IsDeleted = false },
                new Notification() { User = new CustomUser() { AspIdentityUserId = userId }, IsDeleted = true },
                new Notification() { User = new CustomUser() { AspIdentityUserId = "other-id" }, IsDeleted = false }
            }.AsQueryable();
            mockedNotificationRepository.Setup(x => x.All).Returns(notifications);
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);

            // Act
            notificationService.RemoveAllNotifications(userId);

            // Assert
            mockedNotificationRepository.Verify(x => x.Update(It.Is<Notification>(i => i.IsDeleted == true)), Times.Exactly(2));
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            string userId = "user-xx-id";
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);

            // Act
            notificationService.RemoveAllNotifications(userId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
