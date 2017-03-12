using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Models;
using MeetMe.Data.Contracts;
using System.Data.Entity;

namespace MeetMe.Data.Tests.EFRepositoryTests
{
    public class Update_Should
    {
        [Test]
        public void CallStateFactory_Once()
        {
            // Arrange
            var mockedComment = new Mock<Comment>();
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var mockedEntryState = new Mock<IEntryState<Comment>>();
            mockedEntryState.Object.State = EntityState.Modified;
            mockedDbContext.Setup(x => x.GetState(mockedComment.Object)).Returns(mockedEntryState.Object);
            var repo = new EFRepository<Comment>(mockedDbContext.Object);

            // Act
            repo.Update(mockedComment.Object);

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
            var ex = Assert.Throws<ArgumentNullException>(() => repo.Update(null));

            // Assert
            Assert.That(ex.Message.Contains("Entity"));
        }
    }
}
