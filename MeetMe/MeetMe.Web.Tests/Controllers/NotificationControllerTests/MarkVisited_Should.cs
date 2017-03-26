using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.NotificationControllerTests
{
    [TestFixture]
    public class MarkVisited_Should
    {
        [Test]
        public void CallStatisticService_MarkAsVisitedNotificationsOnce()
        {
            // Arrange
            var mockedNotificationService = new Mock<INotificationService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            var notificationController = new NotificationController(
                mockedNotificationService.Object,
                mockedStatisticService.Object,
                mockedUserService.Object,
                mockedViewModelService.Object);
            string userId = "some-id";

            // Act
            notificationController.MarkVisited(userId);

            // Assert
            mockedStatisticService.Verify(x => x.MarkAsVisitedNotifications(userId), Times.Once);
        }
    }
}
