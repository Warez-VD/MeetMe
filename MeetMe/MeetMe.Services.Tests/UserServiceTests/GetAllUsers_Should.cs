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
    public class GetAllUsers_Should
    {
        [Test]
        public void ReturnAllUsersFromRepository()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var users = new List<CustomUser>()
            {
                new CustomUser() { AspIdentityUserId = "second" },
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
            var result = userService.GetAllUsers();

            // Assert
            Assert.AreEqual(users.Count(), result.Count());
        }
    }
}
