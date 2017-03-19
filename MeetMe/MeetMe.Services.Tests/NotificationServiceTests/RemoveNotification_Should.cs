using NUnit.Framework;
using Moq;
using MeetMe.Services.Contracts;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;

namespace MeetMe.Services.Tests.NotificationServiceTests
{
    [TestFixture]
    public class RemoveNotification_Should
    {
        [Test]
        public void CallNotificationRepository_GetByIdOnce()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var notification = new Notification();
            mockedNotificationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(notification);
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
            int publicationId = 10;

            // Act
            notificationService.RemoveNotification(publicationId);

            // Assert
            mockedNotificationRepository.Verify(x => x.GetById(It.Is<int>(p => p == publicationId)), Times.Once);
        }

        [Test]
        public void CallNotificationRepository_UpdateOnce()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var notification = new Notification();
            mockedNotificationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(notification);
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
            int publicationId = 10;

            // Act
            notificationService.RemoveNotification(publicationId);

            // Assert
            mockedNotificationRepository.Verify(x => x.Update(It.Is<Notification>(n => n == notification && notification.IsDeleted == true)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedNotificationRepository = new Mock<IEFRepository<Notification>>();
            var notification = new Notification();
            mockedNotificationRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(notification);
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
            int publicationId = 10;

            // Act
            notificationService.RemoveNotification(publicationId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
