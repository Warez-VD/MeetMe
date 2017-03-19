using MeetMe.Data.Contracts;
using Moq;
using NUnit.Framework;

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
