using MeetMe.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Commit_Should
    {
        [Test]
        public void CallSaveChanges_Once()
        {
            // Arrange
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Act
            unitOfWork.Commit();

            // Assert
            mockedDbContext.Verify(dbContext => dbContext.SaveChanges(), Times.Once);
        }
    }
}
