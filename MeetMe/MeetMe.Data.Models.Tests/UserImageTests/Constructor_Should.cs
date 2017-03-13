using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserImageTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfUserImage_WithSetCorrectProperties()
        {
            // Arrange
            byte[] content = new byte[] { 123, 12, 45, 54 };

            // Act
            var image = new UserImage(content);

            // Assert
            Assert.AreEqual(image.Content, content);
            Assert.IsInstanceOf<UserImage>(image);
        }
    }
}
