using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models.Tests.NotificationTests
{
    [TestFixture]
    public class Content_Should
    {
        [TestCase("Content")]
        [TestCase("Some")]
        public void SetContent_Correct(string content)
        {
            // Arrange
            var notification = new Notification();

            // Act
            notification.Content = content;

            // Assert
            Assert.AreEqual(notification.Content, content);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            // Arrange
            var notification = new Notification();
            var property = notification.GetType().GetProperty("Content");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
