using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Models;
using MeetMe.Data.Contracts;
using System.Data.Entity;

namespace MeetMe.Data.Tests.EFRepositoryTests
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnCorrect_AllRecords()
        {
            // Arrange
            var data = new List<Comment>()
            {
                new Comment() { Content = "Some" },
                new Comment() { Content = "Other" },
                new Comment() { Content = "Another" },
                new Comment() { Content = "Again" }
            };
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Comment>(queryableData);

            mockedDbContext.Setup(x => x.Set<Comment>()).Returns(mockedDbSet.Object);
            var repo = new EFRepository<Comment>(mockedDbContext.Object);

            // Act
            var result = repo.All;

            // Assert
            Assert.AreEqual(data.Count, result.Count());
            CollectionAssert.AreEqual(data, result.ToList());
        }

        [Test]
        public void ReturnEmptyCollection_WhenNoElements()
        {
            // Arrange
            var data = new List<Comment>();
            var mockedDbContext = new Mock<IMeetMeDbContext>();
            var queryableData = data.AsQueryable();
            var mockedDbSet = this.GetMockedDbSet<Comment>(queryableData);

            mockedDbContext.Setup(x => x.Set<Comment>()).Returns(mockedDbSet.Object);
            var repo = new EFRepository<Comment>(mockedDbContext.Object);

            // Act
            var result = repo.All;

            // Assert
            Assert.AreEqual(data.Count, result.Count());
            CollectionAssert.AreEqual(data, result.ToList());
        }

        private Mock<IDbSet<T>> GetMockedDbSet<T>(IQueryable<T> data)
            where T : class
        {
            var mockedDbSet = new Mock<IDbSet<T>>();
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.Provider)
                    .Returns(data.Provider);
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.Expression)
                    .Returns(data.Expression);
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                    .Returns(data.ElementType);
            mockedDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                    .Returns(data.GetEnumerator());

            return mockedDbSet;
        }
    }
}
