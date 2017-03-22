using System;
using NUnit.Framework;

namespace MeetMe.Services.Tests.DateTimeServiceTests
{
    [TestFixture]
    public class GetCurrentDate_Should
    {
        [Test]
        public void ReturnCurrentDateTime()
        {
            // Arrange
            var dateTimeService = new DateTimeService();

            // Act
            var result = dateTimeService.GetCurrentDate();

            // Assert
            Assert.AreEqual(result.Day, DateTime.UtcNow.Day);
            Assert.AreEqual(result.Month, DateTime.UtcNow.Month);
            Assert.AreEqual(result.Year, DateTime.UtcNow.Year);
            Assert.IsInstanceOf<DateTime>(result);
        }
    }
}
