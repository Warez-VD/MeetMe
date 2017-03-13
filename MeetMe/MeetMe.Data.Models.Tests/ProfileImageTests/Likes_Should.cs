using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.ProfileImageTests
{
    [TestFixture]
    public class Likes_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetLikes_Correct(int likes)
        {
            // Arrange
            var image = new ProfileImage();

            // Act
            image.Likes = likes;

            // Assert
            Assert.AreEqual(image.Likes, likes);
        }
    }
}
