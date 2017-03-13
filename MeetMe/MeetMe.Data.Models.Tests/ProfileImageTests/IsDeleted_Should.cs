using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ProfileImageTests
{
    [TestFixture]
    public class IsDeleted_Should
    {
        [TestCase(true)]
        [TestCase(false)]
        public void SetIsDeleted_Correct(bool isDeleted)
        {
            // Arrange
            var image = new ProfileImage();

            // Act
            image.IsDeleted = isDeleted;

            // Assert
            Assert.AreEqual(image.IsDeleted, isDeleted);
        }
    }
}
