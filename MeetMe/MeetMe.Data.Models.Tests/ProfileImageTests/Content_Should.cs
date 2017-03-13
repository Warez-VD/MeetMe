using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ProfileImageTests
{
    [TestFixture]
    public class Content_Should
    {
        [Test]
        public void SetContent_Correct()
        {
            // Arrange
            byte[] content = new byte[] { 12, 45, 65, 22, 11, 66 };
            var image = new ProfileImage();

            // Act
            image.Content = content;

            // Assert
            Assert.AreEqual(image.Content, content);
        }
    }
}
