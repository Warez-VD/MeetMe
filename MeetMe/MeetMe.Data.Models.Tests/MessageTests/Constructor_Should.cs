using System;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.MessageTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfMessage_WithSetCorrectProperties()
        {
            // Arrange
            string content = "some content";
            var user = new Mock<CustomUser>();
            DateTime createdOn = new DateTime(2017, 4, 1);

            // Act
            var message = new Message(content, user.Object, createdOn);

            // Assert
            Assert.AreEqual(message.Content, content);
            Assert.AreEqual(message.User, user.Object);
            Assert.AreEqual(message.CreatedOn, createdOn);
            Assert.IsInstanceOf<Message>(message);
        }
    }
}
