using NUnit.Framework;
using Moq;

namespace MeetMe.Data.Models.Tests.StatisticTests
{
    [TestFixture]
    public class User_Should
    {
        [Test]
        public void SetUser_Correct()
        {
            // Arrange
            var user = new Mock<CustomUser>();
            var statistic = new Statistic();

            // Act
            statistic.User = user.Object;

            // Assert
            Assert.AreSame(statistic.User, user.Object);
        }

        [Test]
        public void BeVirtual()
        {
            // Arrange
            var statistic = new Statistic();

            // Act
            bool isVirtual = statistic.GetType().GetProperty("User").GetGetMethod().IsVirtual;

            // Assert
            Assert.IsTrue(isVirtual);
        }
    }
}
