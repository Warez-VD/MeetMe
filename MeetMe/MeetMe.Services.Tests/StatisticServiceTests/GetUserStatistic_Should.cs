using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Moq;
using MeetMe.Services.Contracts;
using MeetMe.Data.Models;
using MeetMe.Data.Contracts;

namespace MeetMe.Services.Tests.StatisticServiceTests
{
    [TestFixture]
    public class GetUserStatistic_Should
    {
        [Test]
        public void CallUserService_GetByIndentityIdOnce()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedStatisticFactory = new Mock<IStatisticFactory>();

            var statisticService = new StatisticService(
                mockedUserService.Object,
                mockedStatisticRepository.Object,
                mockedUnitOfWork.Object,
                mockedStatisticFactory.Object);
            string userId = "some-id";

            // Act
            statisticService.GetUserStatistic(userId);

            // Assert
            mockedUserService.Verify(x => x.GetByIndentityId(It.Is<string>(i => i == userId)), Times.Once);
        }

        [Test]
        public void ReturnCorrectStatistic()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var user = new CustomUser() { Id = 1 };
            mockedUserService.Setup(x => x.GetByIndentityId(It.IsAny<string>())).Returns(user);
            var mockedStatisticRepository = new Mock<IEFRepository<Statistic>>();
            var statistic = new Statistic() { CustomUserId = 1 };
            var statistics = new List<Statistic>()
            {
                new Statistic() { CustomUserId = 32 },
                new Statistic() { CustomUserId = 12 },
                statistic
            }.AsQueryable();
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
            var result = statisticService.GetUserStatistic(userId);

            // Assert
            Assert.AreEqual(result, statistic);
        }
    }
}
