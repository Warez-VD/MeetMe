using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Image_Should
    {
        [Test]
        public void SetImage_Correct()
        {
            // Arrange
            var image = new Mock<PublicationImage>();
            var publication = new Publication();

            // Act
            publication.Image = image.Object;

            // Assert
            Assert.AreSame(publication.Image, image.Object);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var publication = new Publication();

            // Act
            bool isVirtual = publication.GetType().GetProperty("Image").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
