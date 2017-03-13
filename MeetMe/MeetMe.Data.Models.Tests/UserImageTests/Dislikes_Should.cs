using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserImageTests
{
    [TestFixture]
    public class Dislikes_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetDislikes_Correct(int dislikes)
        {
            // Arrange
            var image = new UserImage();

            // Act
            image.Dislikes = dislikes;

            // Assert
            Assert.AreEqual(image.Dislikes, dislikes);
        }
    }
}
