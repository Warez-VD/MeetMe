using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class AddFriend_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            // Arrange
            string userId = "some-xx-id";
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var friendUser = new CustomUser();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(friendUser);
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var users = new List<CustomUser>() { new CustomUser() { AspIdentityUserId = userId } }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object);
            int friendId = 12;

            // Act
            userService.AddFriend(userId, friendId);

            // Assert
            mockedUserRepository.Verify(x => x.GetById(It.Is<int>(i => i == friendId)), Times.Once);
        }

        [Test]
        public void CallFriendService_AddFriendshipOnce()
        {
            // Arrange
            string userId = "some-xx-id";
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var friendUser = new CustomUser() { AspIdentityUserId = "other-xx-id" };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(friendUser);
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var user = new CustomUser() { Id = 12, AspIdentityUserId = userId };
            var users = new List<CustomUser>() { user }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object);
            int friendId = 12;

            // Act
            userService.AddFriend(userId, friendId);

            // Assert
            mockedFriendService
                .Verify(
                    x => x.AddFriendship(
                        It.Is<int>(i => i == user.Id),
                        It.Is<string>(u => u == friendUser.AspIdentityUserId),
                        It.Is<int>(y => y == friendId)),
                        Times.Once);
        }
    }
}
