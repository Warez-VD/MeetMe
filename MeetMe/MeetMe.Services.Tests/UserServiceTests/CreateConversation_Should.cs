using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.UserServiceTests
{
    [TestFixture]
    public class CreateConversation_Should
    {
        [Test]
        public void CallConversationService_CreateConversationOnce()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var user = new CustomUser() { Id = 2, AspIdentityUserId = "friend-id-xx" };
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);
            var mockedFriendService = new Mock<IFriendService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedConversationService = new Mock<IConversationService>();
            
            var userService = new UserService(
                mockedUserRepository.Object,
                mockedFriendService.Object,
                mockedUnitOfWork.Object,
                mockedConversationService.Object);
            string userId = "user-id-xx";
            int friendId = 2;

            // Act
            userService.CreateConversation(userId, friendId);

            // Assert
            mockedConversationService.Verify(x => x.CreateConversation(userId, user.AspIdentityUserId), Times.Once);
        }
    }
}
