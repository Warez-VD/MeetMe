using System;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfComment_WithSetCorrectProperties()
        {
            // Arrange
            string content = "some comment";
            int userId = 14;
            DateTime createdOn = DateTime.Now;

            // Act
            var comment = new Comment(content, userId, createdOn);

            // Assert
            Assert.AreEqual(comment.Content, content);
            Assert.AreEqual(comment.CustomUserId, userId);
            Assert.AreEqual(comment.CreatedOn, createdOn);
            Assert.IsInstanceOf<Comment>(comment);
        }
    }
}
