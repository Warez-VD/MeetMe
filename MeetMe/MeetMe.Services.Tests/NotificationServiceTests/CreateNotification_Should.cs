using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.NotificationServiceTests
{
    [TestFixture]
    public class CreateNotification_Should
    {
        [Test]
        public void CallDateTimeService_GetCurrentDateOnce()
        {
            // Arrange
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
            int userId = 10;
            string content = "some content";
            bool isFriendship = false;
            int targetId = 15;

            // Act
            notificationService.CreateNotification(userId, content, isFriendship, targetId);

            // Assert
            mockedDateTimeService.Verify(x => x.GetCurrentDate(), Times.Once);
        }

        [Test]
        public void CallNotificationFactory_CreateNotificationOnce()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var date = new DateTime(2017, 4, 20);
            mockedDateTimeService.Setup(x => x.GetCurrentDate()).Returns(date);
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);
            int userId = 10;
            string content = "some content";
            bool isFriendship = false;
            int targetId = 15;

            // Act
            notificationService.CreateNotification(userId, content, isFriendship, targetId);

            // Assert
            mockedNotificationFactory
                .Verify(
                    x => x.CreateNotification(
                        It.Is<int>(u => u == userId),
                        It.Is<string>(c => c == content),
                        It.Is<DateTime>(d => d == date),
                        It.Is<bool>(i => i == isFriendship),
                        It.Is<int>(t => t == targetId)),
                        Times.Once);
        }

        [Test]
        public void CallNotificationRepository_AddOnce()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var mockedDateTimeService = new Mock<IDateTimeService>();
            var mockedNotificationFactory = new Mock<INotificationFactory>();
            var notification = new Notification();
            mockedNotificationFactory
                .Setup(
                    x => x.CreateNotification(
                        It.IsAny<int>(),
                        It.IsAny<string>(),
                        It.IsAny<DateTime>(),
                        It.IsAny<bool>(),
                        It.IsAny<int>()))
                .Returns(notification);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedUserService = new Mock<IUserService>();

            var notificationService = new NotificationService(
                mockedNotificationRepository.Object,
                mockedDateTimeService.Object,
                mockedNotificationFactory.Object,
                mockedUnitOfWork.Object,
                mockedUserService.Object);
            int userId = 10;
            string content = "some content";
            bool isFriendship = false;
            int targetId = 15;

            // Act
            notificationService.CreateNotification(userId, content, isFriendship, targetId);

            // Assert
            mockedNotificationRepository.Verify(x => x.Add(It.Is<Notification>(n => n == notification)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
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
            int userId = 10;
            string content = "some content";
            bool isFriendship = false;
            int targetId = 15;

            // Act
            notificationService.CreateNotification(userId, content, isFriendship, targetId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
