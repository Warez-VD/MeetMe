using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class TargetUserId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetTargetUserId_Correct(int id)
        {
            // Arrange
            var notification = new Notification();

            // Act
            notification.TargetUserId = id;

            // Assert
            Assert.AreEqual(notification.TargetUserId, id);
        }
    }
}
