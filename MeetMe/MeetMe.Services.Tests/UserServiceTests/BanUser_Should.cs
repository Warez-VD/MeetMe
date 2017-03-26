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
    public class BanUser_Should
    {
        [Test]
        public void CallUserRepository_UpdateOnce()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();

            string userId = "user-id-xx";
            var user = new CustomUser() { AspIdentityUserId = userId };
            var users = new List<CustomUser>()
            {
                user,
                new CustomUser() { AspIdentityUserId = "first" },
                new CustomUser() { AspIdentityUserId = "third" }
            }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);

            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);
            

            // Act
            userService.BanUser(userId);

            // Assert
            mockedUserRepository.Verify(x => x.Update(It.Is<CustomUser>(u => u == user && user.IsBanned == true)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();

            string userId = "user-id-xx";
            var user = new CustomUser() { AspIdentityUserId = userId };
            var users = new List<CustomUser>()
            {
                user,
                new CustomUser() { AspIdentityUserId = "first" },
                new CustomUser() { AspIdentityUserId = "third" }
            }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);

            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);


            // Act
            userService.BanUser(userId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
