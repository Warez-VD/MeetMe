using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserFriendTests
{
    [TestFixture]
    public class UserId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetUserId_Correct(int id)
        {
            // Arrange
            var userFriend = new UserFriend();

            // Act
            userFriend.UserId = id;

            // Assert
            Assert.AreEqual(userFriend.UserId, id);
        }
    }
}
