using System;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.MessageTests
{
    [TestFixture]
    public class CreatedOn_Should
    {
        [Test]
        public void SetCreatedOn_Correct()
        {
            // Arrange
            DateTime createdOn = new DateTime(1994, 11, 12);
            var message = new Message();

            // Act
            message.CreatedOn = createdOn;

            // Assert
            Assert.AreEqual(message.CreatedOn, createdOn);
        }
    }
}
