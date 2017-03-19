using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.EFRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void BeInstanceOfIRepository_Correct()
        {
            // Arrange
            var mockedDbContext = new Mock<IMeetMeDbContext>();

            // Act
            var repo = new EFRepository<AspIdentityUser>(mockedDbContext.Object);

            // Assert
            Assert.IsInstanceOf<IEFRepository<AspIdentityUser>>(repo);
        }

        [Test]
        public void NotBeNull()
        {
            // Arrange
            var mockedDbContext = new Mock<IMeetMeDbContext>();

            // Act
            var repo = new EFRepository<AspIdentityUser>(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(repo);
        }

        [Test]
        public void Throw_WhenDbContextIsNull()
        {
            // Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() => new EFRepository<AspIdentityUser>(null));

            // Assert
            Assert.That(ex.Message.Contains("DbContext"));
        }
    }
}
