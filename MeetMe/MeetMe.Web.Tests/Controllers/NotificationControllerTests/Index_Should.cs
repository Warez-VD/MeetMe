using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Notifications;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.NotificationControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void RedirectWhenId_IsNull()
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

            // Act & Assert
            notificationController
                .WithCallTo(x => x.Index(null))
                .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Index"));
        }

        [Test]
        public void ReturnDefaultView_WhenIdIsNotNull()
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
            string id = "some-id";

            // Act & Assert
            notificationController
                .WithCallTo(x => x.Index(id))
                .ShouldRenderDefaultView()
                .WithModel<NotificationViewModel>();
        }
    }
}
