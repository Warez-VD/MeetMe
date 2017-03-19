using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserFriendTests
{
    [TestFixture]
    public class FriendId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetFriendId_Correct(int id)
        {
            // Arrange
            var userFriend = new UserFriend();

            // Act
            userFriend.FriendId = id;

            // Assert
            Assert.AreEqual(userFriend.FriendId, id);
        }
    }
}
