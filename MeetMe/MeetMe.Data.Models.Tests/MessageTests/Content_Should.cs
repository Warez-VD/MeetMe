using System;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.MessageTests
{
    [TestFixture]
    public class Content_Should
    {
        [TestCase("some content")]
        [TestCase("other content")]
        public void SetContent_Correct(string content)
        {
            // Arrange
            var message = new Message();

            // Act
            message.Content = content;

            // Assert
            Assert.AreEqual(message.Content, content);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            // Arrange
            var message = new Message();
            var property = message.GetType().GetProperty("Content");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
