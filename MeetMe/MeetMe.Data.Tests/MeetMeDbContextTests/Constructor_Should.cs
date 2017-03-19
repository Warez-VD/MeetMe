using System;
using MeetMe.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeTeamToolsDbContext_Correct()
        {
            // Arrange & Act
            var context = new MeetMeDbContext();

            // Assert
            Assert.IsNotNull(context);
        }

        [Test]
        public void ThrowWhenStateFactory_IsNull()
        {
            // Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() => new MeetMeDbContext(null));

            // Assert
            Assert.That(ex.Message.Contains("StateFactory"));
        }

        [Test]
        public void InitializeTeamToolsDbContext_CorrectWhenStateFactoryIsSet()
        {
            // Arrange
            var mockedFactory = new Mock<IStateFactory>();

            // Act
            var context = new MeetMeDbContext(mockedFactory.Object);

            // Assert
            Assert.IsNotNull(context);
        }
    }
}
