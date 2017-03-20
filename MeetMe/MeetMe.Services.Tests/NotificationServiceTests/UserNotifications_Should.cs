using System;
using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.NotificationServiceTests
{
    [TestFixture]
    public class UserNotifications_Should
    {
        [Test]
        public void CallUserService_GetByIndentityIdOnce()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);
            int skip = 0;
            int count = 2;
            string userId = "user-xx-id";

            // Act
            notificationService.UserNotifications(skip, count, userId);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(u => u == userId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectNotifications_WhenSkipIsZero()
        {
            // Arrange
            int userid = 10;
            var expected = new List<Notification>()
            {
                new Notification() { TargetUserId = userid, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 20) },
                new Notification() { TargetUserId = userid, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 19) },
                new Notification() { TargetUserId = userid, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 18) }
            };
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var notifications = new List<Notification>()
            {
                new Notification() { TargetUserId = 15, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 22) }
            };
            notifications.AddRange(expected);
            mockedNotificationRepository.Setup(x => x.All).Returns(notifications.AsQueryable());
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = userid };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);
            int skip = 0;
            int count = 4;
            string userId = "user-xx-id";

            // Act
            var result = notificationService.UserNotifications(skip, count, userId);

            // Assert
            CollectionAssert.AreEqual(result, expected);
        }

        [Test]
        public void ReturnCorrectNotifications_WhenSkipIsSet()
        {
            // Arrange
            int userid = 10;
            var expected = new List<Notification>()
            {
                new Notification() { TargetUserId = userid, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 19) },
                new Notification() { TargetUserId = userid, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 18) }
            };
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var notifications = new List<Notification>()
            {
                new Notification() { TargetUserId = userid, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 20) }
            };
            notifications.AddRange(expected);
            notifications.Add(new Notification() { TargetUserId = 15, IsDeleted = false, CreatedOn = new DateTime(2017, 3, 22) });
            mockedNotificationRepository.Setup(x => x.All).Returns(notifications.AsQueryable());
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = userid };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);
            int skip = 1;
            int count = 4;
            string userId = "user-xx-id";

            // Act
            var result = notificationService.UserNotifications(skip, count, userId);

            // Assert
            CollectionAssert.AreEqual(result, expected);
        }

        [Test]
        public void ReturnEmptyCollection_WhenUserNotificationsNotFound()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 10 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);
            int skip = 1;
            int count = 4;
            string userId = "user-xx-id";

            // Act
            var result = notificationService.UserNotifications(skip, count, userId);

            // Assert
            CollectionAssert.AreEqual(result, new List<Notification>());
        }
    }
}
