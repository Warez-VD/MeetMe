using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using MeetMe.Services.Contracts;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;

namespace MeetMe.Services.Tests.StatisticServiceTests
{
    [TestFixture]
    public class AddMessageStatistic_Should
    {
        [Test]
        public void CallUserService_GetByIndentityIdOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var statistics = new List<Statistic>() { new Statistic() { CustomUserId = 1 } }.AsQueryable();
            mockedStatisticRepository.Setup(x => x.All).Returns(statistics);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();
            
            var statisticService = new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object);
            string userId = "some-id";

            // Act
            statisticService.AddMessageStatistic(userId);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void IncreasedStatistic_MessagesCountWithOne()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var statistic = new Statistic() { CustomUserId = 1 };
            var statistics = new List<Statistic>() { statistic }.AsQueryable();
            mockedStatisticRepository.Setup(x => x.All).Returns(statistics);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            var statisticService = new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object);
            string userId = "some-id";

            // Act
            statisticService.AddMessageStatistic(userId);

            // Assert
            Assert.AreEqual(statistic.MessagesCount, 1);
        }

        [Test]
        public void CallStatisticRepository_UpdateOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var statistic = new Statistic() { CustomUserId = 1 };
            var statistics = new List<Statistic>() { statistic }.AsQueryable();
            mockedStatisticRepository.Setup(x => x.All).Returns(statistics);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            var statisticService = new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object);
            string userId = "some-id";

            // Act
            statisticService.AddMessageStatistic(userId);

            // Assert
            mockedStatisticRepository.Verify(x => x.Update(It.Is<Statistic>(s => s == statistic)), Times.Once);
        }

        [Test]
        public void CallUnitOfWork_CommitOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var statistic = new Statistic() { CustomUserId = 1 };
            var statistics = new List<Statistic>() { statistic }.AsQueryable();
            mockedStatisticRepository.Setup(x => x.All).Returns(statistics);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            var statisticService = new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object);
            string userId = "some-id";

            // Act
            statisticService.AddMessageStatistic(userId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
