using System;
using MeetMe.Data.Contracts;
using MeetMe.Data.Models;
using MeetMe.Services.Contracts;
using Moq;
using NUnit.Framework;

namespace MeetMe.Services.Tests.CommentServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowsWhen_CommentRepositoryIsNull()
        {
            // Arrange
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new CommentService(
                null,
                mockedUnitOfWork.Object,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("CommentRepository"));
        }

        [Test]
        public void ThrowsWhen_UnitOfWorkIsNull()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new CommentService(
                mockedCommentRepository.Object,
                null,
                mockedCommentFactory.Object));

            // Assert
            Assert.That(ex.Message.Contains("UnitOfWork"));
        }

        [Test]
        public void ThrowsWhen_CommentFactoryIsNull()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new CommentService(
                mockedCommentRepository.Object,
                mockedUnitOfWork.Object,
                null));

            // Assert
            Assert.That(ex.Message.Contains("CommentFactory"));
        }

        [Test]
        public void ReturnInstanceOfAccountService_Correct()
        {
            // Arrange
            var mockedCommentRepository = new Mock<IEFRepository<Comment>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedCommentFactory = new Mock<ICommentFactory>();

            // Act
            var commentService = new CommentService(
                mockedCommentRepository.Object,
                mockedUnitOfWork.Object,
                mockedCommentFactory.Object);

            // Assert
            Assert.IsNotNull(commentService);
            Assert.IsInstanceOf<CommentService>(commentService);
        }
    }
}
