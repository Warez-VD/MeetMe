using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsDeleted_Correct(bool isDeleted)
        {
            // Arrange
            var notification = new Notification();

            // Act
            notification.IsDeleted = isDeleted;

            // Assert
            Assert.AreEqual(notification.IsDeleted, isDeleted);
        }
    }
}
