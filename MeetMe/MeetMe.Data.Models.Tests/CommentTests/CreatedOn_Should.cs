using System;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class CreatedOn_Should
    {
        [Test]
        public void SetContent_Correct()
        {
            // Arrange
            DateTime createdOn = new DateTime(1994, 11, 12);
            var comment = new Comment();

            // Act
            comment.CreatedOn = createdOn;

            // Assert
            Assert.AreEqual(comment.CreatedOn, createdOn);
        }
    }
}
