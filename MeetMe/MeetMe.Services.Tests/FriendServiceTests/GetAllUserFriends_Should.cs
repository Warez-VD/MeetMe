using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.FriendServiceTests
{
    [TestFixture]
    public class GetAllUserFriends_Should
    {
        [Test]
        public void CallUserRepository_FriendsCountTimes()
        {
            // Arrange
            int id = 5;
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendIds = new List<int>() { 1, 2, 3 };
            mockedUserFriendRepository.Setup(x => x.All).Returns(new List<UserFriend>()
            {
                new UserFriend() { UserId = id, FriendId = 1 },
                new UserFriend() { UserId = id, FriendId = 2 },
                new UserFriend() { UserId = id, FriendId = 3 }
            }.AsQueryable());
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            mockedUserRepository.SetupSequence(x => x.GetById(It.IsAny<int>()))
                .Returns(new CustomUser() { Id = friendIds[0] })
                .Returns(new CustomUser() { Id = friendIds[1] })
                .Returns(new CustomUser() { Id = friendIds[2] });
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            
            // Act
            friendService.GetAllUserFriends(id);

            // Assert
            for (int i = 0; i < friendIds.Count; i++)
            {
                mockedUserRepository.Verify(x => x.GetById(It.Is<int>(u => u == friendIds[i])));
            }
        }

        [Test]
        public void ReturnCorrectFriends()
        {
            // Arrange
            int id = 5;
            var mockedUserFriendRepository = new Mock<IEFRepository<UserFriend>>();
            var friendIds = new List<int>() { 1, 2, 3 };
            mockedUserFriendRepository.Setup(x => x.All).Returns(new List<UserFriend>()
            {
                new UserFriend() { UserId = id, FriendId = 1 },
                new UserFriend() { UserId = id, FriendId = 2 },
                new UserFriend() { UserId = id, FriendId = 3 }
            }.AsQueryable());
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var expected = new List<CustomUser>()
            {
                new CustomUser() { Id = friendIds[0] },
                new CustomUser() { Id = friendIds[1] },
                new CustomUser() { Id = friendIds[2] }
            };
            mockedUserRepository.SetupSequence(x => x.GetById(It.IsAny<int>()))
                .Returns(expected[0])
                .Returns(expected[1])
                .Returns(expected[2]);
            var mockedUserFriendFactory = new Mock<IUserFriendFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var friendService = new FriendService(
                mockedUserFriendRepository.Object,
                mockedUserRepository.Object,
                mockedUserFriendFactory.Object,
                mockedUnitOfWork.Object);
            
            // Act
            var result = friendService.GetAllUserFriends(id);

            // Assert
            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
