using System.Collections.Generic;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Images_Should
    {
        [Test]
        public void SetImages_Correct()
        {
            // Arrange
            var images = new HashSet<UserImage>();
            var user = new CustomUser();

            // Act
            user.Images = images;

            // Assert
            Assert.AreSame(user.Images, images);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var user = new CustomUser();

            // Act
            bool isVirtual = user.GetType().GetProperty("Images").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
