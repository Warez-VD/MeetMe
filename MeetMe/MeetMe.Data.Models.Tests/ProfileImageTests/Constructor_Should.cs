using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ProfileImageTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnInstanceOfProfileImage_WithSetCorrectProperties()
        {
            // Arrange
            byte[] content = new byte[] { 123, 12, 45, 54 };

            // Act
            var image = new ProfileImage(content);

            // Assert
            Assert.AreEqual(image.Content, content);
            Assert.IsInstanceOf<ProfileImage>(image);
        }
    }
}
