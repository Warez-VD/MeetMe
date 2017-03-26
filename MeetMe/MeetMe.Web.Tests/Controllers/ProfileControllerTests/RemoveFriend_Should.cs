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
    public class RemoveFriend_Should
    {
        [Test]
        public void ReturnPartialView_ProfileFriendsPartial()
        {
            // Arrange
            var mockedAccountService = new Mock<IAccountService>();
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);

            var mockedFriendService = new Mock<IFriendService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var model = new ProfileViewModel() { Friends = new List<ProfileFriendViewModel>() };
            mockedViewModelService.Setup(x => x.GetMappedProfile(It.IsAny<CustomUser>())).Returns(model);

            var profileController = new ProfileController(
                mockedAccountService.Object,
                mockedUserService.Object,
                mockedFriendService.Object,
                mockedViewModelService.Object);
            int id = 3;
            string userId = "user-id";

            // Act & Assert
            profileController
                .WithCallTo(x => x.RemoveFriend(id, userId))
                .ShouldRenderPartialView("_ProfileFriendsPartial")
                .WithModel<ProfileViewModel>(m =>
                {
                    Assert.AreEqual(model, m);
                });
        }
    }
}
