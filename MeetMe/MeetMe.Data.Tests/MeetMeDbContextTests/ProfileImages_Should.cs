using NUnit.Framework;
using Moq;
using MeetMe.Data.Models;
using System.Data.Entity;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class ProfileImages_Should
    {
        [Test]
        public void SetProfileImages_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<ProfileImage>>();
            var context = new MeetMeDbContext();

            // Act
            context.ProfileImages = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.ProfileImages, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("ProfileImages").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
