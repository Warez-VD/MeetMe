using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class FirstName_Should
    {
        [TestCase("ItOkay")]
        [TestCase("ItOkayToo")]
        public void SetFirstName_Correct(string firstName)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.FirstName = firstName;

            // Assert
            Assert.AreEqual(user.FirstName, firstName);
        }

        [Test]
        public void HaveRequired_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("FirstName");

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
            var property = user.GetType().GetProperty("FirstName");

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
            var property = user.GetType().GetProperty("FirstName");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
