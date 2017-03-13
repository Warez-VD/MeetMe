using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class Content_Should
    {
        [TestCase("ItOkay")]
        [TestCase("ItOkayToo")]
        public void SetContent_Correct(string content)
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.Content = content;

            // Assert
            Assert.AreEqual(comment.Content, content);
        }
    }
}
