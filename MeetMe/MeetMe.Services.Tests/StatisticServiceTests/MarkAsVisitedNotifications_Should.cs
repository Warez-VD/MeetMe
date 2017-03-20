using System.Collections.Generic;
using System.Linq;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.StatisticServiceTests
{
    [TestFixture]
    public class MarkAsVisitedNotifications_Should
    {
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
            statisticService.MarkAsVisitedNotifications(userId);

            // Assert
            mockedStatisticRepository.Verify(x => x.Update(It.Is<Statistic>(s => s == statistic && statistic.NotificationsCount == 0)), Times.Once);
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
            statisticService.MarkAsVisitedNotifications(userId);

            // Assert
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
