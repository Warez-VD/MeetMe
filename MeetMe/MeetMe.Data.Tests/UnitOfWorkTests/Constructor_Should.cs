using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;

namespace MeetMe.Data.Tests.UnitOfWorkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void InitializeUnitOfWork_Correct()
        {
            // Arrange
            var mockedDbContext = new Mock<IMeetMeDbContext>();

            // Act
            var unitOfWork = new UnitOfWork(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }
    }
}
