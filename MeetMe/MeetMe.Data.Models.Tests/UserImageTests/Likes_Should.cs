using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserImageTests
{
    [TestFixture]
    public class Likes_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetLikes_Correct(int likes)
        {
            // Arrange
            var image = new UserImage();

            // Act
            image.Likes = likes;

            // Assert
            Assert.AreEqual(image.Likes, likes);
        }
    }
}
