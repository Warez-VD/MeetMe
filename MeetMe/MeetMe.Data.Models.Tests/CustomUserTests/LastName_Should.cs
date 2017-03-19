using System;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class LastName_Should
    {
        [TestCase("ItOkay")]
        [TestCase("ItOkayToo")]
        public void SetFirstName_Correct(string lastName)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.LastName = lastName;

            // Assert
            Assert.AreEqual(user.LastName, lastName);
        }

        [Test]
        public void HaveRequired_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("LastName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(RequiredAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMinLength_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("LastName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MinLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("LastName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
