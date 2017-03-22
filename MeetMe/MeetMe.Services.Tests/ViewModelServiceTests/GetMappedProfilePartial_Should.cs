using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Home;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedProfilePartial_Should
    {
        [Test]
        public void CallImageService_ByteArrayToImageUrlOnce()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedProfile = new ProfilePartialViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfilePartialViewModel>(It.IsAny<CustomUser>())).Returns(mappedProfile);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            byte[] profileImageContent = new byte[] { 1, 3, 5 };
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = profileImageContent } };

            // Act
            viewModelService.GetMappedProfilePartial(user);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(It.Is<byte[]>(c => c == profileImageContent)), Times.Once);
        }

        [Test]
        public void CallMapperService_MapObjectOnce()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedProfile = new ProfilePartialViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfilePartialViewModel>(It.IsAny<CustomUser>())).Returns(mappedProfile);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            byte[] profileImageContent = new byte[] { 1, 3, 5 };
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = profileImageContent } };

            // Act
            viewModelService.GetMappedProfilePartial(user);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<ProfilePartialViewModel>(It.Is<CustomUser>(u => u == user)), Times.Once);
        }

        [Test]
        public void ReturnCorrectResult()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedProfile = new ProfilePartialViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfilePartialViewModel>(It.IsAny<CustomUser>())).Returns(mappedProfile);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            byte[] profileImageContent = new byte[] { 1, 3, 5 };
            var user = new CustomUser() { ProfileImage = new ProfileImage() { Content = profileImageContent } };

            // Act
            var result = viewModelService.GetMappedProfilePartial(user);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, mappedProfile);
            Assert.IsInstanceOf<ProfilePartialViewModel>(result);
        }
    }
}
