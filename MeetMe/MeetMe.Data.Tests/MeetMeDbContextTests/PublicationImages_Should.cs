using NUnit.Framework;
using Moq;
using System.Data.Entity;
using MeetMe.Data.Models;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class PublicationImages_Should
    {
        [Test]
        public void SetPublicationImages_Correct()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<PublicationImage>>();
            var context = new MeetMeDbContext();

            // Act
            context.PublicationImages = mockedDbSet.Object;

            // Assert
            Assert.AreSame(context.PublicationImages, mockedDbSet.Object);
        }

        [Test]
        public void IsVirtual()
        {
            // Arrange
            var mockedDbSet = new Mock<IDbSet<CustomUser>>();
            var context = new MeetMeDbContext();

            // Act
            bool isVirtual = context.GetType().GetProperty("PublicationImages").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
