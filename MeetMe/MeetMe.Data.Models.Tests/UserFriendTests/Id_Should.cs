using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserFriendTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var userFriend = new UserFriend();

            // Act
            userFriend.Id = id;

            // Assert
            Assert.AreEqual(userFriend.Id, id);
        }
    }
}
