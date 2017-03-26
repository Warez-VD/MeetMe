using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Navigation;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.NavigationControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnPartialView_IndexPartial()
        {
            // Arrange
            var mockedStatisticService = new Mock<IStatisticService>();
            var mockedMapperService = new Mock<IMapperService>();
            var model = new StatisticViewModel();
            mockedMapperService.Setup(x => x.MapObject<StatisticViewModel>(It.IsAny<Statistic>())).Returns(model);
            
            var navigationController = new NavigationController(
                mockedStatisticService.Object,
                mockedMapperService.Object);
            string userId = "some-id";

            // Act & Assert
            navigationController
                .WithCallTo(x => x.Index(userId))
                .ShouldRenderPartialView("_IndexPartial")
                .WithModel<StatisticViewModel>(m =>
                {
                    Assert.AreEqual(model, m);
                });
        }
    }
}
