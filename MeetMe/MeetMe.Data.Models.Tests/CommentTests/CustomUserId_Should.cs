using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class CustomUserId_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetCustomUserId_Correct(int id)
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.CustomUserId = id;

            // Assert
            Assert.AreEqual(comment.CustomUserId, id);
        }
    }
}
