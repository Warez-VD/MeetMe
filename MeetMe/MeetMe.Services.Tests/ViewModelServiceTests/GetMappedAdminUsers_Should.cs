using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Admin;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedAdminUsers_Should
    {
        [Test]
        public void CallMapperService_UsersCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new DashboardViewModel();
            mockedMapperService.Setup(x => x.MapObject<DashboardViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var users = new List<CustomUser>()
            {
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }
            };

            // Act
            viewModelService.GetMappedAdminUsers(users);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<DashboardViewModel>(It.IsAny<CustomUser>()), Times.Exactly(users.Count));
        }
    }
}
