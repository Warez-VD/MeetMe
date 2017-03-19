using System;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfPublication_WithSetCorrectProperties_WhenCalledWithSecondCtor()
        {
            // Arrange
            string content = "some content";
            int userId = 12;
            DateTime createdOn = new DateTime(2003, 4, 23);

            // Act
            var publication = new Publication(content, userId, createdOn);

            // Assert
            Assert.AreEqual(publication.Content, content);
            Assert.AreEqual(publication.CustomUserId, userId);
            Assert.AreEqual(publication.CreatedOn, createdOn);
            Assert.IsInstanceOf<Publication>(publication);
        }

        [Test]
        public void ReturnInstanceOfPublication_WithSetCorrectProperties_WhenCalledWithLastCtor()
        {
            // Arrange
            string content = "some content";
            int userId = 12;
            DateTime createdOn = new DateTime(2003, 4, 23);
            var image = new Mock<PublicationImage>();

            // Act
            var publication = new Publication(content, userId, createdOn, image.Object);

            // Assert
            Assert.AreEqual(publication.Content, content);
            Assert.AreEqual(publication.CustomUserId, userId);
            Assert.AreEqual(publication.CreatedOn, createdOn);
            Assert.AreEqual(publication.Image, image.Object);
            Assert.IsInstanceOf<Publication>(publication);
        }
    }
}
