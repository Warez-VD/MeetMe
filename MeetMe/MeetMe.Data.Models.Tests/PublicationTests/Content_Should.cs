using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.PublicationTests
{
    [TestFixture]
    public class Content_Should
    {
        [TestCase("some content")]
        [TestCase("other content")]
        public void SetCity_Correct(string content)
        {
            // Arrange
            var publication = new Publication();

            // Act
            publication.Content = content;

            // Assert
            Assert.AreEqual(publication.Content, content);
        }
    }
}
