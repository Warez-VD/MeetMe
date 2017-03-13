using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationImageTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfPublicationImage_WithSetCorrectProperties()
        {
            // Arrange
            byte[] content = new byte[] { 123, 12, 45, 54 };

            // Act
            var image = new PublicationImage(content);

            // Assert
            Assert.AreEqual(image.Content, content);
            Assert.IsInstanceOf<PublicationImage>(image);
        }
    }
}
