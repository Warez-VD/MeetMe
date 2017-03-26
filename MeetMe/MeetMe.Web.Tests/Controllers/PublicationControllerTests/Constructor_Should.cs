using System;
using MeetMe.Services.Contracts;
using MeetMe.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace MeetMe.Web.Tests.Controllers.PublicationControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_PublicationServiceIsNull()
        {
            // Arrange
            var mockedTextService = new Mock<ITextService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationController(
                null,
                mockedTextService.Object,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("PublicationService"));
        }

        [Test]
        public void ThrowsWhen_TextServiceIsNull()
        {
            // Arrange
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationController(
                mockedPublicationService.Object,
                null,
                mockedViewModelService.Object));

            // Assert
            Assert.That(ex.Message.Contains("TextService"));
        }

        [Test]
        public void ThrowsWhen_ViewModelServiceIsNull()
        {
            // Arrange
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedTextService = new Mock<ITextService>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new PublicationController(
                mockedPublicationService.Object,
                mockedTextService.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("ViewModelService"));
        }

        [Test]
        public void ReturnInstanceOfPublicationController_Correct()
        {
            // Arrange
            var mockedPublicationService = new Mock<IPublicationService>();
            var mockedTextService = new Mock<ITextService>();
            var mockedViewModelService = new Mock<IViewModelService>();

            // Act
            var publicationController = new PublicationController(
                mockedPublicationService.Object,
                mockedTextService.Object,
                mockedViewModelService.Object);

            // Assert
            Assert.IsNotNull(publicationController);
            Assert.IsInstanceOf<PublicationController>(publicationController);
        }
    }
}
