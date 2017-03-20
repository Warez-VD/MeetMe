using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.SearchServiceTests
{
    [TestFixture]
    public class SearchedUsers_Should
    {
        [Test]
        public void ReturnCorrectUsers_WhenMatchPattern()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var matchUsers = new List<CustomUser>()
            {
                new CustomUser() { Id = 1, FullName = "John Smith" },
                new CustomUser() { Id = 2, FullName = "Smithy Johnson" }
            };
            var users = new List<CustomUser>()
            {
                new CustomUser() { Id = 3, FullName = "Michael Someone" }
            };
            users.AddRange(matchUsers);
            mockedUserRepository.Setup(x => x.All).Returns(users.AsQueryable());

            var searchService = new SearchService(mockedUserRepository.Object);
            string pattern = "mith";
            int skip = 0;
            int count = 10;

            // Act
            var result = searchService.SearchedUsers(pattern, skip, count);

            // Assert
            CollectionAssert.AreEqual(result, matchUsers);
        }

        [Test]
        public void ReturnCorrectUsers_WhenMatchPatternAndCountIsSet()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var users = new List<CustomUser>()
            {
                new CustomUser() { Id = 1, FullName = "John Smith" },
                new CustomUser() { Id = 2, FullName = "Smithy Johnson" },
                new CustomUser() { Id = 3, FullName = "John Smith" },
                new CustomUser() { Id = 4, FullName = "Smithy Johnson" },
                new CustomUser() { Id = 5, FullName = "Michael Someone" }
            }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);

            var searchService = new SearchService(mockedUserRepository.Object);
            string pattern = "mith";
            int skip = 0;
            int count = 3;

            // Act
            var result = searchService.SearchedUsers(pattern, skip, count);

            // Assert
            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void ReturnCorrectUsers_WhenMatchPatternAndCountIsSetAndSkipIsSet()
        {
            // Arrange
            var mockedUserRepository = new Mock<IEFRepository<CustomUser>>();
            var users = new List<CustomUser>()
            {
                new CustomUser() { Id = 1, FullName = "John Smith" },
                new CustomUser() { Id = 2, FullName = "Smithy Johnson" },
                new CustomUser() { Id = 3, FullName = "John Smith" },
                new CustomUser() { Id = 4, FullName = "Smithy Johnson" },
                new CustomUser() { Id = 5, FullName = "Michael Someone" }
            }.AsQueryable();
            mockedUserRepository.Setup(x => x.All).Returns(users);

            var searchService = new SearchService(mockedUserRepository.Object);
            string pattern = "mith";
            int skip = 2;
            int count = 4;

            // Act
            var result = searchService.SearchedUsers(pattern, skip, count);

            // Assert
            Assert.AreEqual(result.Count, 2);
        }
    }
}
