using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Profile;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedUserFriends_Should
    {
        [Test]
        public void CallImageService_ByteArrayToImageUrl()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedFriend = new ProfileFriendViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfileFriendViewModel>(It.IsAny<CustomUser>())).Returns(mappedFriend);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var friends = new List<CustomUser>()
            {
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 2, 3 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 3, 4 } } }
            };

            // Act
            viewModelService.GetMappedUserFriends(friends);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>()), Times.Exactly(friends.Count));
        }

        [Test]
        public void CallMapperService_FriendsCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedFriend = new ProfileFriendViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfileFriendViewModel>(It.IsAny<CustomUser>())).Returns(mappedFriend);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var friends = new List<CustomUser>()
            {
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 2, 3 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 3, 4 } } }
            };

            // Act
            viewModelService.GetMappedUserFriends(friends);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<ProfileFriendViewModel>(It.IsAny<CustomUser>()), Times.Exactly(friends.Count));
        }

        [Test]
        public void ReturnMappedUserFriendsInCorrectType()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedFriend = new ProfileFriendViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfileFriendViewModel>(It.IsAny<CustomUser>())).Returns(mappedFriend);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var friends = new List<CustomUser>()
            {
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 2, 3 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 3, 4 } } }
            };

            // Act
            var result = viewModelService.GetMappedUserFriends(friends);

            // Assert
            Assert.That(result.All(x => x.GetType().Name == "ProfileFriendViewModel"));
        }

        [Test]
        public void ReturnCorrectCountMappedUserFriends()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedFriend = new ProfileFriendViewModel();
            mockedMapperService.Setup(x => x.MapObject<ProfileFriendViewModel>(It.IsAny<CustomUser>())).Returns(mappedFriend);
            var mockedImageService = new Mock<IImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedFriendService = new Mock<IFriendService>();

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var friends = new List<CustomUser>()
            {
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 2, 3 } } },
                new CustomUser() { ProfileImage = new ProfileImage() { Content = new byte[] { 3, 4 } } }
            };

            // Act
            var result = viewModelService.GetMappedUserFriends(friends);

            // Assert
            Assert.AreEqual(result.Count(), 3);
        }
    }
}
