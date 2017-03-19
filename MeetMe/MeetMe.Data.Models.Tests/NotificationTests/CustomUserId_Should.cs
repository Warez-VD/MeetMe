using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class CustomUserId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetCustomUserId_Correct(int id)
        {
            // Arrange
            var notification = new Notification();

            // Act
            notification.CustomUserId = id;

            // Assert
            Assert.AreEqual(notification.CustomUserId, id);
        }
    }
}
