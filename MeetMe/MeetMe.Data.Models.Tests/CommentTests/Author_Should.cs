using NUnit.Framework;
using Moq;

namespace MeetMe.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class Author_Should
    {
        [Test]
        public void SetAuthor_Correct()
        {
            // Arrange
            var user = new Mock<CustomUser>();
            var comment = new Comment();

            // Act
            comment.Author = user.Object;

            // Assert
            Assert.AreSame(comment.Author, user.Object);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var comment = new Comment();

            // Act
            bool isVirtual = comment.GetType().GetProperty("Author").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
