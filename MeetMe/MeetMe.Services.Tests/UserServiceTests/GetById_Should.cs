using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallUserRepository_GetByIdOnce()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();

            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);
            int userId = 11;

            // Act
            userService.GetById(userId);

            // Assert
            mockedUserRepository.Verify(x => x.GetById(It.Is<int>(i => i == userId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectUser_WhenFound()
        {
            // Arrange
            int userId = 11;
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { Id = userId };
            mockedUserRepository.Setup(x => x.GetById(It.Is<int>(i => i == userId))).Returns(user);
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();

            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);

            // Act
            var result = userService.GetById(userId);

            // Assert
            Assert.AreEqual(result, user);
        }

        [Test]
        public void ReturnNull_WhenUserNotFound()
        {
            // Arrange
            int userId = 11;
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { Id = userId };
            mockedUserRepository.Setup(x => x.GetById(It.Is<int>(i => i == userId))).Returns(user);
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();

            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);
            int otherUserId = 50;

            // Act
            var result = userService.GetById(otherUserId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
