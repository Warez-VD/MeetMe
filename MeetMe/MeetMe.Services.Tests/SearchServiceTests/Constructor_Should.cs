using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.SearchServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_AspIdentityUserFactoryIsNull()
        {
            // Arrange & Act
            var ex = Assert.Throws<ArgumentNullException>(() => new SearchService(null));

            // Assert
            Assert.That(ex.Message.Contains("UserRepository"));
        }

        [Test]
        public void ReturnInstanceOfSearchService_Correct()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();

            // Act
            var searchService = new SearchService(mockedUserRepository.Object);

            // Assert
            Assert.IsNotNull(searchService);
            Assert.IsInstanceOf<SearchService>(searchService);
        }
    }
}
