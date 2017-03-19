using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserFriendTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfUserFriend_WithSetCorrectProperties()
        {
            // Arrange
            int userId = 2;
            string friendIdentityId = "some-xx-id";
            int friendId = 12;

            // Act
            var userFriend = new UserFriend(userId, friendIdentityId, friendId);

            // Assert
            Assert.AreEqual(userFriend.UserId, userId);
            Assert.AreEqual(userFriend.FriendIdentityId, friendIdentityId);
            Assert.AreEqual(userFriend.FriendId, friendId);
            Assert.IsInstanceOf<UserFriend>(userFriend);
        }
    }
}
