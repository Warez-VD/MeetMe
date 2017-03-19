using NUnit.Framework;
using Moq;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void SetUser_Correct()
        {
            // Arrange
            var user = new Mock<CustomUser>();
            var notification = new Notification();

            // Act
            notification.User = user.Object;

            // Assert
            Assert.AreSame(notification.User, user.Object);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var notification = new Notification();

            // Act
            bool isVirtual = notification.GetType().GetProperty("User").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
