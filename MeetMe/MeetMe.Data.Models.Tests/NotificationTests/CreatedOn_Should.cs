using System;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class CreatedOn_Should
    {
        [Test]
        public void SetCreatedOn_Correct()
        {
            // Arrange
            var notification = new Notification();
            var date = new DateTime(2015, 2, 20);

            // Act
            notification.CreatedOn = date;

            // Assert
            Assert.AreEqual(notification.CreatedOn, date);
        }
    }
}
