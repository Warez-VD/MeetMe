using System;
using System.Data.Entity;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.EFRepositoryTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void CallStateFactory_Once()
        {
            // Arrange
            var mockedComment = new Mock<Comment>();
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var mockedEntryState = new Mock<IEntryState<Comment>>();
            mockedEntryState.Object.State = EntityState.Deleted;
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
            var ex = Assert.Throws<ArgumentNullException>(() => repo.Delete(null));

            // Assert
            Assert.That(ex.Message.Contains("Entity"));
        }
    }
}
