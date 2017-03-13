using NUnit.Framework;
using Moq;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Author_Should
    {
        [Test]
        public void SetAuthor_Correct()
        {
            // Arrange
            var user = new Mock<CustomUser>();
            var publication = new Publication();

            // Act
            publication.Author = user.Object;

            // Assert
            Assert.AreSame(publication.Author, user.Object);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var publication = new Publication();

            // Act
            bool isVirtual = publication.GetType().GetProperty("Author").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
