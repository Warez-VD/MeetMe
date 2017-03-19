using System.IO;
using NUnit.Framework;

namespace MeetMe.Services.Tests.ImageServiceTests
{
    [TestFixture]
    public class GetImage_Should
    {
        [Test]
        public void ThrowWhenFileIsNotFound()
        {
            // Arrange
            var imageService = new ImageService();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => imageService.GetImage("invalidPath"));
        }
    }
}
