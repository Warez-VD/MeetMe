using System.Collections.Generic;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Notifications;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.NotificationControllerTests
{
    [TestFixture]
    public class RemoveAllNotifications_Should
    {
        [Test]
        public void ReturnPartialView_NotificationsPartial()
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

            // Act & Assert
            notificationController
                .WithCallTo(x => x.RemoveAllNotifications(userId))
                .ShouldRenderPartialView("_NotificationsPartial")
                .WithModel<IEnumerable<NotificationUserViewModel>>();
        }
    }
}
