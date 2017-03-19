using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class IsFriendship_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsFriendship_Correct(bool isFriendship)
        {
            // Arrange
            var notification = new Notification();

            // Act
            notification.IsFriendship = isFriendship;

            // Assert
            Assert.AreEqual(notification.IsFriendship, isFriendship);
        }
    }
}
