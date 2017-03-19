using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserFriendTests
{
    [TestFixture]
    public class FriendIdentityId_Should
    {
        [TestCase("some-xx-1")]
        [TestCase("other-xx-26")]
        public void SetFriendId_Correct(string id)
        {
            // Arrange
            var userFriend = new UserFriend();

            // Act
            userFriend.FriendIdentityId = id;

            // Assert
            Assert.AreEqual(userFriend.FriendIdentityId, id);
        }
    }
}
