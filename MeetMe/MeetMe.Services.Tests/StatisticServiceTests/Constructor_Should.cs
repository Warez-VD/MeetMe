using System;
using NUnit.Framework;
using Moq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;

namespace MeetMe.Services.Tests.StatisticServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_UserServiceIsNull()
        {
            // Arrange
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new StatisticService(
                null,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UserService"));
        }

        [Test]
        public void ThrowsWhen_StatisticRepositoryIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new StatisticService(
                mockedUserService.Object,
                null,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("StatisticRepository"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                null,
                mockedStatisticFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_StatisticFactoryIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("StatisticFactory"));
        }

        [Test]
        public void ReturnInstanceOfStatisticService_Correct()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            // Act
            var statisticService = new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object);

            // Assert
            Assert.IsNotNull(statisticService);
            Assert.IsInstanceOf<StatisticService>(statisticService);
        }
    }
}
