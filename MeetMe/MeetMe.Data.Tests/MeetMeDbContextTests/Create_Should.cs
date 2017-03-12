using NUnit.Framework;

namespace MeetMe.Data.Tests.MeetMeDbContextTests
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void ReturnInstanceOf_TeamToolsDbContext()
        {
            // Arrange & Act
            var result = MeetMeDbContext.Create();

            // Assert
            Assert.IsInstanceOf<MeetMeDbContext>(result);
        }

        [Test]
        public void ReturnNotNull_TeamToolsDbContext()
        {
            // Arrange & Act
            var result = MeetMeDbContext.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
