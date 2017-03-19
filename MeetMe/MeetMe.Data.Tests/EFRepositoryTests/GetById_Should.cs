using System;
using System.Data.Entity;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using Moq;
using NUnit.Framework;

namespace MeetMe.Data.Tests.EFRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ReturnCorrect_RecordWhenValidIntIdIsPassed()
        {
            // Arrange
            int id = 1;
            var mockedDbSet = new Mock<IDbSet<Comment>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(new Comment() { Id = id });
            var mockedContext = new Mock<IMeetMeDbContext>();
            mockedContext.Setup(x => x.Set<Comment>()).Returns(mockedDbSet.Object);
            var repo = new EFRepository<Comment>(mockedContext.Object);

            // Act
            var record = repo.GetById(id);

            // Assert
            Assert.IsNotNull(record);
            Assert.IsInstanceOf<Comment>(record);
            Assert.AreEqual(id, record.Id);
        }

        [Test]
        public void ReturnCorrect_RecordWhenValidStringIdIsPassed()
        {
            // Arrange
            string id = "abcd-some";
            var mockedDbSet = new Mock<IDbSet<AspIdentityUser>>();
            mockedDbSet.Setup(x => x.Find(It.IsAny<string>())).Returns(new AspIdentityUser() { Id = id });
            var mockedContext = new Mock<IMeetMeDbContext>();
            mockedContext.Setup(x => x.Set<AspIdentityUser>()).Returns(mockedDbSet.Object);
            var repo = new EFRepository<AspIdentityUser>(mockedContext.Object);

            // Act
            var record = repo.GetById(id);

            // Assert
            Assert.IsNotNull(record);
            Assert.IsInstanceOf<AspIdentityUser>(record);
            Assert.AreEqual(id, record.Id);
        }

        [Test]
        public void ReturnNull_WhenRecordIsNotFoundWithIntParameter()
        {
            // Arrange
            int[] ids = new int[] { 1, 2, 3, 4 };
            var mockedDbSet = new Mock<IDbSet<Comment>>();
            mockedDbSet.Setup(x => x.Find(It.Is<int>(id => ids.Contains(id))))
                .Returns(new Comment());
            var mockedContext = new Mock<IMeetMeDbContext>();
            mockedContext.Setup(x => x.Set<Comment>()).Returns(mockedDbSet.Object);
            var repo = new EFRepository<Comment>(mockedContext.Object);

            // Act
            var record = repo.GetById(10);

            // Assert
            Assert.IsNull(record);
        }

        [Test]
        public void ReturnNull_WhenRecordIsNotFoundWithStringParameter()
        {
            // Arrange
            string[] ids = new string[] { "absc-asdf", "absc-fdasf", "dfas-asdf", "absc-gfd" };
            var mockedDbSet = new Mock<IDbSet<AspIdentityUser>>();
            mockedDbSet.Setup(x => x.Find(It.Is<string>(id => ids.Contains(id))))
                .Returns(new AspIdentityUser());
            var mockedContext = new Mock<IMeetMeDbContext>();
            mockedContext.Setup(x => x.Set<AspIdentityUser>()).Returns(mockedDbSet.Object);
            var repo = new EFRepository<AspIdentityUser>(mockedContext.Object);

            // Act
            var record = repo.GetById("hha-skk");

            // Assert
            Assert.IsNull(record);
        }

        [Test]
        public void Throw_WhenIdLessThanZeroIsPassed()
        {
            // Arrange
            int testId = -10;
            var mockedContext = new Mock<IMeetMeDbContext>();
            var repo = new EFRepository<Comment>(mockedContext.Object);

            // Act
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => repo.GetById(testId));

            // Assert
            Assert.That(ex.Message.Contains("Id"));
        }

        [Test]
        public void Throw_WhenIdIsNull()
        {
            // Arrange
            string testId = null;
            var mockedContext = new Mock<IMeetMeDbContext>();
            var repo = new EFRepository<AspIdentityUser>(mockedContext.Object);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => repo.GetById(testId));

            // Assert
            Assert.That(ex.Message.Contains("Id"));
        }
    }
}
