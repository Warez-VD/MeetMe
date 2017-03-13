using System;
using NUnit.Framework;
using System.ComponentModel.DataAnnotations;

namespace MeetMe.Data.Models.Tests.CustomUserTests
{
    [TestFixture]
    public class Company_Should
    {
        [TestCase("CompanyOne")]
        [TestCase("CompanyTwo")]
        public void SetCompany_Correct(string company)
        {
            // Arrange
            var user = new CustomUser();

            // Act
            user.Company = company;

            // Assert
            Assert.AreEqual(user.Company, company);
        }

        [Test]
        public void HaveMaxLength_Attribute()
        {
            // Arrange
            var user = new CustomUser();
            var property = user.GetType().GetProperty("Company");

            // Act
            bool isDefined = Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            // Assert
            Assert.IsTrue(isDefined);
        }
    }
}
