using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Dislikes_Should
    {
        [TestCase(21)]
        [TestCase(123)]
        public void SetDislikes_Correct(int dislikes)
        {
            // Arrange
            var publication = new Publication();

            // Act
            publication.Dislikes = dislikes;

            // Assert
            Assert.AreEqual(publication.Dislikes, dislikes);
        }
    }
}
