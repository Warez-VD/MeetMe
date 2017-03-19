using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var notification = new Notification();

            // Act
            notification.Id = id;

            // Assert
            Assert.AreEqual(notification.Id, id);
        }
    }
}
