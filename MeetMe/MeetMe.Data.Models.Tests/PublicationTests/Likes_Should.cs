using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Likes_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetLikes_Correct(int likes)
        {
            // Arrange
            var publication = new Publication();

            // Act
            publication.Likes = likes;

            // Assert
            Assert.AreEqual(publication.Likes, likes);
        }
    }
}
