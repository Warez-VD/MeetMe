using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using System.Data.Entity;
using MeetMe.Data.Models;

namespace MeetMe.Data.Tests.EFRepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        [Test]
        public void CallStateFactory_Once()
        {
            // Arrange
            var mockedComment = new Mock<Comment>();
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var mockedEntryState = new Mock<IEntryState<Comment>>();
            mockedEntryState.Object.State = EntityState.Added;
            mockedDbContext.Setup(x => x.GetState(mockedComment.Object)).Returns(mockedEntryState.Object);
            var repo = new EFRepository<Comment>(mockedDbContext.Object);

            // Act
            repo.Add(mockedComment.Object);

            // Assert
            mockedDbContext.Verify(x => x.GetState(mockedComment.Object), Times.Once);
        }

        [Test]
        public void Throw_WhenEntityIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var repo = new EFRepository<Comment>(mockedDbContext.Object);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => repo.Add(null));

            // Assert
            Assert.That(ex.Message.Contains("Entity"));
        }
    }
}
