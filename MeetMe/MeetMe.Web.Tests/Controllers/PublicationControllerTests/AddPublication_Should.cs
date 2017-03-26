using System.Collections.Generic;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using MeetMe.Web.Models.Publications;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MeetMe.Web.Tests.Controllers.PublicationControllerTests
{
    [TestFixture]
    public class AddPublication_Should
    {
        [Test]
        public void RenderPartialView_PublicationPartial()
        {
            // Arrange
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedTextService = new Mock<ITextService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var publications = new List<PublicationViewModel>()
            {
                new PublicationViewModel(),
                new PublicationViewModel()
            };
            mockedViewModelService.Setup(x => x.GetMappedPublications(It.IsAny<IEnumerable<Publication>>())).Returns(publications);

            var publicationController = new PublicationController(
                mockedPublicationService.Object,
                mockedTextService.Object,
                mockedViewModelService.Object);
            string content = "content";
            string userId = "user-id";
            string imageBase64 = "base64";
            int skip = 2;
            int count = 5;

            // Act & Assert
            publicationController
                .WithCallTo(x => x.AddPublication(content, userId, imageBase64, skip, count))
                .ShouldRenderPartialView("_PublicationPartial")
                .WithModel<IEnumerable<PublicationViewModel>>(m =>
                {
                    Assert.AreEqual(publications, m);
                });
        }
    }
}
