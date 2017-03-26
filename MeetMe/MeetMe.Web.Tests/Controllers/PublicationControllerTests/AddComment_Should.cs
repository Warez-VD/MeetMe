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
    public class AddComment_Should
    {
        [Test]
        public void RenderPartialView_PublicationCommentPartial()
        {
            // Arrange
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedTextService = new Mock<ITextService>();
            var mockedViewModelService = new Mock<IViewModelService>();
            var comments = new List<CommentViewModel>()
            {
                new CommentViewModel(),
                new CommentViewModel()
            };
            mockedViewModelService.Setup(x => x.GetMappedComments(It.IsAny<Publication>())).Returns(comments);

            var publicationController = new PublicationController(
                mockedPublicationService.Object,
                mockedTextService.Object,
                mockedViewModelService.Object);
            int id = 5;
            string comment = "some comment";
            string userId = "user-id";

            // Act & Assert
            publicationController
                .WithCallTo(x => x.AddComment(id, comment, userId))
                .ShouldRenderPartialView("_PublicationCommentPartial")
                .WithModel<IList<CommentViewModel>>(m =>
                {
                    Assert.AreEqual(comments, m);
                }); 
        }
    }
}
