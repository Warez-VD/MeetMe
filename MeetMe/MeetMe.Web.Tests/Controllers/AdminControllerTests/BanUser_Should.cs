using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class BanUser_Should
    {
        [Test]
        public void CallUserManager_AddToRoleOnce()
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
            adminController.BanUser(userId);

            // Assert
            mockedUserManager.Verify(x => x.AddToRoleAsync(userId, "banned"), Times.Once);
        }

        [Test]
        public void CallUserService_BanUserOnce()
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
            adminController.BanUser(userId);

            // Assert
            mockedUserService.Verify(x => x.BanUser(userId), Times.Once);
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
            adminController.WithCallTo(x => x.BanUser(userId))
                .ShouldReturnJson();
        }
    }
}
