using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Notifications;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.NotificationControllerTests
{
    [TestFixture]
    public class AcceptFriendship_Should
    {
        [Test]
        public void ReturnPartialView_NotificationsPartial()
        {
            // Arrange
            var mockedNotificationService = new Mock<INotificationService>();
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var users = new List<NotificationUserViewModel>()
            {
                new NotificationUserViewModel(),
                new NotificationUserViewModel()
            };
            mockedViewModelService.Setup(x => x.GetMappedUserNotifications(It.IsAny<IEnumerable<Notification>>())).Returns(users);

            var notificationController = new NotificationController(
                mockedNotificationService.Object,
                mockedStatisticService.Object,
                mockedUserService.Object,
                mockedViewModelService.Object);
            string id = "some-id";
            int authorId = 21;
            int notificationId = 11;

            // Act & Assert
            notificationController
                .WithCallTo(x => x.AcceptFriendship(id, authorId, notificationId))
                .ShouldRenderPartialView("_NotificationsPartial")
                .WithModel<IEnumerable<NotificationUserViewModel>>(m => 
                {
                    Assert.AreEqual(users, m);
                });
        }
    }
}
