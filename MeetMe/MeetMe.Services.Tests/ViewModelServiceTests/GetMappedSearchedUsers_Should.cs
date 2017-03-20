using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Models.Search;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ViewModelServiceTests
{
    [TestFixture]
    public class GetMappedSearchedUsers_Should
    {
        [Test]
        public void CallMapperService_UsersCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new SearchUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
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
            viewModelService.GetMappedSearchedUsers(users, string.Empty);

            // Assert
            mockedMapperService.Verify(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>()), Times.Exactly(users.Count));
        }

        [Test]
        public void CallImageService_ByteArrayToImageUrlUsersCountTimes()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new SearchUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
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
            viewModelService.GetMappedSearchedUsers(users, string.Empty);

            // Assert
            mockedImageService.Verify(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>()), Times.Exactly(users.Count));
        }

        [Test]
        public void CallUserService_GetByIndentityIdOnce_WhenUserIdIsNotEmpty()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new SearchUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser();
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedFriendService = new Mock<IFriendService>();
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(new List<int>());

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
            string userId = "user-xx-id";

            // Act
            viewModelService.GetMappedSearchedUsers(users, userId);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(u => u == userId)), Times.Once);
        }

        [Test]
        public void NotCallUserService_GetByIndentityId_WhenUserIdIsEmpty()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new SearchUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
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
            viewModelService.GetMappedSearchedUsers(users, string.Empty);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void CallFriendService_GetAllUserFriendsIdsOnce_WhenUserIdIsNotEmpty()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new SearchUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedFriendService = new Mock<IFriendService>();
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(new List<int>());

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
            string userId = "user-xx-id";

            // Act
            viewModelService.GetMappedSearchedUsers(users, userId);

            // Assert
            mockedFriendService.Verify(x => x.GetAllUserFriendsIds(It.Is<int>(i => i == user.Id)), Times.Once);
        }

        [Test]
        public void NotCallFriendService_GetAllUserFriendsIds_WhenUserIdIsEmpty()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            var mappedUser = new SearchUserViewModel();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(mappedUser);
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
            viewModelService.GetMappedSearchedUsers(users, string.Empty);

            // Assert
            mockedFriendService.Verify(x => x.GetAllUserFriendsIds(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void SetCorrectIsFriend_WhenUserIdIsNotEmpty()
        {
            // Arrange
            var mockedMapperService = new Mock<IMapperService>();
            mockedMapperService.Setup(x => x.MapObject<SearchUserViewModel>(It.IsAny<CustomUser>())).Returns(() => new SearchUserViewModel());
            var mockedImageService = new Mock<IImageService>();
            mockedImageService.Setup(x => x.ByteArrayToImageUrl(It.IsAny<byte[]>())).Returns("some-url");
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedFriendService = new Mock<IFriendService>();
            mockedFriendService.Setup(x => x.GetAllUserFriendsIds(It.IsAny<int>())).Returns(new List<int>() { 2, 3 });

            var viewModelService = new ViewModelService(
                mockedMapperService.Object,
                mockedImageService.Object,
                mockedUserService.Object,
                mockedFriendService.Object);
            var users = new List<CustomUser>()
            {
                new CustomUser() { Id = 1, ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { Id = 2, ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } },
                new CustomUser() { Id = 3, ProfileImage = new ProfileImage() { Content = new byte[] { 1, 2 } } }
            };
            string userId = "user-xx-id";

            // Act
            var result = viewModelService.GetMappedSearchedUsers(users, userId);

            // Assert
            Assert.That(result.Where(x => x.IsFriend == true).Count() == 2);
        }
    }
}
