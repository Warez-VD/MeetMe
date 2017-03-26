using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Auth.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Admin;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallUserService_GetAllUsersOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);

            // Act
            adminController.Index();

            // Assert
            mockedUserService.Verify(x => x.GetAllUsers(), Times.Once);
        }

        [Test]
        public void CallViewModelService_GetMappedAdminUsers_WithAllUsers()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var users = new List<CustomUser>()
            {
                new CustomUser(),
                new CustomUser()
            };
            mockedUserService.Setup(x => x.GetAllUsers()).Returns(users);

            var mockedViewModelService = new Mock<IViewModelService>();
            var mockedUserManager = new Mock<IUserManager>();

            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);

            // Act
            adminController.Index();

            // Assert
            mockedViewModelService.Verify(x => x.GetMappedAdminUsers(users), Times.Once);
        }

        [Test]
        public void ReturnDefaultView_WithMappedAdminUsers()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var users = new List<DashboardViewModel>()
            {
                new DashboardViewModel(),
                new DashboardViewModel()
            };
            mockedViewModelService.Setup(x => x.GetMappedAdminUsers(It.IsAny<IEnumerable<CustomUser>>())).Returns(users);
            var mockedUserManager = new Mock<IUserManager>();

            var adminController = new AdminController(
                mockedUserService.Object,
                mockedViewModelService.Object,
                mockedUserManager.Object);

            // Act & Assert
            adminController.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel(users);
        }
    }
}
