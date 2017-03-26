using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class UnbanUser_Should
    {
        [Test]
        public void CallUserManager_RemoveFromRoleOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);
            string userId = "user-id-xx";

            // Act
            adminController.UnbanUser(userId);

            // Assert
            mockedUserManager.Verify(x => x.RemoveFromRoleAsync(userId, "banned"), Times.Once);
        }

        [Test]
        public void CallUserService_UnbanUserOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);
            string userId = "user-id-xx";

            // Act
            adminController.UnbanUser(userId);

            // Assert
            mockedUserService.Verify(x => x.UnbanUser(userId), Times.Once);
        }

        [Test]
        public void ReturnJsonAsResult()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);
            string userId = "user-id-xx";

            // Act & Assert
            adminController.WithCallTo(x => x.UnbanUser(userId))
                .ShouldReturnJson();
        }
    }
}
