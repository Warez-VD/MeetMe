using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Profile;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.ProfileControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 2 };
            mockedUserService.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);

            var mockedFriendService = new Mock<IFriendService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var model = new ProfileViewModel() { Friends = new List<ProfileFriendViewModel>() };
            mockedViewModelService.Setup(x => x.GetMappedProfile(It.IsAny<CustomUser>())).Returns(model);
            
            var profileController = new ProfileController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedFriendService.Object,
                mockedViewModelService.Object);
            int id = 4;

            // Act & Assert
            profileController
                .WithCallTo(x => x.Index(id))
                .ShouldRenderDefaultView()
                .WithModel<ProfileViewModel>(x => 
                {
                    Assert.AreEqual(model, x);
                });
        }
    }
}
