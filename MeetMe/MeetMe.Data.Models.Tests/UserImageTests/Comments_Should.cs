using System.Collections.Generic;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.UserImageTests
{
    [TestFixture]
    public class Comments_Should
    {
        [Test]
        public void SetComments_Correct()
        {
            // Arrange
            var comments = new HashSet<Comment>();
            var image = new UserImage();

            // Act
            image.Comments = comments;

            // Assert
            Assert.AreSame(image.Comments, comments);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var image = new UserImage();

            // Act
            bool isVirtual = image.GetType().GetProperty("Comments").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
