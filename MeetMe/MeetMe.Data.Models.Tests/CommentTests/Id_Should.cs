using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CommentTests
{
    [TestFixture]
    public class Id_Should
    {
        [TestCase(1)]
        [TestCase(550)]
        public void SetId_Correct(int id)
        {
            // Arrange
            var comment = new Comment();

            // Act
            comment.Id = id;

            // Assert
            Assert.AreEqual(comment.Id, id);
        }
    }
}
