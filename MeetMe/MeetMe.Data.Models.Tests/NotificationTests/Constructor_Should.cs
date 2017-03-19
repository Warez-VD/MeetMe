using System;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfNotification_WithSetCorrectProperties()
        {
            // Arrange
            int userId = 2;
            string content = "some content";
            DateTime createdOn = new DateTime(2014, 2, 12);
            bool isFriendship = false;
            int targetId = 14;

            // Act
            var notification = new Notification(userId, content, createdOn, isFriendship, targetId);

            // Assert
            Assert.AreEqual(notification.CustomUserId, userId);
            Assert.AreEqual(notification.Content, content);
            Assert.AreEqual(notification.CreatedOn, createdOn);
            Assert.AreEqual(notification.IsFriendship, isFriendship);
            Assert.AreEqual(notification.TargetUserId, targetId);
            Assert.IsInstanceOf<Notification>(notification);
        }
    }
}
