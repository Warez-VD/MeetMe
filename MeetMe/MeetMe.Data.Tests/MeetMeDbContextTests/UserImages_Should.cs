using NUnit.Framework;
using Moq;
using System.Data.Entity;
using MeetMe.Data.Models;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class UserImages_Should
    {
        [Test]
        public void SetUserImages_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<UserImage>>();
            var context = new MeetMeDbContext();

            // Act
            context.UserImages = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.UserImages, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("UserImages").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
